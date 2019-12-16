using FA.BookStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.BookStore.Core.Repositories
{
    public interface ICommentRepository : IDisposable
    {
        Comment FindComment(int CommentId);
        bool AddComment(Comment Comment);
        bool UpdateComment(Comment Comment);
        bool DeleteComment(int commentId);
        bool DeleteComment(Comment Comment);
        List<Comment> GetAllComment();
        Comment GetCommentByBook(string book);
    }
}
