using System;

namespace Microsoft.ApplicationInsights
{
    internal class TelemetryClient
    {
        private TelemetryConfiguration value;

        public TelemetryClient()
        {

        }

        public TelemetryClient(TelemetryConfiguration value)
        {
            this.value = value;
        }

        internal bool IsEnabled() => true;

        internal void InitializeInstrumentationKey(RequestTelemetry requestTelemetry)
        {
            
        }

        internal void TrackRequest(RequestTelemetry telemetry)
        {
        }

        internal void Track(ExceptionTelemetry exceptionTelemetry)
        {
        }

        internal void TrackException(ExceptionTelemetry exceptionTelemetry)
        {
            
        }

        internal void TrackTrace(TraceTelemetry traceTelemetry)
        {
        }
    }
}
