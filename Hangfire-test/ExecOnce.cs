using Hangfire.Client;
using Hangfire.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Hangfire_test
{
    public class ExecuteOnceAttribute : JobFilterAttribute, IClientFilter
    {
        public void OnCreating(CreatingContext filterContext)
        {
            var entries = filterContext.Connection.GetAllEntriesFromHash(GetJobKey(filterContext.Job));
            if (entries != null && entries.ContainsKey("jobId"))
            {
                // this job was already created once, cancel creation
                filterContext.Canceled = true;
            }
        }

        public void OnCreated(CreatedContext filterContext)
        {
            if (!filterContext.Canceled)
            {
                // job created, mark it as such
                filterContext.Connection.SetRangeInHash(GetJobKey(filterContext.Job),
                    new[] { new KeyValuePair<string, string>("jobId", filterContext.BackgroundJob.Id) });
            }
        }

        private static string GetJobKey(Job job)
        {
            using (var sha256 = SHA256.Create())
            {
                return "execute-once:" + Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(job.ToString())));
            }

            //using (var sha512 = SHA512.Create())
            //{
            //    return Convert.ToBase64String(sha512.ComputeHash(Encoding.UTF8.GetBytes("execute-once:" + JsonConvert.SerializeObject(job))));
            //}
        }
    }
}
