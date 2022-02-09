using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterClone.Models;
using TwitterClone.Models.DTO;

namespace TwitterClone.Data
{
    public class MockRepository : IRepository
    {

        List<UserDTO> Users =  new List<UserDTO>
            {
                new UserDTO() { UserId = 1, UserAvatar = "www.glala.net", UserHandle = "@gamli", UserName = "ólafur hrafn"  },
                new UserDTO() { UserId = 2, UserAvatar = "www.google.net", UserHandle = "@SiggaMegaBabe", UserName = "Sigrún Björgvinsdóttir"  },
                new UserDTO() { UserId = 3, UserAvatar = "www.twitter.bla", UserHandle = "@Arían", UserName = "Aría ósk ólafssdóttir"  }
            };

        List<TweetDTO> Tweets = new List<TweetDTO>
        {
            new TweetDTO() { UserId = 1, TweetId = 1, Likes = 0, RetweetId = 0, TweetText = "Hvað er málið með twitter maður",},
            new TweetDTO() { UserId = 2, TweetId = 2, Likes = 2, RetweetId = 0, TweetText = "Hver er ég ? "},
            new TweetDTO() { UserId = 3, TweetId = 3, Likes = 0, RetweetId = 0, TweetText = "facebook betra ? "},
            new TweetDTO() { UserId = 3, TweetId = 4, Likes = 1, RetweetId = 0, TweetText = "ná mér í monster..."},

        };

    public MockRepository()
        {


        }

        public Task<List<UserDTO>> GetUsersAsync()
        {
            return null;
        }

        public async Task<UserDTO> GetUserByHandleAsync(String handle)
        {
            return Users.FirstOrDefault(x => x.UserHandle == handle);
        }

        public Task<List<TweetDTO>> GetAllTweetsAsync()
        {
            return null;
        }

        public async Task<TweetDTO> GetTweetByIdAsync(int id)
        {
            return Tweets.FirstOrDefault(x => x.TweetId == id);
        }

        public Task CreateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task CreateTweetAsync(Tweet tweet)
        {
            throw new NotImplementedException();
        }

        public Task<Tweet> UpdateTweetAsync(int id, Tweet tweet)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUserAsync(String handle, User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTweetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Reply>> GetAllRepliesAsync()
        {
            throw new NotImplementedException();
        }

        public Task CreateReplyAsync(Reply reply)
        {
            throw new NotImplementedException();
        }
    }
}
