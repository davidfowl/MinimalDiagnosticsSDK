
namespace Microsoft.ApplicationInsights.AspNetCore.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Represents the runtime version of AspNetCore.
    /// </summary>
    internal enum AspNetCoreMajorVersion
    {
        /// <summary>
        /// .NET Core Version 1.0
        /// </summary>
        One = 1,

        /// <summary>
        /// .NET Core Version 2.0
        /// </summary>
        Two = 2,

        /// <summary>
        /// .NET Core Version 3.0
        /// </summary>
        Three = 3
    }
}
