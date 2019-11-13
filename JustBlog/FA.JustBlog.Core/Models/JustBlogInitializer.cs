using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Models
{
    public class JustBlogInitializer : CreateDatabaseIfNotExists<JustBlogContext>
    {
        protected override void Seed(JustBlogContext context)
        {
            Category category = new Category() { Name = "Entity Framework", Description = "All post in Entity Framework", UrlSlug = "entity framework" };
            context.Categories.Add(category);
            Category category2 = new Category() { Name = "FEE", Description = "All post in Entity FEE", UrlSlug = "Font end" };
            context.Categories.Add(category2);

            Tag t1 = new Tag()
            {
                Name = "Entity Framework",
                Description = "Entity Framework",
                Count = 100,
                UrlSlug = "entity framework"
            };
            Tag t2 = new Tag()
            {
                Name = "MVC",
                Description = "Microsoft MVC",
                Count = 50,
                UrlSlug = "mvc"
            };
            context.Tags.Add(t1);
            context.Tags.Add(t2);


            Post post = new Post()
            {
                Category = category,
                Title = "Man must explore, and this is exploration at its greatest",
                ShortDescription = "Problems look mighty small from 150 miles up",
                Modified = DateTime.Now,
                PostedOn = DateTime.Now,
                PostContent = @"In the above example, the Course and Teacher entities have two one-to-many relationships. A Course can be taught by an online teacher as well as a class-room teacher. In the same way, a Teacher can teach multiple online courses as well as class room courses.

Here,
                EF API cannot determine the other end of the relationship.It will throw the following exception for the above example during migration.
         

         Unable to determine the relationship represented by navigation property 'Course.OnlineTeacher' of type 'Teacher'.Either manually configure the relationship, or ignore this property using the '[NotMapped]' attribute or by using 'EntityTypeBuilder.Ignore' in 'OnModelCreating'.

        However, EF 6 will create the following Courses table with four foreign keys.",
                Published = true,
                RateCount = 10,
                TotalRate = 45,
                UrlSlug = "data annotation inverse property attribule in ef 1",
                ViewCount = 100,
                Tags = new List<Tag>() {t1
                     ,t2
                },
            };
            context.Posts.Add(post);

            Post post2 = new Post()
            {
                Category = category,
                Title = "I believe every human has a finite number of heartbeats. I don't intend to waste any of mine.",
                ShortDescription = "We predict too much for the next year and yet far too little for the next ten.",
                Modified = DateTime.Now,
                PostedOn = DateTime.Now,
                PostContent = @"In the above example, the Course and Teacher entities have two one-to-many relationships. A Course can be taught by an online teacher as well as a class-room teacher. In the same way, a Teacher can teach multiple online courses as well as class room courses.Here,
                            EF API cannot determine the other end of the relationship.It will throw the following exception for the above example during migration.
                            Unable to determine the relationship represented by navigation property 'Course.OnlineTeacher' of type 'Teacher'.Either manually configure the relationship, or ignore this property using the '[NotMapped]' attribute or by using 'EntityTypeBuilder.Ignore' in 'OnModelCreating'.
                            However, EF 6 will create the following Courses table with four foreign keys.",
                Published = true,
                RateCount = 10,
                TotalRate = 45,
                UrlSlug = "data annotation inverse property attribule in ef 2",
                ViewCount = 100,
                Tags = new List<Tag>() { t1 }
            };

            context.Posts.Add(post2);

            Post post3 = new Post()
            {
                Category = category2,
                Title = "Science has not yet mastered prophecy",
                ShortDescription = "We predict too much for the next year and yet far too little for the next ten.",
                Modified = DateTime.Now,
                PostedOn = DateTime.Now,
                PostContent = @"In the above example, the Course and Teacher entities have two one-to-many relationships. A Course can be taught by an online teacher as well as a class-room teacher. In the same way, a Teacher can teach multiple online courses as well as class room courses.Here,
                EF API cannot determine the other end of the relationship.It will throw the following exception for the above example during migration.
                Unable to determine the relationship represented by navigation property 'Course.OnlineTeacher' of type 'Teacher'.Either manually configure the relationship, or ignore this property using the '[NotMapped]' attribute or by using 'EntityTypeBuilder.Ignore' in 'OnModelCreating'.
                However, EF 6 will create the following Courses table with four foreign keys.",
                Published = true,
                RateCount = 10,
                TotalRate = 45,
                UrlSlug = "data annotation inverse property attribule in ef 3",
                ViewCount = 100,
                Tags = new List<Tag>() {
                    t1 ,
                    t2
                },
            };

            context.Posts.Add(post3);

            Post post4 = new Post()
            {
                Category = category2,
                Title = "Failure is not an option",
                ShortDescription = "Many say exploration is part of our destiny, but it’s actually our duty to future generations.",
                Modified = DateTime.Now,
                PostedOn = DateTime.Now,
                PostContent = @"In the above example, the Course and Teacher entities have two one-to-many relationships. A Course can be taught by an online teacher as well as a class-room teacher. In the same way, a Teacher can teach multiple online courses as well as class room courses.Here,
                EF API cannot determine the other end of the relationship.It will throw the following exception for the above example during migration.
                Unable to determine the relationship represented by navigation property 'Course.OnlineTeacher' of type 'Teacher'.Either manually configure the relationship, or ignore this property using the '[NotMapped]' attribute or by using 'EntityTypeBuilder.Ignore' in 'OnModelCreating'.
                However, EF 6 will create the following Courses table with four foreign keys.",
                Published = true,
                RateCount = 10,
                TotalRate = 45,
                UrlSlug = "data annotation inverse property attribule in ef 4",
                ViewCount = 100,
                Tags = new List<Tag>() {
                    t1 ,
                    t2
                },
            };

            context.Posts.Add(post4);

            Comment comment = new Comment()
            {
                Post = post,
                Name = "Scott Trinh",
                Email = "tutb@live.com",
                CommentTime = DateTime.Now,
                CommentHeader = "This is sample comment",
                CommentText = @"This is sample comment with 

            multiple lines"
            };

            context.Comments.Add(comment);

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
