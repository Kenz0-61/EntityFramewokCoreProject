using DataAccess.Data;
using DataAccess.Migrations;
using DataModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFramewokCoreProject.Controllers
{
    public class KategoriController : Controller
    {
        private readonly ApplicationDbContext _context; //modellere erişebilme için oluşturan nesnedir.

        public KategoriController(ApplicationDbContext db)
        {
            _context = db;
        }
        public IActionResult Index()
        {
            List<Kategori> objList = _context.Kategoriler.ToList();
            return View(objList);
        }

        public IActionResult Update_Insert(int? id) //int? parametresi Nullable'da gelebilir.// Http Get İşlemidir.
        {
            Kategori obj = new();
            if (id == null)
            {
                return View(obj);
            }

            obj = _context.Kategoriler.FirstOrDefault(a => a.KategoriId == id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [ValidateAntiForgeryToken]//Güvenlik amaçlı attributedür.Client tarafında gönderilecek talepleri sitenin ön yüzünden geldiğini anlamak için kontrol sağlayan bir attributedür. Bot kullanıcılarından vesair gibi yazılımlardan devamlı istek atılma gibi durumları engellemek için kullanılabilinir.
        [HttpPost]
        public IActionResult Update_Insert(Kategori obj)
        {
            if (ModelState.IsValid)//modelstate.isvalid modelin geçerlimi geçersimi olduğu kontrolü yapmaktadır.
            {
                if (obj.KategoriId == 0)
                {
                    //Create(Oluşturma)
                    _context.Kategoriler.Add(obj);
                }
                else
                {
                    //Update İşlemi gelmiştir var olan kayıt üzerinde güncelleme işlemi gelmiştir.
                    _context.Kategoriler.Update(obj);
                }
                _context.SaveChanges();//database yansıtma
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Sil(int id)
        {
            var obj = _context.Kategoriler.SingleOrDefault(a => a.KategoriId == id);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                _context.Kategoriler.Remove(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }

        }

        public IActionResult CokluEkleme3()
        {
            List<Kategori> kategoriListesi = new();

            for (int i = 0; i < 3; i++)
            {
                kategoriListesi.Add(new Kategori { KategoriAdi = Guid.NewGuid().ToString() });
            }

            _context.Kategoriler.AddRange(kategoriListesi);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult CokluEkleme10()
        {
            List<Kategori> kategoriListesi = new();

            for (int i = 0; i <= 10; i++)
            {
                kategoriListesi.Add(new Kategori { KategoriAdi = Guid.NewGuid().ToString() });
            }

            _context.Kategoriler.AddRange(kategoriListesi);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult CokluSilme3()
        {
            IEnumerable<Kategori> kategoriListesi = _context.Kategoriler.OrderByDescending(a => a.KategoriId).Take(3).ToList();

            /*IQueryable<Kategori> kategoriListesi = _context.Kategoriler.FromSql($"Select top 3 * from tbl_Kategori order by KategoriId desc");*/
            // FromSql methodu formattableStrng referans tipinde bir paramaetre değer istemektedir. Bu formattablestring referance tipini string interpolation beraber kullanılması gerekliliğini bildirmektedir. ('$' dolar işaretini kullanarak stringimizi yazmamız gereklidir.)


            _context.Kategoriler.RemoveRange(kategoriListesi);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult CokluSilme10()
        {
            IEnumerable<Kategori> kategoriListesi = _context.Kategoriler.OrderByDescending(a => a.KategoriId).Take(10).ToList();

            _context.Kategoriler.RemoveRange(kategoriListesi);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
