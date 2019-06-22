using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Listener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListenController : ControllerBase
    {

        // POST api/listen
        [HttpPost]
        public void Post()
        {
            using (StreamReader stream = new StreamReader(HttpContext.Request.Body))
            {
                string body = stream.ReadToEnd();
                Console.WriteLine(body);
            }
        }
    }
}