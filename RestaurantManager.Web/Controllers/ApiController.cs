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
        private SQLMenuRepository _sqlMenuHandler;

        public ApiController(RestaurantContext context)
        {
            _context = context;
            _sqlUserHandler = new SQLUserRepository(context);
            _sqlMenuHandler = new SQLMenuRepository(context);
        }


        [HttpPost("registration")]
        public IActionResult Registration(RegistrationCredentials registrationCred)
        {
            User regUser = _sqlUserHandler.GetUser(registrationCred.Username);
            bool isLoginningUserEmailTaken = _sqlUserHandler.GetUsers().Any(x => x.Email == registrationCred.Email);
            if (regUser != null || isLoginningUserEmailTaken)
            {
                return BadRequest("username or email already taken");
            }

            User user = new User(registrationCred.Username, registrationCred.Email, registrationCred.Password); // we should validate the password as well if it strong enough
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

        [HttpPost("logout")]
        public IActionResult Logout(AuthenticationCredential authentication)
        {
            User user = _sqlUserHandler.GetUser(authentication.Username);
            if (user == null)
            {
                return BadRequest();
            }

            if (user.IsValidToken(authentication.Token))
            {
                _sqlUserHandler.DeleteUserToken(authentication.Username);
                return Ok("successfully logged out");
            }

            return BadRequest();
        }

        [HttpDelete("delete")]
        public IActionResult DeleteUser(LoginCredential userCred)
        {
            User loginningUser = _sqlUserHandler.GetUser(userCred.Username);
            if (loginningUser == null)
            {
                return BadRequest();
            }

            if (loginningUser.IsValidPassword(userCred.Password))
            {
                _sqlUserHandler.DeleteUser(userCred.Username);
                return Ok("user successfully deleted");
            }

            return BadRequest();
        }

        [HttpGet("menu")]
        public IEnumerable<MenuItem> GetMenu()
        {
            return _sqlMenuHandler.GetMenu();
        }

        [HttpGet("menu-item")]
        public MenuItem GetMenuItem(int id)
        {
            return _sqlMenuHandler.getMenuItem(id);
        }

        [HttpDelete("delete-menu-item")]
        public MenuItem DeleteMenuItem(int id)
        {
            return _sqlMenuHandler.DeleteMenuItem(id);
        }

    }
}
