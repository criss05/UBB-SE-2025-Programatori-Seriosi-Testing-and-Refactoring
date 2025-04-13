using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3
{
    public class Config
    {

        public static readonly string DATABASE_CONNECTION_STRING = "Server=localhost\\SQLEXPRESS;Database=Team3;Trusted_Connection=True;TrustServerCertificate=True;";
        public static readonly TimeZoneInfo ROMANIA_TIMEZONE;

        private static Config? instance;
        private static readonly object LockObject = new object();

        public string Username { get; set; } = string.Empty;

        static Config()
        {
            if (!TimeZoneInfo.TryFindSystemTimeZoneById("E. Europe Standard Time", out ROMANIA_TIMEZONE))
            {
                throw new TimeZoneNotFoundException("The specified time zone could not be found.");
            }
        }

        public static Config Instance
        {
            get
            {
                if (instance == null)
                {


                    lock (LockObject)
                    {
                        if (instance == null)
                        {
                            instance = new Config();
                        }
                    }
                }
                return instance;
            }


        }

    }
}
