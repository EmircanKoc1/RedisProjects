using Microsoft.AspNetCore.Mvc;
using RedisProjects.RedisClient.CustomRedisClient.Services;

namespace RedisProjects.RedisClient.CustomRedisClient.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RedisStringController : ControllerBase
    {
        private readonly IRedisService _redisService;

        public RedisStringController(IRedisService redisService)
        {
            _redisService = redisService;
        }


        [HttpPost]
        public IActionResult SetString(string key, string value, int keyExpireMin = 1)
        {
            return Ok(_redisService.SetString(key, value, TimeSpan.FromMinutes(keyExpireMin)));
        }

        [HttpGet]
        public IActionResult GetString(string key)
        {
            return Ok(_redisService.GetString(key));
        }

        [HttpDelete]
        public IActionResult RemoveKey(string key)
        {
            return Ok(_redisService.RemoveKey(key));
        }

        [HttpPut]
        public IActionResult StringIncrement(string key, long value)
        {

            return Ok(_redisService.IncrString(key, value));
        }

        [HttpPut]
        public IActionResult StringDecrement(string key, long value)
        {
            return Ok(_redisService.DecrString(key, value));
        }

      
    }

}
