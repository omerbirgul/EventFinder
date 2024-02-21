using EvenFinder.Data;
using EvenFinder.Data2.Abstract;

namespace EvenFinder.Data2.Concrate.EfCore
{
    public class EfCommentRepository : ICommentRepository
    {
        private readonly DataContext _dataContext;
        public EfCommentRepository(DataContext context)
        {
            _dataContext = context;
        }

        public IQueryable<Comment> Comments => _dataContext.Comments;

        public void CreateComment(Comment comment)
        {
            _dataContext.Comments.Add(comment);
            _dataContext.SaveChanges();
        }
    }
}
