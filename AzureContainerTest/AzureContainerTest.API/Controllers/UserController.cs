using AzureContainerTest.API.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureContainerTest.API.Entities;

namespace AzureContainerTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public UserController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _dataAccessProvider.GetUserRecords();
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                user.Id = obj.ToString();
                _dataAccessProvider.AddUserRecord(user);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public User Details(string id)
        {
            return _dataAccessProvider.GetUserSingleRecord(id);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateUserRecord(user);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(string id)
        {
            var data = _dataAccessProvider.GetUserSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeleteUserRecord(id);
            return Ok();
        }
    }
}
