using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Core.Repositories
{

    public class CommentRepository : ICommentRepository
    {
        private readonly JustBlogContext db = new JustBlogContext();

        public void AddComment(Comment comment)
        {
            if(comment.CommentTime == null)
            {
                comment.CommentTime = DateTime.Now;
            }
            
            db.Comments.Add(comment);
            db.Entry(comment).State = EntityState.Added;
            db.SaveChanges();
        }

        public void AddComment(int postId, string commentName, string commentEmail, string commentTitle, string commentBody)
        {
            //var post = postRepository.FindPost(postId);
            var post = db.Posts.Find(postId);
            Comment comment = new Comment();
            comment.Name = commentName;
            comment.Email= commentEmail;
            comment.CommentHeader = commentTitle;
            comment.CommentText = commentBody;
            comment.Post = post;
            comment.CommentTime = DateTime.Now;
            db.Comments.Add(comment);
            db.SaveChanges();
        }

        public void DeleteComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public void DeleteComment(int commendId)
        {
            throw new NotImplementedException();
        }

        public Comment Find(int commentId)
        {
            return db.Comments.Find(commentId);
        }

        public IList<Comment> GetAllComments()
        {
            return db.Comments.ToList();
        }

        public IList<Comment> GetCommentsForPost(int postId)
        {
            return db.Posts.Find(postId).Comments.ToList();
        }

        public IList<Comment> GetCommentsForPost(Post post)
        {
            return post.Comments.ToList();
        }

        public void UpdateComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
