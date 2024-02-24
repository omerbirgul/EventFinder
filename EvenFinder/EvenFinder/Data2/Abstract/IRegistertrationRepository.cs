using EvenFinder.Data;

namespace EvenFinder.Data2.Abstract
{
    public interface IRegistrationRepository
    {
        IQueryable<Registration> Registrations { get; }

        void Register(Registration registration);
    }
}
