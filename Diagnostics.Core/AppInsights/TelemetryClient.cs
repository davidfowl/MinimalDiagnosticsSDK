using System;

namespace Microsoft.ApplicationInsights
{
    internal class TelemetryClient
    {
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
    }
}
