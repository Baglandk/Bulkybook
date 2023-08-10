using BulkyBook.App.Data;
using BulkyBook.App.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook.App.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryDb categoryDb;
        public CategoryController(CategoryDb categoryDb)
        {
            this.categoryDb = categoryDb;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = categoryDb.categories.ToList();
            return View(objCategoryList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name==Convert.ToString(obj.DisplayOrder))
            {
                ModelState.AddModelError("CustomError", "The name should not be the same");
            }
            if (ModelState.IsValid)
            {
                categoryDb.categories.Add(obj);
                categoryDb.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            var CategoryUpdate = categoryDb.categories.Find(id);
            if(CategoryUpdate==null)
            {
                return NotFound();
            }
            return View(CategoryUpdate);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == Convert.ToString(obj.DisplayOrder))
            {
                ModelState.AddModelError("CustomError", "The name should not be the same");
            }
            if (ModelState.IsValid)
            {
                categoryDb.categories.Update(obj);
                categoryDb.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var CategoryUpdate = categoryDb.categories.Find(id);
            if (CategoryUpdate == null)
            {
                return NotFound();
            }
            return View(CategoryUpdate);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Delete(Category obj)
        {
            if (ModelState.IsValid)
            {
                categoryDb.categories.Remove(obj);
                categoryDb.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
