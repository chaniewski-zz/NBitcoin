using System;
using System.Net;
using ServiceStack;
using ServiceStack.Text;

namespace NBitcoin.Internal
{
    public class JsonRpcHttpClient : IJsonRpcClient
    {
        private readonly string _user;
        private readonly string _password;
        private readonly string _host;
        private readonly int _port;
        private readonly Action<string> _jsonRequestCallback;

        public JsonRpcHttpClient(string user, string password, string host, int port, Action<string> jsonRequestCallback = null)
        {
            JsConfig.EmitLowercaseUnderscoreNames = true;
            JsConfig.ExcludeTypeInfo = true;
            _user = user;
            _password = password;
            _host = host;
            _port = port;
            _jsonRequestCallback = jsonRequestCallback ?? (json => {});
        }

        private string ServerUrl
        {
            get { return string.Format("{0}:{1}", _host, _port); }
        }

        public TOutput InvokeMethod<TOutput>(Request request)
            where TOutput : class, IHasError, new()
        {
            try
            {
                _jsonRequestCallback(request.ToJson());

                return ServerUrl.GetJsonFromUrl(httpRequest =>
                {
                    httpRequest.Method = "POST";
                    httpRequest.Credentials = new NetworkCredential(_user, _password);
                    JsonSerializer.SerializeToStream(request, httpRequest.GetRequestStream());
                }).FromJson<TOutput>();
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    return JsonSerializer.DeserializeFromStream<TOutput>(ex.Response.GetResponseStream());
                }

                return new TOutput
                {
                    Error = new Error { Code = -1, Message = ex.Message }
                };
            }
        }
    }
}
