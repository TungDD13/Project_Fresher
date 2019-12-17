using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FA.BookStore.Core.Models
{
    public class Category
    {
        [Key]
        public int CateId { get; set; }
        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(255)]
        public string CateName { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime ModifieDate { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
