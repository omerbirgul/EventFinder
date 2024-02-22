using EvenFinder.Data;

namespace EvenFinder.Data2.Abstract
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }


        void CreateUser(User user);
    }
}
