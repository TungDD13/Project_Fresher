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

        [ForeignKey("Categorys")]
        public int CategoryId { get; set; }
        public Category Categorys { get; set; }
        public int? AuthorId { get; set; }
        [ForeignKey("Publishers")]
        public int PubId { get; set; }
        public Publisher Publishers { get; set; }
        public string Summary { get; set; }
        public byte[] ImgUrl { get; set; }
        [NotMapped]
        //public IFormFile UploadedImage { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifieDate { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Comment> Comments { get; set; }

      

    }
}
