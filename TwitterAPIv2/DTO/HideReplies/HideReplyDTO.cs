using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterAPIv2.DTO.HideReplies
{
    public class HideReplyDTO
    {
        [JsonProperty("hidden")]
        public bool hidden { get; set; }
    }
}
