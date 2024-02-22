using EvenFinder.Data;

namespace EvenFinder.Data2.Abstract
{
    public interface IEventRepository
    {
        IQueryable<Event> Events { get; }

        void CreateEvent(Event post);
    }
}
