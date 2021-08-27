using Microsoft.AspNetCore.Http;
using MaheApi.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nancy.Json;

namespace CoreApiDemoCall.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        public List<string> StateIndex()
        {
            var responseString = ApiCall.GetApi("https://localhost:44316/Web");
            var rootobject = new JavaScriptSerializer().Deserialize<List<string>>(responseString);
            return rootobject;
        }

    }
}
