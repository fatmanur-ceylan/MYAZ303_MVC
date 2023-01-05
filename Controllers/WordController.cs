using Microsoft.AspNetCore.Mvc;
using MVC_Odev.Model;
using MVC_Odev.Repository;

namespace MVC_Odev.Controllers
{
    public class WordController : Controller
    {
        private readonly KullaniciDbContext _dbSet;

        public WordController(KullaniciDbContext dbSet)
        {
            _dbSet = dbSet;
        }

        public IActionResult Index()
        {
            IEnumerable<Word> objWordList = _dbSet.Word;
            return View(objWordList);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Word obj)
        {
            if (ModelState.IsValid)
            {
                _dbSet.Word.Add(obj);
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
            var wordFromDb = _dbSet.Word.Find(id);


            if (wordFromDb == null)
            {
                return NotFound();
            }

            return View(wordFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Word obj)
        {

            if (ModelState.IsValid)
            {

                _dbSet.Word.Update(obj);
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

            var wordFromDb = _dbSet.Word.Find(id);
            if (wordFromDb == null)
            {
                return NotFound();
            }
            return View(wordFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _dbSet.Word.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _dbSet.Word.Remove(obj);
            _dbSet.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
