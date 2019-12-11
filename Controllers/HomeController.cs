using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        List<Good> goods1 = new List<Good>(){
                new Good() { Id=1, Title="Nokia 1100", Price=450.0, Category="Mobile"},
                new Good() { Id=2, Title="IPhone 10", Price=25000.0, Category="Mobile"},
                new Good() { Id=3, Title="Refrigerator 5000", Price=2555.0, Category="Kitchen"},
                new Good() { Id=4, Title="Mixer", Price=150.0, Category="Kitchen"},
                new Good() { Id=5, Title="Magnitola", Price=1450.0, Category="Car"},
            };
        List<Good> goods2 = new List<Good>(){
                new Good() { Id=6, Title="Samsung Galaxy", Price=3100, Category="Mobile"},
                new Good() { Id=7, Title="Auto Cleaner", Price=2300, Category="Car"},
                new Good() { Id=8, Title="Owen", Price=700, Category="Kitchen"},
                new Good() { Id=9, Title="Siemens Turbo", Price=3199, Category="Mobile"},
                new Good() { Id=10, Title="Lighter", Price=150.0, Category="Car"},
            };
        public ActionResult Index()
        {
            ViewBag.list = goods1.Concat(goods2);
            return View();
        }

        public ActionResult Prod(int a, int b)
        {
            ViewBag.total = $"{a} + {b} = {a + b}";
            return View();
        }

        public ActionResult Reverse(string str)
        {
            ViewBag.reverse = new string(str.ToCharArray().Reverse().ToArray());
            return View();
        }

        public ActionResult Max()
        {
            var price_max = goods1.Concat(goods2).Max(m => m.Price);
            ViewBag.maxPrice = price_max.ToString();
            return View();
        }

        public ActionResult Total(double? value)
        {
            if (value != null)
            {
                var total_price = goods1.Concat(goods2).Where(p => p.Price > value).Sum(s => s.Price);
                ViewBag.value = value;
                ViewBag.totalPrices = total_price.ToString();
            }
            else
                ViewBag.totalPrices = 0;
            return View();
        }
    }
}