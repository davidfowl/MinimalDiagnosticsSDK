using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.Extensions.Logging;

namespace Microsoft.ApplicationInsights
{
    internal class Telemetry
    {
        public string Id { get; internal set; }
        public string Name { get; internal set; }
        public IDictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();
        public TelemetryContext Context { get; set; } = new TelemetryContext();

        public class TelemetryContext
        {
            public string InstrumentationKey { get; set; }
            public Operation Operation { get; internal set; } = new Operation();

            public InternalTelemetryContext GetInternalContext()
            {
                return new InternalTelemetryContext();
            }


            public class InternalTelemetryContext
            {
                public string SdkVersion { get; internal set; }
            }
        }

        public class Operation
        {
            public string Id { get; set; }
            public string ParentId { get; set; }
        }
    }

    internal class RequestTelemetry : Telemetry
    {
        public SamplingDecision ProactiveSamplingDecision { get; set; }
        public string Source { get; set; }
        public bool? Success { get; set; }
        public Uri Url { get; set; }
        public string ResponseCode { get; set; }
        public object ItemTypeFlag { get; internal set; }

        internal void Start(long timestamp)
        {
            
        }

        internal void Stop(long timestamp)
        {
        }
    }

    internal class ExceptionTelemetry : Telemetry
    {
        public ExceptionTelemetry(Exception exception)
        {
            Exception = exception;
        }

        public Exception Exception { get; set; }
        public ExceptionHandledAt HandledAt { get; set; }
        public string Message { get; set; }
        public LogLevel SeverityLevel { get; set; }
    }

    internal class TraceTelemetry : Telemetry
    {
        public TraceTelemetry(string message, LogLevel logLevel)
        {
            Message = message;
            LogLevel = logLevel;
        }

        public LogLevel LogLevel { get; }
        public string Message { get; }
    }
}
