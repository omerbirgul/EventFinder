using EvenFinder.Data;
using EvenFinder.Data2.Abstract;

namespace EvenFinder.Data2.Concrate
{
    public class EfEventRepository : IEventRepository
    {

        private readonly DataContext _context;
        public EfEventRepository(DataContext context)
        {
            _context = context;
        }


        public IQueryable<Event> Events => _context.Events;

        public void CreateEvent(Event post)
        {
            _context.Events.Add(post);
            _context.SaveChanges();
        }
    }
}
