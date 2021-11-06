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
    public class AccountController : Controller
    {
        private DataContext db;

        public AccountController(DataContext db)
        {
            this.db = db;
        }

        
    }
}
