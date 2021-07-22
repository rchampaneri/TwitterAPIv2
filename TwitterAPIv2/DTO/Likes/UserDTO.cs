using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterAPIv2.DTO.Likes
{

    public class UserDTO
    {
        public List<DTO.Likes.User> data { get; set; }
        public Meta meta { get; set; }
    }

}
