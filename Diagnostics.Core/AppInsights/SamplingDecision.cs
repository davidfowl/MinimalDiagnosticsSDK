namespace Microsoft.ApplicationInsights.DataContracts
{
    public enum SamplingDecision
    {
        /// <summary>
        /// Sampling decision has not been made.
        /// </summary>
        None = 0,

        /// <summary>
        /// Item is sampled in. This may change as item flows through the pipeline.
        /// </summary>
        SampledIn = 1,

        /// <summary>
        /// Item is sampled out. This may not change.
        /// </summary>
        SampledOut = 2,
    }
}
