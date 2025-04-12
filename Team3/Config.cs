using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3
{
    public class Config
    {

        public static readonly string DATABASE_CONNECTION_STRING = "Server=vm;Database=team3;Integrated Security=True;";
        public static readonly TimeZoneInfo ROMANIA_TIMEZONE;

        private static Config? _instance;
        private static readonly object _lock = new object();

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
                if (_instance == null)
                {


                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Config();
                        }
                    }
                }
                return _instance;
            }


        }

    }
}
