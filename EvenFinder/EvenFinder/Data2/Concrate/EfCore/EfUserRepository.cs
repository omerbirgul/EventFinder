using EvenFinder.Data;
using EvenFinder.Data2.Abstract;

namespace EvenFinder.Data2.Concrate.EfCore
{
    public class EfUserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public EfUserRepository(DataContext context)
        {
            _dataContext = context;
        }

        public IQueryable<User> Users => _dataContext.Users;

        public void CreateUser(User user)
        {
            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();
        }
    }
}
