using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Core.Repositories
{

    public class TagRepository : ITagRepository
    {
        private readonly JustBlogContext db = new JustBlogContext();
        public void AddTag(Tag tag)
        {
            db.Tags.Add(tag);
            db.SaveChanges();
        }

        public void DeleteTag(Tag tag)
        {
            var item = db.Tags.Find(tag.Name);
            db.Tags.Remove(item);
            db.SaveChanges();
        }

        public void DeleteTag(int tagId)
        {
            var item = db.Tags.Find(tagId);
            db.Tags.Remove(item);
            db.SaveChanges();
        }

        public Tag Find(string name)
        {
            return db.Tags.Find(name);
        }

        public IList<Tag> GetAllTags()
        {
            return db.Tags.ToList();
        }

        public void UpdateTag(Tag tag)
        {
            db.Entry(tag).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Tag GetTagByUrlSlug(string urlSlug)
        {
            var tag = db.Tags.FirstOrDefault<Tag>(t => t.UrlSlug == urlSlug);
            return tag;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
