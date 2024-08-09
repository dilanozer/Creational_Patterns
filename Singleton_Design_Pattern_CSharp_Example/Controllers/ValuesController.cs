using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Singleton_Design_Pattern_CSharp_Example.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Singleton_Design_Pattern_CSharp_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult X()
        {
            DatabaseService databaseService = DatabaseService.GetInstance;
            databaseService.Connection();
            databaseService.Disconnect();
            return Ok(databaseService);
        }

        [HttpGet("[action]")]
        public IActionResult Y()
        {
            DatabaseService databaseService = DatabaseService.GetInstance;
            databaseService.Connection();
            databaseService.Disconnect();
            return Ok(databaseService);
        }
    }
}

