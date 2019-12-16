using System;
using System.Collections.Generic;
using System.Linq;
using FA.BookStore.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FA.BookStore.Core.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private BookContext db;
        public PublisherRepository(BookContext bookContext)
        {
            db = bookContext;
        }
        public bool AddPublisher(Publisher publisher)
        {
            try
            {
                db.Publishers.Add(publisher);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeletePublisher(Publisher publisher)
        {
            try
            {
                var item = db.Publishers.Find(publisher.PubId);
                db.Publishers.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeletePublisher(int PublisherId)
        {
            try
            {
                var item = db.Publishers.Find(PublisherId);
                db.Publishers.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
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

        public Publisher Find(int publisherId)
        {
            return db.Publishers.Find(publisherId);
        }

        public List<Publisher> GetAllPublisher()
        {
            return db.Publishers.ToList();
        }

        public bool UpdatePublisher(Publisher publisher)
        {
            try
            {
                db.Entry(publisher).State = EntityState.Modified;
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
