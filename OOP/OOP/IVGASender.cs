namespace OOP
{
    public interface IVGASender
    {
        void SendVGA(string content, IVGAReceiver receiver);
    }
}