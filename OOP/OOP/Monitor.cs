using System;

namespace OOP
{
    public class Monitor : IVGAReceiver
    {
        public void ReceiveVGA(string content)
        {
            Console.WriteLine("Display " + content + " on screen");
        }
    }
}