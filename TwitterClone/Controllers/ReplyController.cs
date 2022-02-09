using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterClone.Data;
using TwitterClone.Models;

namespace TwitterClone.Controllers
{
    [Route("api/Replies")]
    [Controller]
    public class ReplyController : ControllerBase
    {
        private readonly IRepository _repository;

        // IoC notað til að ákveða hvaða repo er notað . styllt í startup.cs
        public ReplyController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Reply>>> GetAllReplies()
            {
                try
                {
                    return Ok(await _repository.GetAllRepliesAsync());
                }
                catch (Exception)
                {   
                    return StatusCode(500);
                }
            }

        [HttpPost]
        public async Task<IActionResult> CreateReply([FromBody] Reply reply)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.CreateReplyAsync(reply);
                    return CreatedAtAction(nameof(GetAllReplies), new { id = reply.Id }, reply);
                }
                else
                {
                    return BadRequest();

                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
        /*
         * 
         * [HttpPost]
        public async Task<IActionResult> CreateTweet([FromBody] Tweet tweet)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.CreateTweetAsync(tweet);

                    return CreatedAtAction(nameof(GetTweetById), new { id = tweet.TweetId }, tweet);

                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }
         
         */
    }
}
