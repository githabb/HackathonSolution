using Microsoft.AspNetCore.Mvc;
using Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace Services.Controllers
{
    [Route("users")]
    [ApiController]
    public class UsersVideosPathsController : ControllerBase
    {
        [HttpGet("{userId}/videos/{videoId}/paths")]
        public IEnumerable<PathPriorityModel> Get(int userId, int videoId, SortingOrder? priority)
        {
            var result = new List<PathPriorityModel>();
            result.Add(new PathPriorityModel() { path = "users/5/videos/7", priority = Priorities.low });
            result.Add(new PathPriorityModel() { path = "users/5/flows/4/videos/7", priority = Priorities.medium });
            result.Add(new PathPriorityModel() { path = "users/5/flows/9/videos/7", priority = Priorities.critical });
            result.Add(new PathPriorityModel() { path = "users/5/groups/5/flows/4/videos/7", priority = Priorities.high });

            if (priority == SortingOrder.asc)
            {
                result = result.OrderBy(x => x.priority).ToList<PathPriorityModel>();
            }
            else
            {
                result = result.OrderByDescending(x => x.priority).ToList<PathPriorityModel>();
            }
                
            return result;
        }
    }
}
