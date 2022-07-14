using System;
using System.Threading.Tasks;
using System.Threading.Channels;

namespace ChannelsDemo
{
    public class Consumer
    {
        ChannelReader<string> _reader;
        public Consumer(ChannelReader<string> reader)
        {
            _reader = reader;
        }

        public async Task Consume()
        {
            while (await _reader.WaitToReadAsync())
            {
                if (_reader.TryRead(out var msg))
                {
                    Console.WriteLine(msg);
                }
            }

        }
    }
}
