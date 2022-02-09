using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterClone.Models;
using TwitterClone.Models.DTO;

namespace TwitterClone.Data
{
    public interface IRepository
    {
        Task<List<UserDTO>> GetUsersAsync();
        Task<UserDTO> GetUserByHandleAsync(String handle);
        Task<List<TweetDTO>> GetAllTweetsAsync();
        Task<TweetDTO> GetTweetByIdAsync(int id);
        Task<List<Reply>>GetAllRepliesAsync();
        Task CreateReplyAsync(Reply reply);
        Task CreateUserAsync(User user);
        Task CreateTweetAsync(Tweet tweet);
        Task<Tweet> UpdateTweetAsync(int id, Tweet tweet);
        Task<User> UpdateUserAsync(String handle, User user);
        Task<bool> DeleteUserAsync(int id);
        Task<bool> DeleteTweetAsync(int id);
    }
}
