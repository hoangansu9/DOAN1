using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace doan_1.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [Display(Name = "Khách hàng")]
        public string UserId { get; set; }

        [Display(Name = "Ngày order")]
        [Required(ErrorMessage = "Ngày order là bắt buộc !")]
        public DateTime OrderDate { get; set; }


        [Display(Name = "Tổng")]
        public float? SubTotal { get; set; }
    }
}