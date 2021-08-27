using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiDemo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WebController : ControllerBase
    {
        private static List<string> studentsname = new List<string> { "Abu", "Little", "John", "Tommy" };

       
        public IEnumerable<string> GetNames()
        {
            return studentsname;
        }
       
    }
}
