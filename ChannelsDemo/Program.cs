using System;
using System.Threading.Tasks;
using System.Threading.Channels;

namespace ChannelsDemo
{
    class Program
    {
        private static Channel<string> channel;
        private const int TOTAL_ITEMS = 1000;
        private const int CHANNEL_CAPACITY = 1000;
        static async Task Main(string[] args)
        {
            channel = Channel.CreateBounded<string>(CHANNEL_CAPACITY);

            Producer producer = new Producer(channel.Writer);
            Consumer consumer = new Consumer(channel.Reader);

            producer.Start(TOTAL_ITEMS).ConfigureAwait(false);
            await consumer.Consume().ConfigureAwait(false);

            channel.Writer.TryComplete();
            Console.WriteLine("Hello World!");

            Console.ReadLine();
        }
    }
}
