using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace doan_1.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }

        [Display(Name = "Hoá đơn")]
        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public Order Order { get; set; }


        [Display(Name = "Sách")]
        [ForeignKey("Book")]
        public int BookID { get; set; }
        public Book Book { get; set; }

        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }
        [Display(Name = "Đơn giá")]
        public float UnitPriceSale { get; set; }
    }
}