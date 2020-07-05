using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace doan_1.Models
{
    public class Category
    {
        [Key]
        public int CateID { get; set; }
        [Display(Name = "Tên loại")]
        [Required(ErrorMessage = "Tên loại là bắt buộc")]
        public string CateName { get; set; }

        public ICollection<Book> Book { get; set; }
    }
}