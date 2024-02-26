using EvenFinder.Data;
using EvenFinder.Data2.Abstract;

namespace EvenFinder.Data2.Concrate.EfCore
{
    public class EfRegistrationRepository : IRegistrationRepository
    {
        private readonly DataContext _context;
        public EfRegistrationRepository(DataContext context)
        {
            _context = context;
        }


        public IQueryable<Registration> Registries => _context.Registrations;



        public void RegisterToEvent(Registration registration)
        {
            _context.Registrations.Add(registration);
            _context.SaveChanges();
        }
    }
}
