using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ServiceStack;

namespace NBitcoin.Internal
{
    public class Request
    {
        public string Jsonrpc { get { return "1.0"; } }
        public string Id { get; private set; }
        public string Method { get; private set; }
        public object[] Params { get; private set; }

        private Request(string method, string id, IEnumerable<object> parameters)
        {
            Method = method;
            Id = id;
            Params = parameters.ToArray();
        }

        public static Request FromObject<T>(T payload, string id = null)
        {
            var method = typeof (T).Name.Replace("Request", "").ToLower();
            var request = new Request(method, id ?? Guid.NewGuid().ToString(), ToParams(payload));
            return request;
        }

        public static Request FromString(string method, string payload, string id = null)
        {
            return new Request(method.ToLower(), id ?? Guid.NewGuid().ToString(), new[] {payload});
        }

        private static IEnumerable<object> ToParams<T>(T payload)
        {
            var payloadType = typeof (T);
            return from prop in payloadType.GetPublicProperties()
                let value = prop.GetValue(payload)
                let converter = prop.GetCustomAttribute<ParamConverterAttribute>()
                let isOptional = prop.GetCustomAttribute<OptionalParameterAttribute>() != null
                let convertedValue = value != null
                    ? converter == null ? value : converter.Convert(value)
                    : null
                where convertedValue != null || !isOptional
                select convertedValue;
        }
    }
}
