using Microsoft.AspNetCore.Mvc;
using RedisProjects.RedisService.CustomRedisService.Lib.Abstractions;

namespace RedisProjects.RedisService.CustomRedisService.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class RedisSortedSetController : ControllerBase
{
    private readonly IRedisService _redisService;

    public RedisSortedSetController(IRedisService redisService)
    {
        _redisService = redisService;
    }

    [HttpGet]
    public IActionResult GetSetMemberCount(string key)
    {
        return Ok(_redisService.GetSortedSetMemberCount(key));
    }

    [HttpPost]
    public IActionResult AddItemSortedSet(string key, string value, double score)
    {
        return Ok(_redisService.AddItemToSortedSet(key, value,score));
    }

    [HttpGet]
    public IActionResult IsKeyExistsFromSortedSet(string key, string value)
    {
        return Ok(_redisService.IsKeyExistsFromSortedSet(key, value));
    }

    [HttpDelete]
    public IActionResult RemoveItemFromSortedSet(string key, string value)
    {
        return Ok(_redisService.RemoveItemFromSortedSet(key, value));
    }

    [HttpGet]
    public IActionResult GetItemsFromSortedSet(string key)
    {
        return Ok(_redisService.GetItemsFromSortedSet(key));
    }
    [HttpGet]
    public IActionResult GetItemsWithScoreFromSortedSet(string key)
    {
        return Ok(_redisService.GetItemsWithScoreFromSortedSet(key));
    }

}