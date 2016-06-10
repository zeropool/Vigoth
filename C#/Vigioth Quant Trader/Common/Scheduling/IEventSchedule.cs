namespace VigiothCapital.QuantTrader.Scheduling
{
    public interface IEventSchedule
    {
        void Add(ScheduledEvent scheduledEvent);
        void Remove(string name);
    }
}