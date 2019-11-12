using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ApplicationInsights.Extensibility;

namespace Diagnostics.Core.AppInsights
{
    public class ApplicationIdProvider : IApplicationIdProvider
    {
        public bool TryGetApplicationId(string instrumentationKey, out string applicationId)
        {
            throw new NotImplementedException();
        }
    }
}
