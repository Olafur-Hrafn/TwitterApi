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
    [Route("api/user")]
    [Controller]
    public class UsersController : ControllerBase
    {
        private readonly IRepository _repository;
        
        // IoC notað til að ákveða hvaða repo er notað . styllt í startup.cs
        
        public UsersController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetUsers() //GetAllUsers
        {
            try
            {
                List<UserDTO> users = await _repository.GetUsersAsync();
                
                return Ok(users);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            
        }

        [HttpGet]
        [Route("{handle}")]
        public async Task<ActionResult<User>> GetUserByHandle(String handle)
        {
            try
            {
                //  return _repository.GetUserByHandle(handle);

                UserDTO userToReturn = await _repository.GetUserByHandleAsync(handle);
                if (userToReturn == null)
                {
                    return NotFound();
                }
                else
                { 
                    return Ok(userToReturn);
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.CreateUserAsync(user);

                    return CreatedAtAction(nameof(GetUserByHandle), new { handle = user.UserHandle }, user);
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
        [Route("{handle}")]
        public async Task<ActionResult<User>> UpdateUser(String handle, [FromBody] User user)
        {
            try
            {
               User userToUpdate = await _repository.UpdateUserAsync(handle, user);
                if (userToUpdate == null)
                {
                    return NotFound();
                }
                else 
                {
                    return CreatedAtAction(nameof(GetUserByHandle), new { handle = userToUpdate.UserHandle }, userToUpdate);
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {

            try
            {
                bool deleteSuccess = await _repository.DeleteUserAsync(id);

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
