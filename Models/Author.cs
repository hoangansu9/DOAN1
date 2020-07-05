using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace doan_1.Models
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }
        [Display(Name = "Tên tác giả")]
        [Required(ErrorMessage = "Tên tác giả là bắt buộc")]
        public string AuthorName { get; set; }

        public ICollection<Book> Book { get; set; }
    }
}