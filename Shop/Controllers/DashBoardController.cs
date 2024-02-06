using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using System.Security.Cryptography.X509Certificates;

namespace Shop.Controllers
{
    public class DashBoardController : Controller
    {
/*static is i want it in the whole controller and not create or got deleted
 it is global in controller u can use it wherever u want
 */
        private static List<Product> _products = new List<Product>();
        private static List<Blog> _blogs = new List<Blog>();
        private static List<Company> _companies = new List<Company>();
        private static List<Category> _categories = new List<Category>();
        public IActionResult DashBoardIndex()
        {
            return View();
        }
        /*Product Actions*/
        #region ProductView
        public IActionResult ProductIndex()
        {
            string message = TempData["Update"] as string;
            string delete = TempData["Delete"] as string;
            ViewBag.Delete = delete;
            ViewBag.Update = message;
            return View(_products);
        }
        #endregion
        #region CreateProduct
        public IActionResult Create()
        {
            string message = TempData["Create"] as string;
            ViewBag.Create = message;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            int id = 0;
            if (_products.Count() == 0) {

                id = 1;
            }
            else
            {
                 id = _products.Max(x => x.Id)+1;
            }
            product.Id = id;
            _products.Add(product);
            TempData["Create"] = "Data Created Successfully";
            return RedirectToAction("Create");
        }
        #endregion
        #region DeleteProduct
        
/*FirstorDefault single  single or default*/
        public IActionResult Delete(int id)
        {
            Product ToDelete = _products.FirstOrDefault(x => x.Id == id);
            _products.Remove(ToDelete);
            TempData["Delete"] = "Data Deleted Successfully";
            return RedirectToAction("ProductIndex");
        }
        #endregion
        #region UpdateProduct
        public IActionResult EditProduct(int id)
        {
            Product product = _products.FirstOrDefault(x => x.Id == id);
            return View(product);
        }
        [HttpPost]
        public IActionResult EditProduct(Product prod)
        {
            /*return BadRequest("Here u r inside");*/
            Product product = _products.FirstOrDefault(p => p.Id == prod.Id);
            product.Name = prod.Name;
            product.Description = prod.Description;
            product.Price = prod.Price;
            product.EnableSize = prod.EnableSize;
            product.Quantity = prod.Quantity;
            product.company = _companies.FirstOrDefault(x => x.Id == prod.company.Id);
            TempData["Update"] = "Data Updated Successfully";
            return RedirectToAction("ProductIndex");
        }
        #endregion

        /*Blog Actions*/
        #region BlogView
        public IActionResult BlogIndex()
        {
            string message = TempData["Update"] as string;
            string delete = TempData["Delete"] as string;
            ViewBag.Delete = delete;
            ViewBag.Update = message;
            return View(_blogs);
        }
        #endregion
        #region CreateBlog
        public IActionResult CreateBlog()
        {
            string message = TempData["Create"] as string;
            ViewBag.Create = message;
            return View();
        }
        [HttpPost]
        public IActionResult CreateBlog(Blog blog)
        {
            int id = 0;
            if (_blogs.Count() == 0)
            {

                id = 1;
            }
            else
            {
                id = _blogs.Max(x => x.Id) + 1;
            }
            blog.Id = id;

            _blogs.Add(blog);
            TempData["Create"] = "Data Created Successfully";
            return RedirectToAction("CreateBlog");
        }
        #endregion
        #region DeleteBlog
        public IActionResult DeleteBlog(int id)
        {
            Blog ToDelete = _blogs.FirstOrDefault(x => x.Id == id);
            _blogs.Remove(ToDelete);
            TempData["Delete"] = "Data Deleted Successfully";
            return RedirectToAction("BlogIndex");
        }
        #endregion
        #region UpdateBlog
        public IActionResult EditBlog(int id)
        {
            Blog blog = _blogs.FirstOrDefault(x => x.Id == id);
            return View(blog);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog blg)
        {
            /*return BadRequest("Here u r inside");*/
            Blog blog = _blogs.FirstOrDefault(p => p.Id == blg.Id);
            blog.Title = blg.Title;
            blog.Detail = blg.Detail;
            blog.category = _categories.FirstOrDefault(x => x.Id == blg.category.Id);
            TempData["Update"] = "Data Updated Successfully";
            return RedirectToAction("BlogIndex");
        }
        #endregion
    }
}
