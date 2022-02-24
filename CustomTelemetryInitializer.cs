using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInsightsWebJob
{
    // This is how we Initialize the Telemetry. We need this class and to make it available to the solution.
    // We can cutomize this to help us better refine our data.
    class CustomTelemetryInitializer : ITelemetryInitializer
    {
        public void Initialize(ITelemetry telemetry)
        {
            // Do something with telemetry here.
        }
    }
}
