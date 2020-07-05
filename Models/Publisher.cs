using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace doan_1.Models
{
    public class Publisher
    {
        [Key]
        public int PublisherID { get; set; }
        [Display(Name = "Tên nhà xuất bản")]

        [Required(ErrorMessage = "Tên nhà xuất bản là bắt buộc")]
        public string PublisherName { get; set; }
        [Display(Name = "Email")]
        [EmailAddress]
        public string PublisherEmail { get; set; }
        public ICollection<Book> Book { get; set; }
    }
}