using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;
using Shop.ViewModel;
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

        private readonly ApplicationDbContext _DB;
        public DashBoardController(ApplicationDbContext _db)
        {
            _DB = _db;
            _companies.Add(new Company {Id = 1 , Name = "Nike" });
            _companies.Add(new Company {Id = 2 , Name = "Adidas" });
        }
        public IActionResult DashBoardIndex()
        {
            return View();
        }
        /*Product Actions*/
        #region ProductView
        public IActionResult ProductIndex(int id)
        {
            string message = TempData["Update"] as string;
            string delete = TempData["Delete"] as string;
            ViewBag.Delete = delete;
            ViewBag.Update = message;
            var product = _DB.products.Include(p => p.company).ToList();
            /*var product = _DB.products
                           .Include(p => p.company)
                           .SingleOrDefault(p => p.Id == id);*/
            return View(product);
        }
        #endregion
        #region CreateProduct
        public IActionResult Create()
        {
            string message = TempData["Create"] as string;
            ViewBag.Create = message;
            var co = _DB.companies.ToList();
            var productView = new ProductViewModel()
            {
                companies = co
            };
            return View(productView);
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            _DB.products.Add(product);
            _DB.SaveChanges();
            return RedirectToAction("Create");
        }
        #endregion
        #region DeleteProduct
        
/*FirstorDefault single  single or default*/
        public IActionResult Delete(int id)
        {
            Product? product = _DB.products.FirstOrDefault(p => p.Id == id);
            TempData["Delete"] = "Data Deleted Successfully";
            _DB.products.Remove(product);
            _DB.SaveChanges();
            return RedirectToAction("ProductIndex");
        }
        #endregion
        #region UpdateProduct
        public IActionResult EditProduct(int id)
        {
            /*Product? product = _DB.products.Find(id);*/
            var co = _DB.companies.ToList();
            var productView = new ProductViewModel()
            {
                companies = co
            };
            return View(productView);
        }
        [HttpPost]
        public IActionResult EditProduct(Product prod)
        {
            if (!ModelState.IsValid)
            {
                return View(prod);
            }
            /*return BadRequest("Here u r inside");*/
            Product? product = _DB.products.Find(prod.Id);
            product.Name = prod.Name;
            product.Description = prod.Description;
            product.Price = prod.Price;
            product.EnableSize = prod.EnableSize;
            product.Quantity = prod.Quantity;
            product.CompanyId = prod.CompanyId;
            TempData["Update"] = "Data Updated Successfully";
            _DB.products.Update(product);
            _DB.SaveChanges();
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
            var blog = _DB.blogs.Include(b => b.category).ToList();
            return View(blog);
        }
        #endregion
        #region CreateBlog
        public IActionResult CreateBlog()
        {
            string message = TempData["Create"] as string;
            ViewBag.Create = message;
            var cate = _DB.categories.ToList();
            var blogView = new BlogViewModel()
            {
                categories = cate
            };

            return View();
        }
        [HttpPost]
        public IActionResult CreateBlog(Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return View(blog);
            }
            _DB.blogs.Add(blog);
            _DB.SaveChanges();
            return RedirectToAction("Create");
        }
        #endregion
        #region DeleteBlog
        public IActionResult DeleteBlog(int id)
        {
            Blog? blog = _DB.blogs.FirstOrDefault(b => b.Id == id);
            _DB.blogs.Remove(blog);
            _DB.SaveChanges();
            TempData["Delete"] = "Data Deleted Successfully";
            return RedirectToAction("BlogIndex");
        }
        #endregion
        #region UpdateBlog
        public IActionResult EditBlog(int id)
        {
            Blog? blog = _DB.blogs.Find(id);
            return View(blog);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog blg)
        {
            if (!ModelState.IsValid)
            {
                return View(blg);
            }
            /*return BadRequest("Here u r inside");*/
            Blog? blog = _DB.blogs.Find(blg.Id);
            blog.Title = blg.Title;
            blog.Detail = blg.Detail;
            blog.category = _categories.FirstOrDefault(x => x.Id == blg.category.Id);
            _DB.blogs.Update(blog);
            _DB.SaveChanges();
            TempData["Update"] = "Data Updated Successfully";
            return RedirectToAction("BlogIndex");
        }
        #endregion
    }
}
