using StackExchange.Redis;

namespace RedisProjects.PubSub.Lib.Interfaces
{
    public interface IMessager
    {
        ISubscriber Subscriber { get; }
        void PublishMessage(string channel, string message);
        void ConsumeChannel(string channel, Action<string> action);
        void SubscribeChannel(string channel, Action<string> action);
    }
}
