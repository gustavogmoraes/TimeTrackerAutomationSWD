using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TimeTrackerAutomationSWD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeTrackingController : Controller
    {
        [HttpPost("[action]")]
        public void EnterTime([FromBody] List<Entry> entries)
        {
            Runner.Enter(entries);
        }
        
        [HttpPost("[action]")]
        public void Login([FromBody] Credentials credentials)
        {
            Runner.Login(credentials);
        }
    }
}