using System.Configuration;

namespace NBitcoin.Configuration
{
    public class NBitcoinSection : ConfigurationSection
    {
        [ConfigurationProperty("user", IsRequired = true)]
        public string User
        {
            get { return (string) this["user"]; }
            set { this["user"] = value; }
        }

        [ConfigurationProperty("password", IsRequired = true)]
        public string Password
        {
            get { return (string)this["password"]; }
            set { this["password"] = value; }
        }

        [ConfigurationProperty("host", DefaultValue = "http://127.0.0.1", IsRequired = false)]
        public string Host
        {
            get { return (string)this["host"]; }
            set { this["host"] = value; }
        }

        [ConfigurationProperty("port", DefaultValue = 8332, IsRequired = false)]
        public int Port
        {
            get { return (int)this["port"]; }
            set { this["port"] = value; }
        }
    }
}
