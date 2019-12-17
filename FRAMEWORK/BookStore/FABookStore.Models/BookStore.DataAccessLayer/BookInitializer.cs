using FA.BookStore.Core.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace BookStore.DataAccessLayer
{
    public class BookInitializer: DropCreateDatabaseAlways<BookStoreContext>
    {
        protected override void Seed(BookStoreContext context)
        {
            Category cate1 = new Category() { CateName = "Anime", CreateDate = new DateTime(2019, 01, 01), ModifieDate = new DateTime(2019, 02, 02), Description = "this is a Description 1" };
            Category cate2 = new Category() { CateName = "Viet Nam", CreateDate = new DateTime(2019, 01, 01), ModifieDate = new DateTime(2019, 02, 02), Description = "this is a Description 2" };
            Category cate3 = new Category() { CateName = "Dan Gian", CreateDate = new DateTime(2019, 01, 01), ModifieDate = new DateTime(2019, 02, 02), Description = "this is a Description 3" };
            //context.Categories.Add(cate1);
            //context.Categories.Add(cate2);
            //context.Categories.Add(cate3);
            context.Categories.AddOrUpdate(c => c.CateName, cate1, cate2, cate3);

            Publisher pub1 = new Publisher() { PubName = "Doan Tung", Description = "he is a publisher" };
            Publisher pub2 = new Publisher() { PubName = "Doan Tung 2", Description = "he is a publisher 2" };
            //context.Publishers.Add(pub1);
            //context.Publishers.Add(pub2);
            context.Publishers.AddOrUpdate(p => p.PubName, pub1, pub2);

            Book book1 = new Book()
            {
                Title = "Title 1",
                Categorys = cate1,
                //AuthorId = 1,
                Publishers = pub1,
                Summary = "Summary 1",
                //ImgUrl = "Image 1",
                Price = 100,
                Quantity = 50,
                CreateDate = new DateTime(2019, 01, 01),
                ModifieDate = new DateTime(2019, 02, 02),
                IsActive = true,
            };

            //context.Books.Add(book1);
            context.Books.AddOrUpdate(b => b.Title, book1);

            Comment comment1 = new Comment() { Books = book1, Content = "this is perfect", CreateDate = new DateTime(2019, 02, 03), IsActive = true };
            Comment comment2 = new Comment() { Books = book1, Content = "this is good", CreateDate = new DateTime(2019, 05, 03), IsActive = false };
            //context.Comments.Add(comment1);
            //context.Comments.Add(comment2);
            context.Comments.AddOrUpdate(c => c.Content, comment1, comment2);

            base.Seed(context);
        }
    }
}
