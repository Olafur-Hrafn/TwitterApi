using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TwitterClone.Models
{
    public class User
    {
        public User()
        {
            Tweets = new List<Tweet>();
        }
        
        public int UserId { get; set; }

        [Required]
        [MaxLength(30)]
        public String UserName { get; set; }

        [Required]
        [MaxLength(15)]
        public String UserHandle { get; set; }

        public String UserAvatar { get; set; }

        public List<Tweet> Tweets { get; set; }
    }
}
