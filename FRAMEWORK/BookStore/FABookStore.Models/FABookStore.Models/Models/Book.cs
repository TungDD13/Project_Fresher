using FABookStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.BookStore.Core.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Title name is required.")]
        [StringLength(255)]
        public string Title { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        [ForeignKey("Publisher")]
        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }
        public string Summary { get; set; }
        public string ImgUrl { get; set; }
        //[NotMapped]
        //public IFormFile UploadedImage { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Comment> Comments { get; set; }

      

    }
}
