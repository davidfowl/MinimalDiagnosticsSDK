using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ApplicationInsights.DataContracts;

namespace Microsoft.ApplicationInsights
{
    internal class Telemetry
    {
        public string Id { get; internal set; }
        public string Name { get; internal set; }
        public IDictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();
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
        private Exception exception;

        public ExceptionTelemetry(Exception exception)
        {
            this.exception = exception;
        }

        public ExceptionHandledAt HandledAt { get; set; }
    }
}
