using EvenFinder.Data;

namespace EvenFinder.Data2.Abstract
{
    public interface ICommentRepository
    {
        IQueryable<Comment> Comments { get; }

        void CreateComment(Comment comment);
    }
}
