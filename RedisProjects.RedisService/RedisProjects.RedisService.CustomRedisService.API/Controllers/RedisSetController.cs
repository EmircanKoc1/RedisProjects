using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using RedisProjects.RedisService.CustomRedisService.Lib.Abstractions;

namespace RedisProjects.RedisService.CustomRedisService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RedisSetController : ControllerBase
    {
        private readonly IRedisService _redisService;

        public RedisSetController(IRedisService redisService)
        {
            _redisService = redisService;
        }

        [HttpGet]
        public IActionResult GetSetMemberCount(string key)
        {
            return Ok(_redisService.GetSetMemberCount(key));
        }

        [HttpPost]
        public IActionResult AddItemSet(string key, string value)
        {
            return Ok(_redisService.AddItemToSet(key, value));
        }

        [HttpGet]
        public IActionResult IsKeyExistsFromSet(string key, string value)
        {
            return Ok(_redisService.IsKeyExistsFromSet(key, value));
        }

        [HttpDelete]
        public IActionResult  RemoveItemFromSet(string key,string value)
        {
            return Ok(_redisService.RemoveItemFromSet(key,value));
        }

        [HttpGet]
        public IActionResult GetItemsFromSet(string key)
        {
            return Ok(_redisService.GetItemsFromSet(key));
        }

    }
}
