using AcademyApi.Data;
using AcademyApi.Data.Entities;
using Api.Resources.User;
using AutoMapper;
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

        [HttpGet]
        public IActionResult Get()
        {
            var users = _db.Users.ToList();

            var userResource = _mapper.Map<IEnumerable<UserResource>>(users);

            return Ok(userResource);
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int? id)
        {
            if (id == null) return NotFound();

            User user = _db.Users.FirstOrDefault(x => x.Id == id);

            if (user == null) return NotFound(new { message = "User not found" });

            var userResource = _mapper.Map<UserResource>(user);

            return Ok(userResource);
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginResource login)
        {
            var user = _db.Users.FirstOrDefault(d => d.Email == login.Email);
            
            if (user != null)
            {
                if (CryptoHelper.Crypto.VerifyHashedPassword(user.Password, login.Password))
                {
                    user.Token = CryptoHelper.Crypto.HashPassword(DateTime.Now.ToString());

                    await _db.SaveChangesAsync();

                    var userResource = _mapper.Map<User, UserResource>(user);

                    return Ok(userResource);
                }
            }

            return NotFound(new
            {
                message="Email or password incorrect"
            });
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterResource register)
        {
            if (_db.Users.Any(d => d.Email == register.Email)) return Conflict( new 
            { 
                message="This Email alredy exists"
            });

            var user = _mapper.Map<RegisterResource, User>(register);

            await _db.Users.AddAsync(user);

            await _db.SaveChangesAsync();

            var userResource = _mapper.Map<User, UserResource>(user);

            return Ok(userResource);
        }


        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(int? id, [FromBody] UpdateProfileResource updateProfile)
        {
            if (id == null) return NotFound(new { message = "User not found" });
          
            var dbUser = _db.Users.FirstOrDefault(x => x.Id == id);

            if (updateProfile.Email!=dbUser.Email)
            {
                if (_db.Users.Any(x => x.Email == updateProfile.Email)) return Conflict(new
                {
                    message = "This Email alredy exists"
                });
            }

            dbUser.Email = updateProfile.Email;

            dbUser.Name = updateProfile.Name;

            dbUser.Surname = updateProfile.Surname;

            var userResource = _mapper.Map<User, UserResource>(dbUser);

            await _db.SaveChangesAsync();

            return Ok(userResource);
        }
    }
}