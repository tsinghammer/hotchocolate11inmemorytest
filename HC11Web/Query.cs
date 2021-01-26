using System.Collections.Generic;

namespace HC11Web
{
    public class Query
    {
        public IEnumerable<string> GetStrings() => new[] { "hello1", "hello2" };
    }
}