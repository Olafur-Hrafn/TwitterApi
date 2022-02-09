using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwitterClone.Models.DTO
{
    public class UserDTO
    {
        public UserDTO()
        {
            Tweets = new List<Tweet>();
        }

            public int UserId { get; set; }

            
            public String UserName { get; set; }

            public String UserHandle { get; set; }

            public String UserAvatar { get; set; }

            public List<Tweet> Tweets { get; set; }
        }
    }


