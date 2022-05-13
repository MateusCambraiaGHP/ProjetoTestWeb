using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoTest.Interfaces;
using ProjetoTest.Models;

namespace ProjetoTest.Controllers
{
    public class MaterialController : Controller
    {
        private readonly IApplicationMySqlDbContext _db;

        public MaterialController(IApplicationMySqlDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Material> objCategories = _db.Material.ToList();
            return View(objCategories);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Material obj)
        {
            _db.Material.Add(obj);
            _db.Save();
            TempData["success"] = "Material criado com sucesso.";
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var materialFromDb = _db.Material.AsNoTracking().Where(c => c.Id == id).FirstOrDefault();

            if (materialFromDb == null)
            {
                return NotFound();
            }
            return View(materialFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Material obj)
        {
            if (ModelState.IsValid)
                 _db.Material.Update(obj);
                   _db.Save();
                 TempData["success"] = "Material editado com sucesso.";
                 return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var materialFromDb = _db.Material.AsNoTracking().Where(c => c.Id == id).FirstOrDefault();

            if (materialFromDb == null)
            {
                return NotFound();
            }
            return View(materialFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            var obj = _db.Material.AsNoTracking().Where(c => c.Id == id).FirstOrDefault();

            if (obj == null)
            {
                return NotFound();
            }
            _db.Material.Remove(obj);
            _db.Save();
            TempData["success"] = "Material apagado com sucesso.";
            return RedirectToAction("Index");
        }
    }
}
