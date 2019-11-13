using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Core.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly JustBlogContext db = new JustBlogContext();
        public void AddPost(Post post)
        {
            db.Posts.Add(post);
            post.Tags = new List<Tag>();
            if (!string.IsNullOrEmpty(post.TagValues))
            {
                var tags = post.TagValues.Split(new[] { ";", "," }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string tag in tags)
                {
                   var keyword = tag.Trim();
                    var tagObject = db.Tags.Find(keyword);
                    if (tagObject == null)
                    {
                        var newTag = new Tag()
                        {
                            Name = keyword,
                            UrlSlug = keyword,
                            Count = 1,
                            Description = keyword
                        };
                        newTag = db.Tags.Add(newTag);
                        post.Tags.Add(newTag);
                    }
                    else
                    {
                        tagObject.Count += 1;
                        db.Entry(tagObject).State = EntityState.Modified;
                        post.Tags.Add(tagObject);
                    }
                }
            }

            db.SaveChanges();
        }

        public int CountPostsForCategory(string category)
        {
            return db.Posts.Count(p => p.Category.Name == category);
        }

        public int CountPostsForTag(string tag)
        {
            return db.Posts.Count(p => p.Tags.Any(t => t.Name == tag));
        }

        public void DeletePost(Post post)
        {
            var item = db.Posts.Find(post.Id);
            db.Posts.Remove(item);
            db.SaveChanges();
        }

        public void DeletePost(int postId)
        {
            var item = db.Posts.Find(postId);
            db.Posts.Remove(item);
            db.SaveChanges();
        }

        public Post FindPost(int postId)
        {
            return db.Posts.Find(postId);
        }

        public Post FindPost(int year, int month, string urlSluq)
        {
            var post =
                db.Posts.Include("Category").SingleOrDefault<Post>(p => p.Published && p.PostedOn.Year == year && p.PostedOn.Month == month && p.UrlSlug == urlSluq);
            return post;
        }

        public IList<Post> GetAllPosts()
        {
            return db.Posts.OrderByDescending(p => p.PostedOn).ToList();
        }

        public IList<Post> GetPublisedPosts()
        {
            return db.Posts.Where(p => p.Published).OrderByDescending(p => p.PostedOn).ToList();
        }

        public IList<Post> GetUnpublisedPosts()
        {
            return db.Posts.Where(p => !p.Published).OrderByDescending(p => p.Modified).ToList();
        }

        public IList<Post> GetHighestPosts(int size)
        {
            return db.Posts.OrderByDescending(p => p.Rate).Take(size).ToList();
        }

        public IList<Post> GetLatestPost(int size)
        {
            return db.Posts.OrderByDescending(p => p.PostedOn).Take(size).ToList();
        }

        public IList<Post> GetMostViewedPost(int size)
        {
            return db.Posts.OrderByDescending(p => p.ViewCount).Take(size).ToList();
        }

        public IList<Post> GetPostsByCategory(string category)
        {
            return db.Posts.Where(p => p.Category.Name == category).ToList();
        }

        public IList<Post> GetPostsByMonth(DateTime monthYear)
        {
            var fromDate = new DateTime(monthYear.Year, monthYear.Month, 1);
            var toDate = fromDate.AddMonths(1).AddDays(-1);
            return db.Posts.Where(p => p.PostedOn >= fromDate && p.PostedOn <= toDate).ToList();
        }

        public IList<Post> GetPostsByTag(string tag)
        {
            return db.Posts.Where(p => p.Tags.Any(t => t.UrlSlug == tag)).ToList();
        }

        public void UpdatePost(Post post)
        {
            var oldPost = db.Posts.Find(post.Id);
            //oldPost.TagValues = post.TagValues;
            db.Entry(oldPost).CurrentValues.SetValues(post);

            oldPost.Tags.Clear();
            if (!string.IsNullOrEmpty(post.TagValues))
            {
                var tags = post.TagValues.Split(new[] { ";", "," }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string tag in tags)
                {
                    var keyword = tag.Trim();
                    var tagObject = db.Tags.FirstOrDefault(t => t.Name == keyword);
                    if (tagObject == null)
                    {
                        var newTag = new Tag()
                        {
                            Name = keyword,
                            UrlSlug = keyword,
                            Count = 1,
                            Description = keyword
                        };
                        newTag = db.Tags.Add(newTag);
                        oldPost.Tags.Add(newTag);
                    }
                    else
                    {
                        tagObject.Count += 1;
                        db.Entry(tagObject).State = EntityState.Modified;
                        oldPost.Tags.Add(tagObject);
                    }
                }
            }
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
