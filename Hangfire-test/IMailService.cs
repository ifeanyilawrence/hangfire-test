using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangfire_test
{
    public interface IMailService
    {
        Task SendPeriodicMail();
    }
}
