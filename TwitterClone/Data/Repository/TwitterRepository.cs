using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterClone.Models;
using TwitterClone.Models.DTO;

namespace TwitterClone.Data
{
    public class TwitterRepository : IRepository
    {
        private readonly TwitterDbContext _dbContext;

        public TwitterRepository()
        {
            _dbContext = new TwitterDbContext();
        }

        public async Task CreateTweetAsync(Tweet tweet)
        {
            using (var db = _dbContext)
            {
                tweet.DateOfPost = DateTime.Now;
                
                await db.Tweets.AddAsync(tweet);
                await db.SaveChangesAsync();
            }
        }

        public async Task CreateUserAsync(User user)
        {
            using (var db = _dbContext)
            {
                
               await db.Users.AddAsync(user);
                
                await db.SaveChangesAsync();
            }
        }

        public async Task CreateReplyAsync(Reply reply)
        {
            using (var db = _dbContext)
            {
                await db.Replies.AddAsync(reply);
                await db.SaveChangesAsync();
            }
        }

        public async Task<bool> DeleteTweetAsync(int id)
        {
            Tweet tweetToDelete;

            using (var db = _dbContext )
            {
                tweetToDelete = await db.Tweets.FirstOrDefaultAsync(x => x.TweetId == id);

                if (tweetToDelete == null)
                {
                    return false;
                }
                else 
                {
                    db.Tweets.Remove(tweetToDelete);
                  await db.SaveChangesAsync();

                    return true;
                }
            }
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            User userToDelete;

            using (var db = _dbContext)
            {
                userToDelete = await db.Users.FirstOrDefaultAsync(x => x.UserId == id);

                if (userToDelete == null)
                {
                    return false;
                }
                else
                {
                    db.Users.Remove(userToDelete);
                    await db.SaveChangesAsync();

                    return true;
                }
            }
        }

        public async Task<List<TweetDTO>> GetAllTweetsAsync()
        {
          //  Tweet t;
            List<Tweet> tweets;

            using (var db = _dbContext)
            {
                tweets = await db.Tweets.Include(r => r.Replies).Include(u => u.user).ToListAsync();
            }

            List<TweetDTO> listToReturn = new List<TweetDTO>();

            

            foreach (var tweet in tweets)
            {
                TweetDTO tweetToAdd = new TweetDTO();

                tweetToAdd.TweetId = tweet.TweetId;
                tweetToAdd.TweetText = tweet.TweetText;
                tweetToAdd.Replies = tweet.Replies;
                tweetToAdd.DateOfPost = tweet.DateOfPost;
                tweetToAdd.UserHandle = tweet.UserHandle;
                tweetToAdd.UserName = tweet.UserName;
                tweetToAdd.Likes = tweet.Likes;
                tweetToAdd.UserAvatar = tweet.UserAvatar;
                 // tweetToAdd.user = tweet.user;
              

                listToReturn.Add(tweetToAdd);
            }
            return listToReturn;
        }

        public async Task<TweetDTO> GetTweetByIdAsync(int id)
        {
            Tweet t;

            using (var db = _dbContext)
            {
                t = await db.Tweets.Include(r => r.Replies).FirstOrDefaultAsync(x => x.TweetId == id);
            }

            TweetDTO tweetToReturn = new TweetDTO();

            
            List<User> user = new List<User>();

            tweetToReturn.TweetId = t.TweetId;
            tweetToReturn.TweetText = t.TweetText;
          // tweetToReturn.UserId = t.UserId;
            tweetToReturn.Likes = t.Likes;
            tweetToReturn.Replies = t.Replies;
            tweetToReturn.DateOfPost = t.DateOfPost;
            tweetToReturn.UserHandle = t.UserHandle;
            tweetToReturn.UserName = t.UserName;
           
            

            return tweetToReturn;

        }

        public async Task<UserDTO> GetUserByHandleAsync(string handle)
        {
            User u;
            

            using (var db = _dbContext)
            {
                u = await db.Users.Include(u => u.Tweets).FirstOrDefaultAsync(x => x.UserHandle == handle); 
            }

            UserDTO userToReturn = new UserDTO();

            List<TweetDTO> tweetDTO = new List<TweetDTO>();
            List<Reply> reply = new List<Reply>();

            userToReturn.UserId = u.UserId;
            userToReturn.UserName = u.UserName;
            userToReturn.UserHandle = u.UserHandle;
            userToReturn.UserAvatar = u.UserAvatar;
            userToReturn.Tweets = u.Tweets;
            
            

            return userToReturn;

        }

        public async Task<List<UserDTO>> GetUsersAsync()
        {
            List<User> users;
            
            using (var db = _dbContext )
            {
                users = await db.Users.Include(t => t.Tweets).ToListAsync();
            }

            List<UserDTO> userList = new List<UserDTO>();
           

            foreach (User u in users)
            {
                UserDTO userToAdd = new UserDTO();

                userToAdd.UserId = u.UserId;
                userToAdd.UserName = u.UserName;
                userToAdd.UserHandle = u.UserHandle;
                userToAdd.UserAvatar = u.UserAvatar;
                userToAdd.Tweets = u.Tweets;
                

                userList.Add(userToAdd);
            }

            return userList;
        }

        public async Task<List<Reply>> GetAllRepliesAsync()
        {

            using var db = _dbContext ;
            
            return await db.Replies.ToListAsync();
        }


        public async Task<Tweet> UpdateTweetAsync(int id, Tweet tweet)
        {

            Tweet tweetToUpdate;
            using (var db = _dbContext)
            {
                tweetToUpdate = await db.Tweets.FirstOrDefaultAsync(x => x.TweetId == id);
                if (tweetToUpdate == null)
                {
                    return null;
                }

                tweetToUpdate.TweetText = tweet.TweetText;
                tweetToUpdate.Likes = tweet.Likes;
                

                await db.SaveChangesAsync();

                return tweetToUpdate;

            };
        }

        public async Task<User> UpdateUserAsync(String handle, User user)
        {
            User userToUpdate;
            using (var db = _dbContext)
            {
                userToUpdate = await db.Users.FirstOrDefaultAsync(x => x.UserHandle == handle);
                if (userToUpdate == null)
                {
                    return null;
                }

                userToUpdate.UserName = user.UserName;
                userToUpdate.UserHandle = user.UserHandle;
                userToUpdate.UserAvatar = user.UserAvatar;

                await db.SaveChangesAsync();

                return userToUpdate;

            };
        }
    }
}
