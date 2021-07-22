using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TwitterAPIv2.Clients;
using TwitterAPIv2.Core;
using TwitterAPIv2.DTO.HideReplies;
using TwitterAPIv2.Models.HideReplies;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterAPIv2.Services.HideReply
{
    public class HideReplyService
    {
        private OAuthInfo _oAuthInfo;
        private object HideReplyModel;

        public HideReplyService(OAuthInfo oAuth)
        {
            _oAuthInfo = oAuth;
        }

        public HideReplyModel HideReply(string tweetId)
        {
            // ok, this may be overkill for one property
            // but lets keep the same pattern througout for clarity. Twitter may also extend this
            // API in the future

            HideRepliesClient client = new HideRepliesClient(_oAuthInfo);
            // create the json object to send in the body
            HideReplyDTO hideReply = new HideReplyDTO { hidden = true };
            
            string jsonResponse = client.HideReply(tweetId, JsonConvert.SerializeObject(hideReply));
            
            JObject jObject = JObject.Parse(jsonResponse);
            
            HideReplyModel model = new HideReplyModel{ hidden = bool.Parse(jObject["data"]["hidden"].ToString()) };
            
            return model;
        }
    }
}