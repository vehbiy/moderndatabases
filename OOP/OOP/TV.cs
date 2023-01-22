using System;

namespace OOP
{
    public class TV : IVGAReceiver
    {
        public void ReceiveVGA(string content)
        {
            Console.WriteLine("Display " + content + " on TV");
        }
    }
}