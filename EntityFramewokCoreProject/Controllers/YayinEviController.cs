using DataAccess.Data;
using DataAccess.Migrations;
using DataModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFramewokCoreProject.Controllers
{
    public class YayinEviController : Controller
    {
        private readonly ApplicationDbContext _context; //modellere erişebilme için oluşturan nesnedir.

        public YayinEviController(ApplicationDbContext db)
        {
            _context = db;
        }
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Update_Insert(int? id) //int? parametresi Nullable'da gelebilir.// Http Get İşlemidir.
        {
            
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Update_Insert(Kategori obj)
        {
            
                return RedirectToAction("Index");
            
            
        }

        public IActionResult Sil(int id)
        {
            
                return RedirectToAction("Index");

            

        }

        
    }
}
