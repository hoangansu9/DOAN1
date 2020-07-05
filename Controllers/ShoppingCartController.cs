using doan_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace doan_1.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: ShoppingCart
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult AddtoCart(int id)
        {
            var pro = _db.Book.SingleOrDefault(s => s.BookID == id);
            if (pro != null)
            {
                GetCart().Add(pro);
            }
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        public ActionResult ShowToCart()
        {
            if (Session["Cart"] == null)
            {
                return RedirectToAction("ShowToCart", "ShoppingCart");
            }
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
        public ActionResult Update_Quantity_Cart(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_pro = Convert.ToInt32(form["ID_Product"]);
            int _quantity = int.Parse(form["Quantity"]);
            cart.Update_Quantity_Shopping(id_pro, _quantity);
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_Cart_Item(id);
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        public PartialViewResult BagCart()
        {
            int total_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)
                total_item = cart.Total_Quantity_In_Cart();
            ViewBag.QuantityCart = total_item;

            return PartialView("BagCart");

        }
        public ActionResult Shopping_Success()
        {
            return View();
        }

        //public ActionResult CheckOut(FormCollection form)
        //{
        //    try
        //    {
        //        Cart cart = Session["Cart"] as Cart;
        //        Order _order = new Order();
        //        _order.OrderDate = DateTime.Now;
        //        _order.CodeCus = int.Parse(form["CodeCustomer"]);
        //        _order.Descriptions = form["Address_Delivery"];
        //        _db.Orders.Add(_order);
        //        foreach (var item in cart.Items)
        //        {
        //            OrderDetail orderDetail = new OrderDetail();
        //            orderDetail.IDOrder = _order.IDOrder;
        //            orderDetail.IDProduct = item._shopping_product.IDProduct;
        //            orderDetail.UnitPriceSale = item._shopping_product.UnitPrice;
        //            orderDetail.QuantitySale = item._shopping_quantity;
        //            _db.OrderDetails.Add(orderDetail);
        //        }
        //        _db.SaveChanges();
        //        cart.ClearCart();
        //        return RedirectToAction("Shopping_Success", "ShoppingCart");
        //    }
        //    catch
        //    {
        //        return Content("Error CHeckout. Please information of Customer....");
        //    }
        //}
    }
}