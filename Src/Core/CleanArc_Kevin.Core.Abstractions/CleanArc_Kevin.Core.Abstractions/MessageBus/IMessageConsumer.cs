namespace CleanArc_Kevin.Core.Abstractions.MessageBus;

public interface IMessageConsumer
{
    Task<bool> ConsumeEvent(string sender, Parcel parcel);
    Task<bool> ConsumeCommand(string sender, Parcel parcel);
}