using RedisProjects.PubSub.Lib.Interfaces;
using StackExchange.Redis;

namespace RedisProjects.PubSub.Lib.Implementations
{
    public class Messager : IMessager
    {
        protected IRedisContext _context;
        public ISubscriber Subscriber => _context.GetSubscriber();

        public Messager(IRedisContext context)
            => _context = context;

        public void ConsumeChannel(string channel, Action<string> action)
        {

            Subscriber.Subscribe(channel, (redisChannel, message) =>
            {
                action(message);
            });
        }

        public void PublishMessage(string channel, string message)
        {
            Subscriber.Publish(channel, message);
        }

        public void SubscribeChannel(string channel, Action<string> action)
        {
            ConsumeChannel(channel, action);
        }
    }
}
