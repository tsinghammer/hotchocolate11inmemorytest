using System;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;

namespace HC11Web
{
    public class Subscription
    {
        [Subscribe]
        [Topic(Constants.PositionMessageId)]
        public async Task<string> Positions([EventMessage] string message)
        {
            Console.WriteLine("Message received {0}", message);

            try
            {
                return await Task.FromResult(message);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Positions subscription exception {0}", exception);
                return await Task.FromResult("hello");
            }
        }
    }
}
