using Microsoft.AspNetCore.Mvc;
using Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace Services.Controllers
{
    [Route("users")]
    [ApiController]
    public class UsersVideosController : ControllerBase
    {
        [HttpGet("{userId}/videos")]
        public IEnumerable<VideoPriorityModel> Get(int userId, SortingOrder? priority)
        {
            var result = new List<VideoPriorityModel>();
            result.Add(new VideoPriorityModel() { video = "Video 5", priority = Priorities.high });
            result.Add(new VideoPriorityModel() { video = "Video 6", priority = Priorities.high });
            result.Add(new VideoPriorityModel() { video = "Video 7", priority = Priorities.high });

            if (userId == 5)
            {
                result.Add(new VideoPriorityModel() { video = "Video 8", priority = Priorities.medium });
            }

            if (priority == SortingOrder.asc)
            {
                result = result.OrderBy(x => x.priority).ToList<VideoPriorityModel>();
            }
            else
            {
                result = result.OrderByDescending(x => x.priority).ToList<VideoPriorityModel>();
            }

            return result;
        }
    }
}
