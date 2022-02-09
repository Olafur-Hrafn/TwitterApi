using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterClone.Data;
using TwitterClone.Models;
using TwitterClone.Models.DTO;

namespace TwitterClone.Controllers
{
    [Route("api/Tweet")]
    [Controller]

    public class TweetController : ControllerBase
    {
        private readonly IRepository _repository;

        // IoC notað til að ákveða hvaða repo er notað . styllt í startup.cs
        public TweetController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TweetDTO>>> GetAllTweets()
        {
            try
            {
                List<TweetDTO> tweets = await _repository.GetAllTweetsAsync();
                return Ok(tweets);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Tweet>> GetTweetById(int id)
        {
            try
            {
                TweetDTO tweet = await _repository.GetTweetByIdAsync(id);

                if (tweet == null)
                {
                    return NotFound();
                }
                else
                { 
                    return Ok(tweet);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpPost]
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


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTweet(int id, [FromBody] Tweet tweet)
        {
            try
            {
                Tweet updatedTweet = await _repository.UpdateTweetAsync(id, tweet);

                if (updatedTweet == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(GetTweetById), new { id = updatedTweet.TweetId }, updatedTweet);

                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<User>> DeleteTweet(int id)
        {

            try
            {
                bool deleteSuccess = await _repository.DeleteTweetAsync(id);

                if (!deleteSuccess)
                {
                    return NotFound();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }
    }
}
