using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace doan_1.Models
{
    public class Provider
    {
        [Key]
        public int ProviderID { get; set; }
        [Display(Name = "Tên nhà cung cấp")]
        [Required(ErrorMessage = "Tên nhà cung cấp là bắt buộc")]
        public string ProviderName { get; set; }
        [Display(Name = "Email")]
        [EmailAddress]
        public string ProviderEmail { get; set; }
        [Display(Name = "Phone")]
        [Phone]
        public string ProviderPhone { get; set; }
        [Display(Name = "Địa chỉ")]
        public string ProviderAddress { get; set; }
        public ICollection<Book> Book { get; set; }
    }
}