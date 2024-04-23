using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using RedisProjects.DistributedCache.Entities;
using RedisProjects.DistributedCache.Extensions;
using System.Text;

namespace RedisProjects.DistributedCache.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CacheController : ControllerBase
    {
        private readonly IDistributedCache _cache;

        [NonAction]
        private bool isStringKeyValid(string key) => !string.IsNullOrWhiteSpace(key);
        [NonAction]
        private bool isProductValid(Product product) => !(product is null);


        public CacheController(IDistributedCache cache)
            => _cache = cache;


        [HttpPost]
        public async Task<IActionResult> SetCache(string key, Product product)
        {

            if (!isStringKeyValid(key))
                return BadRequest("key is null");

            if (!isProductValid(product))
                return BadRequest("value is null");

            await _cache.SetStringAsync(key, product.Serialize());

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> SetCacheWithOptions(int absoluteMin, int slidingExpiration, string key, Product product)
        {

            if (!isStringKeyValid(key))
                return BadRequest("key is null");

            if (!isProductValid(product))
                return BadRequest("value is null");

            var options = new DistributedCacheEntryOptions()
            {
                AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(absoluteMin),
                SlidingExpiration = TimeSpan.FromMinutes(slidingExpiration),
            };


            await _cache.SetStringAsync(key, product.Serialize(), options);


            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetCache(string key)
        {
            if (!isStringKeyValid(key))
                return BadRequest("key is null");

            return Ok((await _cache.GetStringAsync(key))?.Deserialize<Product>());
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCache(string key)
        {
            if (!isStringKeyValid(key))
                return BadRequest("value is null");


            await _cache.RemoveAsync(key);

            return Ok();
        }


    }
}
