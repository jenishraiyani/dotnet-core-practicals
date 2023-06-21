using eCommerceCore.Interfaces;
using eCommerceMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceCore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Authorize(Policy = "AdminAndUser")]

        public ActionResult Index()
        {
            var products = _productService.GetAllProducts().ToList();
            return View(products);
        }

        [Authorize(Policy = "CreateProductPolicy")]
        public ActionResult Create()
        {
            return View();
        }
        [Authorize(Policy = "CreateProductPolicy")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.AddProduct(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        [Authorize(Policy = "AdminAndUser")]
        public ActionResult Details(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                ModelState.AddModelError("ProductNotFound", "Product not found.");
            }
            return View(product);
        }


        [Authorize(Policy = "EditProductPolicy")]
        public ActionResult Edit(int id)
        {
            var product = _productService.GetProductById(id);

            if (product == null)
            {
                ModelState.AddModelError("ProductNotFound", "Product not found.");
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "EditProductPolicy")]
        public ActionResult Edit(int id, Product product)
        {
            if (id != product.ProductId)
            {
                ModelState.AddModelError("ProductNotFound", "Product not found.");
            }

            if (ModelState.IsValid)
            {
                _productService.UpdateProduct(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {

            int count = _productService.DeleteProduct(id);

            if (count > 0)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }
    }
}
