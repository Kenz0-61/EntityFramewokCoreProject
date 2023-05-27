using DataAccess.Data;
using DataModel.Models;
using DataModel.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EntityFramewokCoreProject.Controllers
{
    public class KitapController : Controller
    {
        private readonly ApplicationDbContext _context; //modellere erişebilme için oluşturan nesnedir.

        public KitapController(ApplicationDbContext db)
        {
            _context = db;
        }
        public IActionResult Index()
        {
            List<Kitap> objList = _context.Kitaplar.ToList();

            foreach (var obj in objList)
            {
                //Uygulanabilir ama server açısından verimli değildir.
                //obj.YayinEvi = _context.YayinEvleri.FirstOrDefault(a => a.YayinEvi_Id == obj.YayinEvi_ID);

                //Uygulanabilir ve server açısından verimlidir.EXPŞICIT LOADING yöntemi... Aynı veriye sahip olanlar için bir tane sorgu yani distinct işlemi yapmış oluyoruz server performaslı calısması için diyebiliriz.

                _context.Entry(obj).Reference(a => a.YayinEvi).Load();
            }
            return View(objList);
        }

        public IActionResult Update_Insert(int? id) //int? parametresi Nullable'da gelebilir.// Http Get İşlemidir.
        {
            KitapVM? obj = new();//obj? parametresi Nullable'da gelebilir.

            obj.YayinEviListesi = _context.YayinEvleri.Select(a => new SelectListItem
            {
                Text = a.YayinEviAdi,
                Value = a.YayinEvi_Id.ToString()
            });

            if (id == null)
            {
                return View(obj);
            }

            //düzenleme

            obj.Kitap = _context.Kitaplar.FirstOrDefault(a => a.KitapId == id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }



        [ValidateAntiForgeryToken]//Güvenlik amaçlı attributedür.Client tarafında gönderilecek talepleri sitenin ön yüzünden geldiğini anlamak için kontrol sağlayan bir attributedür. Bot kullanıcılarından vesair gibi yazılımlardan devamlı istek atılma gibi durumları engellemek için kullanılabilinir.
        [HttpPost]
        public IActionResult Update_Insert(KitapVM obj)
        {


            if (obj.Kitap.KitapId == 0)
            {
                //Create(Oluşturma)
                _context.Kitaplar.Add(obj.Kitap);
            }
            else
            {
                //Update İşlemi gelmiştir var olan kayıt üzerinde güncelleme işlemi gelmiştir.
                _context.Kitaplar.Update(obj.Kitap);
            }
            _context.SaveChanges();//database yansıtma
            return RedirectToAction("Index");
        }

        public IActionResult Sil(int id)
        {
            var obj = _context.Kitaplar.SingleOrDefault(a => a.KitapId == id);

            _context.Kitaplar.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Detaylar(int? id) //int? parametresi Nullable'da gelebilir.// Http Get İşlemidir.
        {
            KitapVM? obj = new();//obj? parametresi Nullable'da gelebilir.



            if (id == null)
            {
                return View(obj);
            }

            //düzenleme

            obj.Kitap = _context.Kitaplar.FirstOrDefault(a => a.KitapId == id);
            obj.Kitap.KitapDetay = _context.KitapDetaylar.FirstOrDefault(a => a.KitapDetayID == obj.Kitap.KitapDetay_ID);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }



        [ValidateAntiForgeryToken]//Güvenlik amaçlı attributedür.Client tarafında gönderilecek talepleri sitenin ön yüzünden geldiğini anlamak için kontrol sağlayan bir attributedür. Bot kullanıcılarından vesair gibi yazılımlardan devamlı istek atılma gibi durumları engellemek için kullanılabilinir.
        [HttpPost]
        public IActionResult Detaylar(KitapVM obj)
        {


            if (obj.Kitap.KitapId == 0)
            {
                //Create(Oluşturma)
                _context.Kitaplar.Add(obj.Kitap);
                _context.SaveChanges();

                var kitapDb = _context.Kitaplar.FirstOrDefault(a=> a.KitapId==obj.Kitap.KitapId);

                kitapDb.KitapDetay_ID = obj.Kitap.KitapDetay_ID;
                _context.SaveChanges();
            }
            else
            {
                //Update İşlemi gelmiştir var olan kayıt üzerinde güncelleme işlemi gelmiştir.
                _context.Kitaplar.Update(obj.Kitap);
                _context.SaveChanges(); 
            }
            
            return RedirectToAction("Index");
        }
    }
}
