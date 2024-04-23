using Microsoft.AspNetCore.Mvc;
using RedisProjects.RedisService.CustomRedisService.Lib.Abstractions;
using RedisProjects.RedisService.CustomRedisService.Lib.Implementations;

namespace RedisProjects.RedisService.CustomRedisService.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RedisListController : ControllerBase
    {
        private readonly IRedisService _redisService;

        public RedisListController(IRedisService redisService)
        {
            _redisService = redisService;
        }

        [HttpPost]
        public IActionResult ListLeftPush(string key, string value)
        {
            _redisService.ListLeftPush(key, value);
            return Ok();
        }

        [HttpPost]
        public IActionResult ListRightPush(string key, string value)
        {
            _redisService.ListRightPush(key, value);
            return Ok();
        }

        [HttpPost]
        public IActionResult ListInsertAfter(string key, string pivot, string value)
        {
            return Ok(_redisService.ListInsertAfter(key, pivot, value));

        }

        [HttpPost]
        public IActionResult ListInsertBefore(string key, string pivot, string value)
        {
            return Ok(_redisService.ListInsertBefore(key, pivot, value));

        }
        [HttpGet]
        public IActionResult GetList(string key)
        {
            return Ok(_redisService.GetList(key));
        }

        [HttpDelete]
        public IActionResult RemoveValueFromList(string key, string value)
        {
            return Ok(_redisService.RemoveValueFromList(key, value));
        }
    }

}
