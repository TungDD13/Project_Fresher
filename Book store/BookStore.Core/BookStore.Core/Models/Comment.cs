using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.BookStore.Core.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [ForeignKey("Books")]
        public int BookId { get; set; }
        public Book Books { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
    }
}
