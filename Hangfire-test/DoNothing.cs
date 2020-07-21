using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangfire_test
{
    public static class DoNothing
    {
        public static string Nothing(int count)
        {
            return $"Nothing {count}";
        }
    }
}
