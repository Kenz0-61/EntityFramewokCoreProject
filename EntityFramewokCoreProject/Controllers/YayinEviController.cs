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
            List<YayinEvi> objList = _context.YayinEvleri.ToList();
            return View(objList);
        }

        public IActionResult Update_Insert(int? id) //int? parametresi Nullable'da gelebilir.// Http Get İşlemidir.
        {
            YayinEvi? obj = new();//obj? parametresi Nullable'da gelebilir.

            if (id == null)
            {
                return View(obj);
            }

            obj = _context.YayinEvleri.FirstOrDefault(a => a.YayinEvi_Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [ValidateAntiForgeryToken]//Güvenlik amaçlı attributedür.Client tarafında gönderilecek talepleri sitenin ön yüzünden geldiğini anlamak için kontrol sağlayan bir attributedür. Bot kullanıcılarından vesair gibi yazılımlardan devamlı istek atılma gibi durumları engellemek için kullanılabilinir.
        [HttpPost]
        public IActionResult Update_Insert(YayinEvi obj)
        {
            if (ModelState.IsValid)//modelstate.isvalid modelin geçerlimi geçersimi olduğu kontrolü yapmaktadır.
            {
                if (obj.YayinEvi_Id == 0)
                {
                    //Create(Oluşturma)
                    _context.YayinEvleri.Add(obj);
                }
                else
                {
                    //Update İşlemi gelmiştir var olan kayıt üzerinde güncelleme işlemi gelmiştir.
                    _context.YayinEvleri.Update(obj);
                }
                _context.SaveChanges();//database yansıtma
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Sil(int id)
        {
            var obj = _context.YayinEvleri.SingleOrDefault(a => a.YayinEvi_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                _context.YayinEvleri.Remove(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }

        }


    }
}
