using System.Collections.Generic;
using Microsoft.ApplicationInsights.AspNetCore.DiagnosticListeners.Implementation;

namespace System.Diagnostics
{
    internal struct ActivityShim
    {
        private Activity _activity;

        // It's OK these are static since they are based on the Activity type
        private static readonly PropertyFetcher idFormatProperty = new PropertyFetcher("IdFormat");
        private static readonly PropertyFetcher traceStateStringProperty = new PropertyFetcher("TraceStateString");
        private static readonly PropertyFetcher recordedProperty = new PropertyFetcher("Recorded");

        public ActivityShim(Activity activity)
        {
            _activity = activity;
        }

        public ActivityShim(string operationName) : this(new Activity(operationName))
        {

        }

        public static ActivityShim Current => new ActivityShim(Activity.Current);

        public string ParentId => _activity.ParentId;

        public ActivityIdFormat IdFormat
        {
            get
            {
                var obj = idFormatProperty.Fetch(_activity);
                return obj == null ? ActivityIdFormat.Hierarchical : (ActivityIdFormat)(int)obj;
            }
        }

        public IEnumerable<KeyValuePair<string, string>> Baggage => _activity.Baggage;

        public string TraceStateString
        {
            get => (string)traceStateStringProperty.Fetch(_activity);
            set
            {
                // TODO: Set property on Activity
            }
        }

        public bool Recorded
        {
            get
            {
                var recorded = recordedProperty.Fetch(_activity);
                return recorded == null ? false : (bool)recorded;
            }
        }

        public string Id => _activity.Id;

        public string RootId => _activity.RootId;

        public ActivityTraceId TraceId => default;

        public ActivitySpanId SpanId => default;

        public ActivitySpanId ParentSpanId => default;

        public static ActivityIdFormat DefaultIdFormat => ActivityIdFormat.Hierarchical;

        public bool IsDefault => _activity == null;

        public void SetParentId(string parentId) => _activity.SetParentId(parentId);

        public void Start() => _activity.Start();

        public void AddBaggage(string key, string value) => _activity.AddBaggage(key, value);

        public void SetParentId(string traceId, ActivitySpanId activitySpanId, ActivityTraceFlags flags)
        {
        }
    }

    internal struct ActivityTraceId
    {
        public static string CreateFromString(ReadOnlySpan<char> traceId)
        {
            return null;
        }

        internal string ToHexString()
        {
            return null;
        }
    }

    internal struct ActivitySpanId
    {
        public bool IsDefault => true;

        internal string ToHexString()
        {
            return null;
        }
    }

    internal enum ActivityIdFormat
    {
        Unknown = 0,      // ID format is not known.
        Hierarchical = 1, //|XXXX.XX.X_X ... see https://github.com/dotnet/corefx/blob/master/src/System.Diagnostics.DiagnosticSource/src/ActivityUserGuide.md#id-format
        W3C = 2,          // 00-XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX-XXXXXXXXXXXXXXXX-XX see https://w3c.github.io/trace-context/
    }

    [Flags]
    public enum ActivityTraceFlags
    {
        None = 0b_0_0000000,
        Recorded = 0b_0_0000001, // The Activity (or more likley its parents) has been marked as useful to record
    }
}
