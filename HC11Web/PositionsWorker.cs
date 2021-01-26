using System;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate.Subscriptions;
using Microsoft.Extensions.Hosting;

namespace HC11Web
{
    public class PositionWorker : BackgroundService
    {
        private readonly ITopicEventSender _eventSender;

        public PositionWorker(
            ITopicEventSender eventSender)
        {
            _eventSender = eventSender;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine("Position worker running at: {0}", DateTime.UtcNow);
                try
                {
                    Console.WriteLine("Sending subscription message ...");
                    await _eventSender.SendAsync(
                        Constants.PositionMessageId,
                        "positions updated status reset");
                }

                catch (Exception exception)
                {
                    Console.Error.WriteLine(
                        "Error while trying to pull trades from the Navigator Service {0}", exception);
                }
                finally
                {
                    await Task.Delay(2_000, cancellationToken);
                }
            }
        }
    }
}