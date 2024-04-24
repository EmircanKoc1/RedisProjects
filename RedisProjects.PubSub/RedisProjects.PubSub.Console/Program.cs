using StackExchange.Redis;
using sc = System.Console;

namespace RedisProjects.PubSub.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            

            ConnectionMultiplexer cm = ConnectionMultiplexer.Connect("localhost:6380");

            ISubscriber subscriber = cm.GetSubscriber();

            sc.WriteLine("my channel subscribe olundu");

            subscriber.Subscribe("mychannel", (channel, value) =>
            {

                sc.WriteLine("mesajın geldiği kanal  : " + channel.ToString());
                sc.WriteLine("mesaj : " + value.ToString());


            });


            Task.Delay(1000).Wait();

            subscriber.Publish("mychannel", "bu api ile gönderilen bir mesaj");

           

            sc.ReadLine();

        }
    }
}
