using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Model;
using ProductMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;
using System.Linq;
using UserMicroservice.Models;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public int pageSize = 3;
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository productRepository)
        {
            _userRepository = productRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = _userRepository.GetUsers();
            return new OkObjectResult(users);
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userRepository.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _userRepository.InsertUserAsync(user);
            }
            catch (Exception exp)
            {
                return BadRequest(exp);
            }
            return NoContent();
        }

        /// <summary>
        /// UpdateUser
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _userRepository.UpdateUserAsync(user);
            }
            catch (Exception exp)
            {
                return BadRequest(exp);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _userRepository.DeleteUserAsync(id);
            }
            catch (Exception exp)
            {
                return BadRequest(exp);
            }

            return NoContent();
        }

        [HttpGet]
        [Route("users")]
        public IActionResult GetUsers(int page = 1, int range = 10)
        {
            UserListViewModel model = new UserListViewModel
        {
            Users = _userRepository.GetUsers().OrderBy(user => user.UserId)
            .Skip((page - 1) * range)
            .Take(range),
            PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = range,
                TotalElements = _userRepository.GetUsers().Count()
            }
            };
            return new OkObjectResult(model);
        }
    }
}