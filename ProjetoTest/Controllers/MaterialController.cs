using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            IEnumerable<Material> objMaterial = _db.Material.AsNoTracking().Include(m => m.Supplier).ToList();
            return View(objMaterial);
        }
        public IActionResult Create()
        {
            Fill();
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
            Fill();
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
            var obj = _db.Material.Where(c => c.Id == id).FirstOrDefault();

            if (obj == null)
            {
                return NotFound();
            }
            _db.Material.Remove(obj);
            _db.Save();
            TempData["success"] = "Material apagado com sucesso.";
            return RedirectToAction("Index");
        }

        private void Fill()
        {
            var suppliers = _db.Supplier.AsNoTracking().ToList();
            ViewBag.Supplier = suppliers.Select(c => new SelectListItem {Value = c.Id.ToString(), Text = c.NameSupplier});
        }
    }
}
