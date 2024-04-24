using Microsoft.AspNetCore.Mvc;
using RedisProjects.PubSub.Lib.Interfaces;

namespace RedisProjects.PubSub.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessager _messager;
        private readonly ILogger<MessageController> _logger;
        public MessageController(IMessager messager, ILogger<MessageController> logger)
        {
            _messager = messager;
            _logger = logger;
        }

        [NonAction]
        public string PublishAndConsumeMessage(string channel, string message)
        {
            string consumedMessage = default;

            _messager.SubscribeChannel(channel, (subscibedMessage) =>
            {
                _logger.LogInformation($"Subscribed : {subscibedMessage}");
                consumedMessage = message;
            });

            _messager.PublishMessage(channel, message);

            return consumedMessage;
        }

        [HttpPost]
        public IActionResult PublishMessage(string channel, string message)
        {
            _messager.PublishMessage(channel, message);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> SubscribeChannel(string channel , int subsribeDelayTime = 1000)
        {
            string returnedMessage = string.Empty;


            _messager.SubscribeChannel(channel, (message) =>
            {
                _logger.LogInformation($"Subscibed {message}");
                returnedMessage = message;

            });

            await Task.Delay(subsribeDelayTime);

            return Ok(returnedMessage);
        }

        [HttpPost]
        public async Task<IActionResult> PublishAndSubsribeChannel(string channel, string message, int subsribeDelayTime = 1000)
        {
            string returnMessage = PublishAndConsumeMessage(channel, message);

            await Task.Delay(subsribeDelayTime);

            return Ok(returnMessage);

        }


    }
}
