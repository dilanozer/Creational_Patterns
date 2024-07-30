using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;
using Object_Pool_Design_Pattern_CSharp_Example.Classes;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Object_Pool_Design_Pattern_CSharp_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ControllerBase
    {
        readonly ObjectPool<X> _pool;

        public ValueController(ObjectPool<X> pool)
        {
            _pool = pool;
        }

        [HttpGet("[action]")]
        public IActionResult Get1()
        {
            var x1 = _pool.Get();
            x1.Count++;
            _pool.Return(x1);
            return Ok(x1.Count);
        }

        [HttpGet("[action]")]
        public IActionResult Get2()
        {
            var x2 = _pool.Get();
            x2.Count++;
            _pool.Return(x2);
            return Ok(x2.Count);
        }
    }
}

