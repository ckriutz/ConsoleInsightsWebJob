using Microsoft.ApplicationInsights.Channel;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInsightsWebJob
{
    public class SimpleService
    {
        // Here is our "Run" Method where everything starts. Here in the trigger, we define how often this will fire.
        // We can, from here do anything else.
        public void Run([TimerTrigger("*/30 * * * * *", RunOnStartup = false)] TimerInfo timerInfo, ILogger log)
        {
            log.LogInformation("Application starting!");
            var id = Nanoid.Nanoid.Generate(size: 10);
            DoWork(id, log);
            log.LogInformation("Application has finished!");
        }
        
        public void DoWork(string id, ILogger log)
        {
            Random random = new Random();
            var success = random.Next(0, 10);
            if (success < 8)
            {
                // ✅ Success! Let's just write this out as a trace.
                var workobj = new WorkObject() { Id = id, Word = Words.GenerateName(), IsSuccess = true };
                log.LogDebug("WorkObject {0} was successful.", workobj.Id);
            }
            else
            {
                // 🚫 Fail. In this case, we are going to use the "ExceptionTelementry" Object.
                var workobj = new WorkObject() { Id = id, Word = Words.GenerateName(), IsSuccess = false };
                log.LogError(String.Format("WorkObject {0} FAILED.", workobj.Id));
            }
        }
    }
}
