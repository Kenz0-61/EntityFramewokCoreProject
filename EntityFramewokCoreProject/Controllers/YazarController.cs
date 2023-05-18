using DataAccess.Data;
using DataAccess.Migrations;
using DataModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFramewokCoreProject.Controllers
{
    public class YazarController : Controller
    {
        private readonly ApplicationDbContext _context; //modellere erişebilme için oluşturan nesnedir.

        public YazarController(ApplicationDbContext db)
        {
            _context = db;
        }
        public IActionResult Index()
        {
            List<Yazar> objList = _context.Yazarlar.ToList();
            return View(objList);
        }

        public IActionResult Update_Insert(int? id) //int? parametresi Nullable'da gelebilir.// Http Get İşlemidir.
        {
            Yazar? obj = new();//obj? parametresi Nullable'da gelebilir.

            if (id == null)
            {
                return View(obj);
            }

            obj = _context.Yazarlar.FirstOrDefault(a => a.Yazar_ID == id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [ValidateAntiForgeryToken]//Güvenlik amaçlı attributedür.Client tarafında gönderilecek talepleri sitenin ön yüzünden geldiğini anlamak için kontrol sağlayan bir attributedür. Bot kullanıcılarından vesair gibi yazılımlardan devamlı istek atılma gibi durumları engellemek için kullanılabilinir.
        [HttpPost]
        public IActionResult Update_Insert(Yazar obj)
        {
            if (ModelState.IsValid)//modelstate.isvalid modelin geçerlimi geçersimi olduğu kontrolü yapmaktadır.
            {
                if (obj.Yazar_ID == 0)
                {
                    //Create(Oluşturma)
                    _context.Yazarlar.Add(obj);
                }
                else
                {
                    //Update İşlemi gelmiştir var olan kayıt üzerinde güncelleme işlemi gelmiştir.
                    _context.Yazarlar.Update(obj);
                }
                _context.SaveChanges();//database yansıtma
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Sil(int id)
        {
            var obj = _context.Yazarlar.SingleOrDefault(a => a.Yazar_ID == id);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                _context.Yazarlar.Remove(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }

        }


    }
}
