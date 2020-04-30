using Polly;
using Polly.Retry;
using Polly.Wrap;
using System.Net;
using System.Net.Http;

namespace HelpMyStreet.Utils.PollyPolicies
{
    /// <inheritdoc />>
    public class PollyHttpPolicies : IPollyHttpPolicies
    {
        /// <inheritdoc />>
        public AsyncPolicyWrap<HttpResponseMessage> InternalHttpRetryPolicy { get; }

        /// <inheritdoc />>
        public AsyncRetryPolicy<HttpResponseMessage> ExternalHttpRetryPolicy { get; }

        public PollyHttpPolicies(IPollyHttpPoliciesConfig pollyHttpPoliciesConfig)
        {
            AsyncRetryPolicy<HttpResponseMessage> otherHttpRetryPolicy = Policy
                .HandleResult<HttpResponseMessage>(message => message.StatusCode != HttpStatusCode.ServiceUnavailable && (message.StatusCode == HttpStatusCode.RequestTimeout || ((int)message.StatusCode >= 500 && (int)message.StatusCode < 600))) // HTTP errors that don't indicate that Azure Function not running
                .WaitAndRetryAsync(pollyHttpPoliciesConfig.ServiceErrorPauses);

            AsyncRetryPolicy<HttpResponseMessage> azureFunctionHttpsRetryPolicy = Policy
                .HandleResult<HttpResponseMessage>(message => message.StatusCode == HttpStatusCode.ServiceUnavailable) // HTTP error that indicates Azure Function not running
                .WaitAndRetryAsync(pollyHttpPoliciesConfig.AzureFunctionNotStartedPauses);

            InternalHttpRetryPolicy = Policy.WrapAsync(otherHttpRetryPolicy, azureFunctionHttpsRetryPolicy);
            
            ExternalHttpRetryPolicy = Policy
                .HandleResult<HttpResponseMessage>(message => message.StatusCode == HttpStatusCode.RequestTimeout || ((int)message.StatusCode >= 500 && (int)message.StatusCode < 600))
                .WaitAndRetryAsync(pollyHttpPoliciesConfig.ServiceErrorPauses);
        }
    }
}
