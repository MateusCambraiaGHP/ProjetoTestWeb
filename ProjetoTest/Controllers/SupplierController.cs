using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoTest.Interfaces;
using ProjetoTest.Models;

namespace ProjetoTest.Controllers
{
    public class SupplierController : Controller
    {

        public readonly IApplicationMySqlDbContext _db;
        public SupplierController(IApplicationMySqlDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Supplier> objCategories = _db.Supplier.ToList();
            return View(objCategories);
        }
        public IActionResult Create()
        {
            Fill();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Supplier obj)
        {
            obj.QrCode = FormatQrCode(obj);
            _db.Supplier.Add(obj);
            _db.Save();
            TempData["success"] = "Fornecedor criado com sucesso.";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var supplierFromDb = _db.Supplier.AsNoTracking().Where(c => c.Id == id).FirstOrDefault();

            if (supplierFromDb == null)
            {
                return NotFound();
            }
            return View(supplierFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Supplier obj)
        {
            if (ModelState.IsValid)
                FormatQrCode(obj);
                _db.Supplier.Update(obj);
                _db.Save();
                TempData["success"] = "Fornecedor editado com sucesso.";
                return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var supplierFromDb = _db.Supplier.AsNoTracking().Where(c => c.Id == id).FirstOrDefault();

            if (supplierFromDb == null)
            {
                return NotFound();
            }

            return View(supplierFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            var obj = _db.Supplier.AsNoTracking().Where(c => c.Id == id).FirstOrDefault();
            if (ModelState.IsValid)
            _db.Supplier.Remove(obj);
            _db.Save();
            TempData["success"] = "Fornecedor deletado com sucesso.";
            return RedirectToAction("Index");
        }

        public string FormatQrCode(Supplier obj)
        {
            obj.QrCode = obj.QrCode.Replace(SupplierQrCodeVariables.CPNJ, obj.CNPJ)
                .Replace(SupplierQrCodeVariables.CEP, obj.Cep)
                .Replace(SupplierQrCodeVariables.DATACADASTRO, obj.DataCadastro.ToString());
            return obj.QrCode;
        }

        private void Fill()
        {
            ViewBag.QrCodeVariables = new[]
            {
                new SelectListItem { Value = SupplierQrCodeVariables.CPNJ, Text = SupplierQrCodeVariables.CPNJ},
                new SelectListItem { Value = SupplierQrCodeVariables.CEP, Text = SupplierQrCodeVariables.CEP},
                new SelectListItem { Value = SupplierQrCodeVariables.DATACADASTRO, Text = SupplierQrCodeVariables.DATACADASTRO},
                new SelectListItem { Text = $"{SupplierQrCodeVariables.CPNJ} - {SupplierQrCodeVariables.CEP}"},
                new SelectListItem { Text = $"{SupplierQrCodeVariables.CEP} - {SupplierQrCodeVariables.DATACADASTRO}" },
                new SelectListItem { Text = $"{SupplierQrCodeVariables.CPNJ} - {SupplierQrCodeVariables.DATACADASTRO}"},
                new SelectListItem { Text = $"{SupplierQrCodeVariables.CPNJ} - {SupplierQrCodeVariables.CEP} / {SupplierQrCodeVariables.DATACADASTRO}"}
            };
        }
    }
}
