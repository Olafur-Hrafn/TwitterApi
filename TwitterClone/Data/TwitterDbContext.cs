using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterClone.Models;

namespace TwitterClone.Data
{
    public class TwitterDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<Reply> Replies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TwitterDb");
  
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Reply>()
              .HasOne(x => x.tweet)
              .WithMany(x => x.Replies)
              .OnDelete(DeleteBehavior.Restrict);
        }
           
        public static void SeedDb()
        {
            User user1 = new User()
            {
                UserName = "olafur hrafn",
                UserHandle = "@olinn",
                UserAvatar = "https://avatarfiles.alphacoders.com/184/thumb-1920-184497.jpg"
            };
            User user2 = new User()
            {
                UserName = "Elon musk",
                UserHandle = "@Elon",
                UserAvatar = "https://ih1.redbubble.net/image.679676926.0169/flat,128x128,075,t.jpg"
            };
            User user3 = new User()
            {
                UserName = "Rick Sanchez",
                UserHandle = "@wabbadabba",
                UserAvatar = "https://icon-library.com/images/rick-sanchez-icon/rick-sanchez-icon-24.jpg"
            };
            User user4 = new User()
            {
                UserName = "Trump",
                UserHandle = "@winning",
                UserAvatar = "https://ih1.redbubble.net/image.175911021.4459/flat,128x128,075,t-pad,128x128,f8f8f8.jpg"
            };
            Tweet tweet1 = new Tweet()
            {
                TweetText = "Gleymdi að gera Seed fall...",
                Likes = 2,
                DateOfPost = DateTime.Now,
                user = user1,
                UserHandle = user1.UserHandle,
                UserName = user1.UserName,
                UserAvatar = user1.UserAvatar
            };
            Tweet tweet2 = new Tweet()
            {
                TweetText = "mars boyyyy",
                Likes = 4,
                DateOfPost = DateTime.Now,
                user = user2,
                UserHandle = user2.UserHandle,
                UserName = user2.UserName,
                UserAvatar = user2.UserAvatar
            };
            Tweet tweet3 = new Tweet()
            {
                TweetText = "smoke  boyyyy",
                Likes = 5,
                DateOfPost = DateTime.Now,
                user = user2,
                UserHandle = user2.UserHandle,
                UserName = user2.UserName,
                UserAvatar = user2.UserAvatar
            };
            Tweet tweet4 = new Tweet()
            {
                TweetText = "Wubba Lubba Dub-Dub",
                Likes = 10,
                DateOfPost = DateTime.Now,
                user = user3,
                UserHandle = user3.UserHandle,
                UserName = user3.UserName,
                UserAvatar = user3.UserAvatar
            };
            Tweet tweet5 = new Tweet()
            {
                TweetText = "“Boom! Big reveal! I turned myself into a pickle!”",
                Likes = 5,
                DateOfPost = DateTime.Now,
                user = user3,
                UserHandle = user3.UserHandle,
                UserName = user3.UserName,
                UserAvatar = user3.UserAvatar
            };
            Tweet tweet6 = new Tweet()
            {
                TweetText = "Why would Kim Jong-un insult me by calling me old, when I would never call him short and fat? Oh well, I try so hard to be his friend and maybe someday that will happen.",
                Likes = 19,
                DateOfPost = DateTime.Now,
                user = user4,
                UserHandle = user4.UserHandle,
                UserName = user4.UserName,
                UserAvatar = user4.UserAvatar
            };
            Reply reply1 = new Reply()
            { 
                ReplyContent = "Come on, be great again",
                tweet = tweet1,
                UserId = 4
            };
            Reply reply2 = new Reply()
            {
                ReplyContent = "im traveling through galaxy´s and this clown is still trying to get to mars",
                tweet = tweet2,
                UserId = 3
            };
            Reply reply3 = new Reply()
            {
                ReplyContent = "hey Rick. stay out of my way",
                tweet = tweet2,
                UserId = 2
            };
            Reply reply4 = new Reply()
            {
                ReplyContent = "Kim be crazy tho..",
                tweet = tweet6,
                UserId = 2
            };

            using (var db = new TwitterDbContext())
            {
                db.Database.EnsureCreated();

                User user = db.Users.FirstOrDefault(x => x.UserId > 0);

                if (user == null)
                {
                    db.Add(user1);
                    db.Add(user2);
                    db.Add(user3);
                    db.Add(user4);
                    db.Add(tweet1);
                    db.Add(tweet2);
                    db.Add(tweet3);
                    db.Add(tweet4);
                    db.Add(tweet5);
                    db.Add(tweet6);
                    db.Add(reply1);
                    db.Add(reply2);
                    db.Add(reply3);
                    db.Add(reply4);


                    db.SaveChanges();
                }
                  
            }
        }

    }
}
