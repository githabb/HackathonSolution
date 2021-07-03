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
    public class UsersVideosController : ControllerBase
    {
        private IMessageService _messageService;

        public UsersVideosController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("{userId}/videos")]
        public IEnumerable<VideoPriorityModel> Get(int userId, SortingOrder? priority)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

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

            stopWatch.Stop();
            _messageService.Enqueue(new InfoMessage() { elapsedTime = stopWatch.ElapsedMilliseconds, itemsCount = result.Count });

            return result;
        }
    }
}
