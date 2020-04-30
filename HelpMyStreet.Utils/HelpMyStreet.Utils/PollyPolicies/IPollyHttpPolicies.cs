using Polly.Retry;
using Polly.Wrap;
using System.Net.Http;

namespace HelpMyStreet.Utils.PollyPolicies
{
    /// <summary>
    /// HTTP retry policies. This has a dependency on IPollyHttpPoliciesConfig so it must be registered in the DI (PollyHttpPoliciesConfig is an implementation).
    /// </summary>
    public interface IPollyHttpPolicies
    {
        /// <summary>
        /// Retries on 408 and 5XX errors.  503 errors have a different config for the pause between retires to allow time for the Azure Function to start up.
        /// </summary>
        AsyncPolicyWrap<HttpResponseMessage> InternalHttpRetryPolicy { get; }

        /// <summary>
        /// Retries on 408 and 5XX errors.
        /// </summary>
        AsyncRetryPolicy<HttpResponseMessage> ExternalHttpRetryPolicy { get; }
    }
}