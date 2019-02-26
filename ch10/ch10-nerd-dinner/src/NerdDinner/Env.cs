﻿using System;
using System.Collections.Generic;

namespace NerdDinner
{
    public class Env
    {
        private static Dictionary<string, string> _Values = new Dictionary<string, string>();

        public static string HomePageUrl { get { return Get("HOMEPAGE_URL"); } }

        public static string BingMapsKey { get { return Get("BING_MAPS_KEY"); } }

        public static string IpInfoDbKey { get { return Get("IP_INFO_DB_KEY"); } }

        private static string Get(string variable)
        {
            if (!_Values.ContainsKey(variable))
            {
                var value = Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Machine);
                if (string.IsNullOrEmpty(value))
                {
                    value = Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Process);
                }
                _Values[variable] = value;
            }
            return _Values[variable];
        }
    }
}