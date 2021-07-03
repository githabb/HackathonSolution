using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Services.Messages;
using Services.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Services.Controllers
{
    [Route("users")]
    [ApiController]
    public class UsersVideosPathsController : ControllerBase
    {
        private IMessageService _messageService;

        public UsersVideosPathsController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("{userId}/videos/{videoId}/paths")]
        public IEnumerable<PathPriorityModel> Get(int userId, int videoId, SortingOrder? priority)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

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

            stopWatch.Stop();
            _messageService.Enqueue(new InfoMessage() {elapsedTime = stopWatch.ElapsedMilliseconds, itemsCount = result.Count, url = Request.GetEncodedPathAndQuery() });

            return result;
        }
    }
}
