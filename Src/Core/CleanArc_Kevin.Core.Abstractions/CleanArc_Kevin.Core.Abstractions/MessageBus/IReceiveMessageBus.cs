namespace CleanArc_Kevin.Core.Abstractions.MessageBus;

public interface IReceiveMessageBus
{
    void Subscribe(string serviceId, string eventName);
    void Receive(string commandName);
}