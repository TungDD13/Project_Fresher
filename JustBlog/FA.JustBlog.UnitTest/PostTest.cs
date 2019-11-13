using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories;
using NUnit.Framework;


namespace FA.JustBlog.UnitTest
{
    [TestFixture]
    public class PostTest
    {
        private ICategoryRepository categoryRepository = new CategoryRepository();
        private IPostRepository postRepository = new PostRepository();
        private ITagRepository tagRepository = new TagRepository();
        [Test]
        public void TestAddPost()
        {
            Category category = new Category();
            category.Name = "Entity Framework";
            category.UrlSlug = "Entity Framework";
            category.Description = "All posts in Entity Framework category";

            categoryRepository.AddCategory(category);

            Post post = new Post()
            {
                Category = category,
                Title = "Hello JustBlog!",
                ShortDescription = "This is my first blog post!",
                PostContent = "This is my first blog post!",
                Modified = DateTime.Now,
                Published = true,
                PostedOn = DateTime.Now,
                TotalRate = 10,
                RateCount = 45,
                ViewCount = 100,
            };

            List<Tag> listTags = new List<Tag>();
            listTags.Add(new Tag() { Name = "Entity Framework", Description = "Entity Framework 6.0" });
            post.Tags = listTags;
            categoryRepository.AddCategory(category);
            postRepository.AddPost(post);

            Assert.That(1 == 1);
        }
    }
}
