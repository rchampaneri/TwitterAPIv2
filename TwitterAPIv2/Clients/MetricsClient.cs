using Newtonsoft.Json;
using TwitterAPIv2.Core;
using TwitterAPIv2.DTO.TweetMetrics;
using TwitterAPIv2.Models.TweetMetrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterAPIv2.Clients
{
    public class MetricsClient
    {
        private string _privateEndpoint = "https://api.twitter.com/labs/1/tweets/metrics/private";
        private OAuthInfo _oAuthInfo;

        public MetricsClient(OAuthInfo oAuthInfo)
        {
            _oAuthInfo = oAuthInfo;
        }

        public string GetTweetMetrics(List<string> tweetIds)
        {
            RequestBuilder rb = new RequestBuilder(_oAuthInfo, "GET", _privateEndpoint);

            rb.AddParameter("ids", string.Join(",", tweetIds));

            string result = rb.Execute();

            return result;
        }

    }
}
