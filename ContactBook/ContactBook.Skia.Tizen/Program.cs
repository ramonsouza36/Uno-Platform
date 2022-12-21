using Tizen.Applications;
using Uno.UI.Runtime.Skia;

namespace ContactBook.Skia.Tizen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = new TizenHost(() => new ContactBook.App());
            host.Run();
        }
    }
}
