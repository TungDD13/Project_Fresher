using System;
using System.Collections.Generic;
using System.Linq;
using FA.BookStore.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FA.BookStore.Core.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private BookContext db;

        public CommentRepository(BookContext bookContext)
        {
            db = bookContext;
        }
        public bool AddComment(Comment Comment)
        {
            try
            {
                db.Comments.Add(Comment);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteComment(Comment Comment)
        {
            try
            {
                var item = db.Comments.Find(Comment.CommentId);
                db.Comments.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteComment(int commentId)
        {
            try
            {
                var item = db.Comments.Find(commentId);
                db.Comments.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private bool _disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Comment FindComment(int CommentId)
        {
            return db.Comments.Find(CommentId);
        }

        public List<Comment> GetAllComment()
        {
            return db.Comments.ToList();
        }

        public Comment GetCommentByBook(string bookTitle)
        {
            return db.Comments.FirstOrDefault(c => c.Books.Title == bookTitle);
        }

        public bool UpdateComment(Comment Comment)
        {
            try
            {
                db.Entry(Comment).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
