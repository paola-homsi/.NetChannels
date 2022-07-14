using System.Threading.Tasks;
using System.Threading.Channels;

namespace ChannelsDemo
{
    public class Producer
    {
        private ChannelWriter<string> _writer;
        public Producer(ChannelWriter<string> writer)
        {
            _writer = writer;
        }

        public async Task Start(int count)
        {
            for (int i = 0; i < count; i++)
            {
                await Task.Delay(100);
                while (await _writer.WaitToWriteAsync().ConfigureAwait(false))
                {
                    while (!_writer.TryWrite(i.ToString())) ;
                    break;
                }
            }
        }
    }
}
