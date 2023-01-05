using Microsoft.AspNetCore.Mvc;
using MVC_Odev.Model;
using MVC_Odev.Repository;

namespace MVC_Odev.Controllers
{
    public class AdminController : Controller
    {
        private readonly KullaniciDbContext _dbSet;

        public AdminController(KullaniciDbContext dbSet)
        {
            _dbSet = dbSet;
        }

        public IActionResult Index()
        {
            IEnumerable<Admin> objAdminList = _dbSet.Admin;
            return View(objAdminList);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Admin obj)
        {
            if (ModelState.IsValid)
            {
                _dbSet.Admin.Add(obj);
                _dbSet.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var adminFromDb = _dbSet.Admin.Find(id);


            if (adminFromDb == null)
            {
                return NotFound();
            }

            return View(adminFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Admin obj)
        {

            if (ModelState.IsValid)
            {

                _dbSet.Admin.Update(obj);
                _dbSet.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var adminFromDb = _dbSet.Admin.Find(id);
            if (adminFromDb == null)
            {
                return NotFound();
            }
            return View(adminFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _dbSet.Admin.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _dbSet.Admin.Remove(obj);
            _dbSet.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
