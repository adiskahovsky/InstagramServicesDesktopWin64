using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsLibrary
{
    public static class Randomer
    {
        private static Random _rand;

        static Randomer()
        {
            _rand = new Random();
        }

        public static int Next(int maxValue)
        {
            return _rand.Next(maxValue);
        }
    }
}
