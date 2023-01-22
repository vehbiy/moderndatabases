namespace OOP
{
    public class Computer : IVGASender
    {
        public void SendVGA(string content, IVGAReceiver receiver)
        {
            receiver.ReceiveVGA(content); 
        }
    }
}