using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using table.context;
using table.Models;

namespace table.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IToastNotification _toastNotification;

        public CategoryController(ApplicationDbContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
        }
        public IActionResult Index()
        {
            var Categories=_context.Categories.ToList();
            return View(Categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category model)
        {
            if (!ModelState.IsValid) { 
            return View(model);
            }
            _context.Categories.Add(model);
            _context.SaveChanges();
            _toastNotification.AddSuccessToastMessage("تم الإضافة بنجاح");
            return RedirectToAction("Index");
            //return View(nameof(Index), _context.Categories.ToList());
        }
        [HttpGet]
       
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var category = _context.Categories.Find(id);
                if (category == null)
                {
                    return NotFound();
                }
                return View(category);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category model)
        {

            var category = _context.Categories.Find(model.Id);
            if (category == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            category.CategoryName = model.CategoryName;
            category.Description = model.Description;
            _context.SaveChanges();
            _toastNotification.AddSuccessToastMessage("تم التعديل بنجاح");
            return RedirectToAction("Index");
            //return View(nameof(Index), _context.Categories.ToList());
        }

        [HttpGet]
    
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
            _toastNotification.AddSuccessToastMessage("تم الحذف بنجاح");
            return RedirectToAction("Index");
            //return View(nameof(Index), _context.Categories.ToList());
        }
    }
}
