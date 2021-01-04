using AcademyApi.Data;
using AcademyApi.Data.Entities;
using Api.Resources.User;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly ApiDbContext _db;
        private readonly IMapper _mapper;
        public UserController(ApiDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        //[Route("users")]
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _db.Users;
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login()
        {
            return Ok("user/login");
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterResource register)
        {
            var user = new User
            {
                Name = register.Name,
                Surname = register.Surname,
                Email = register.Email,
                Password = CryptoHelper.Crypto.HashPassword(register.Password),
                Token = CryptoHelper.Crypto.HashPassword(DateTime.Now.ToString()),
                AddedDate=DateTime.Now,
                AddedBy = "System"
            };
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            var userResource = _mapper.Map<User, UserResource>(user);
            return Ok(userResource);
        }
    }
}