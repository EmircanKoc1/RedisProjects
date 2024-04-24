using Microsoft.AspNetCore.Mvc;
using RedisProjects.RedisService.CustomRedisService.Lib.Abstractions;

namespace RedisProjects.RedisService.CustomRedisService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RedisHashController : ControllerBase
    {
        private readonly IRedisService _redisService;
        private readonly IRedisHashService _redisHashService;

        public RedisHashController(IRedisService redisService)
        {
            _redisService = redisService;
            _redisHashService = _redisService as IRedisHashService;
        }

        [HttpPost]
        public IActionResult HashSet(string key, string fieldName, string valueName)
        {
            _redisHashService.HashSet(key, fieldName, valueName);
            return Ok();
        }

        [HttpGet]
        public IActionResult HashGetByFieldWithValue(string key , string fieldName)
        {
            return Ok(_redisHashService.HashGetByFieldWithValue(key, fieldName));
        }

        [HttpDelete]
        public IActionResult HashDeleteByFieldName(string key, string fieldName)
        {
            return Ok(_redisHashService.HashDeleteByFieldName(key, fieldName));
        }

        [HttpGet]
        public IActionResult GetHashAllFieldsWithValues(string key)
        {
            return Ok(_redisHashService.GetHashAllFieldsWithValues(key));
        }

        [HttpGet]
        public IActionResult GetHashAllFieldValuesByKey(string key)
        {
            return Ok(_redisHashService.GetHashAllFieldNamesByKey(key));
        }
    }
}
