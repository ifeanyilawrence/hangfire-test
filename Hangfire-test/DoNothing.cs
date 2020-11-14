using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;

namespace Hangfire_test
{
    public static class DoNothing
    {
        //[ExecuteOnce]
        public static string Nothing(int count)
        {
            return $"Nothing {count}";
        }
    }
}
