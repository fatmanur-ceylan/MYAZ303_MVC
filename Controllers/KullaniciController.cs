using Microsoft.AspNetCore.Mvc;
using MVC_Odev.Model;
using MVC_Odev.Repository;

namespace MVC_Odev.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly KullaniciDbContext _dbSet;

        public KullaniciController(KullaniciDbContext dbSet)
        {
            _dbSet = dbSet;
        }

        public IActionResult Index()
        {
            IEnumerable<Kullanici> objKullaniciList = _dbSet.Kullanici;
            return View(objKullaniciList);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Kullanici obj)
        {
            if (ModelState.IsValid)
            {
                _dbSet.Kullanici.Add(obj);
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
            var kullaniciFromDb = _dbSet.Kullanici.Find(id);


            if (kullaniciFromDb == null)
            {
                return NotFound();
            }

            return View(kullaniciFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Kullanici obj)
        {

            if (ModelState.IsValid)
            {

                _dbSet.Kullanici.Update(obj);
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

            var kullaniciFromDb = _dbSet.Kullanici.Find(id);
            if (kullaniciFromDb == null)
            {
                return NotFound();
            }
            return View(kullaniciFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _dbSet.Kullanici.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _dbSet.Kullanici.Remove(obj);
            _dbSet.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}

