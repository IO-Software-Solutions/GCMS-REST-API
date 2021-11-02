using Microsoft.AspNetCore.Mvc;
using Rest_Api.Models;
using Rest_Api.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest_Api.Controllers
{
    [ApiKey]
    [ApiController]
    [Route("api")]
    public class UserController : Controller
    {
        private DataContext db;

        public UserController(DataContext db)
        {
            this.db = db;
        }

        [HttpGet("role/get/id/{id}")]
        public IActionResult GetRoleById(int id)
        {
            var role = db.Roles.Find(id);

            if(role != null)
            {
                return Ok(role);
            }

            return NotFound("Role Not Found");
        }

        [HttpPost("role/create")]
        public IActionResult CreateRole([FromBody] Role role)
        {
            try
            {
                db.Roles.Add(role);
                db.SaveChanges();
                return Ok("Role Created Successfully");
            }
            catch (Exception)
            {
                return NotFound("Error, Could Not Create Role");
            }
        }
    }
}
