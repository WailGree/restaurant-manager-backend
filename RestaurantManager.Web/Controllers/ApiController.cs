using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFDataAccess.DataAccess;
using EFDataAccess.Models;
using RecipesAPI.Models;

namespace RestaurantManager.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly RestaurantContext _context;
        private readonly SQLMenuRepository _menu;
        private readonly SQLUserRepository _users;
        private SQLUserRepository _sqlUserHandler;

        public ApiController(RestaurantContext context)
        {
            _context = context;
            _sqlUserHandler = new SQLUserRepository(context);
        }


        [HttpPost("registration")]
        public IActionResult Registration(RegistrationCredentials registrationCred)
        {
            User regUser = _sqlUserHandler.GetUser(registrationCred.UserName);
            bool isLoginningUserEmailTaken = _sqlUserHandler.GetUsers().Any(x => x.Email == registrationCred.Email);
            if (regUser != null || isLoginningUserEmailTaken)
            {
                return BadRequest("username or email already taken");
            }

            User user = new User(registrationCred.UserName, registrationCred.Email, registrationCred.Password); // we should validate the password as well if it strong enough
            _sqlUserHandler.AddUser(user);
            return Ok("successful registration");
        }

        [HttpPost("login")]
        public IActionResult Login(LoginCredential userCred)
        {
            User loginningUser = _sqlUserHandler.GetUser(userCred.Username);
            if (loginningUser == null)
            {
                return BadRequest();
            }

            if (loginningUser.IsValidPassword(userCred.Password))
            {
                string token = _sqlUserHandler.GenerateTokenForUser(userCred.Username);
                return Ok(token);
            }

            return BadRequest();
        }



    }
}
