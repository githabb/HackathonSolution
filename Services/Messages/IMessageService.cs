namespace Services.Messages
{
    public interface IMessageService
    {
        bool Enqueue(InfoMessage message);
    }
}
