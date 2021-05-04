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

        public ApiController(RestaurantContext context)
        {
            _context = context;
        }


        [HttpGet()]
        public string GetFavoriteRecipes()
        {
            return "data";
        }



    }
}
