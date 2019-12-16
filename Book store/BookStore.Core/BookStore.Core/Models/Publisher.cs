using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FA.BookStore.Core.Models
{
    public class Publisher
    {
        [Key]
        public int PubId { get; set; }
        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(255)]
        public string PubName { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
