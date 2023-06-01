using DataAccess.Data;
using DataModel.Models;
using DataModel.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
            /* 3 farklı join işlemi kullanılmıştır.EFCore İçin
                1. Yöntem: Eager Loading Yöntemi (Include) en performanslı yöntemdir.*/
            List<Kitap> objList = _context.Kitaplar.Include(a => a.YayinEvi).ToList();

            /* foreach (var obj in objList)
            {
             2. Yöntem: Uygulanabilir ama server açısından verimli değildir. YayınEvinin sayısı kadar sorgusu server'da çalıştırılır.

                obj.YayinEvi = _context.YayinEvleri.FirstOrDefault(a => a.YayinEvi_Id == obj.YayinEvi_ID);

                //3. Yöntem: Uygulanabilir ve server açısından verimlidir.EXPLICIT LOADING yöntemi... Aynı veriye sahip olanlar için bir tane sorgu yani distinct işlemi yapmış oluyoruz server performaslı calısması için diyebiliriz. Kaçtane farklı yayın evi varsa okadar sorgu çekmektedir.

                _context.Entry(obj).Reference(a => a.YayinEvi).Load();
            } */
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
            //1.Yöntem: Eager Loading Yöntemi(Include) en performanslı yöntemdir.
            obj.Kitap = _context.Kitaplar.Include(a => a.KitapDetay).FirstOrDefault(a => a.KitapId == id);
            //obj.Kitap.KitapDetay = _context.KitapDetaylar.FirstOrDefault(a => a.KitapDetayID == obj.Kitap.KitapDetay_ID);

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


            if (obj.Kitap.KitapDetay_ID == 0 || obj.Kitap.KitapDetay_ID == null)
            {
                //Create(Oluşturma)
                _context.KitapDetaylar.Add(obj.Kitap.KitapDetay);
                _context.SaveChanges();

                var kitapDb = _context.Kitaplar.FirstOrDefault(a => a.KitapId == obj.Kitap.KitapId);

                kitapDb.KitapDetay_ID = obj.Kitap.KitapDetay.KitapDetayID;
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

        public IActionResult ABC()
        {
            /*SELECT [k].[KitapId], [k].[Fiyat], [k].[ISBN], [k].[Kategori_ID], [k].[KitapAdi], [k].[KitapDetay_ID], [k].[YayinEvi_ID]
                FROM [Kitaplar] AS [k]*/

            //Ienumearable ile refere edilen instance her ne kadar kod tarafında efcore where methodunu kullansakta  tarayıcı memory'de filtreleme yapar database'de filtrleme yapmaz buda performas sorunları ortaya cıkararır. Yukarıda databse'de oluşturduğu sorgu output pencersinden alınıp eklenmiştir...

            IEnumerable<Kitap> KitapListesi1 = _context.Kitaplar;
            var filtreleme1 = KitapListesi1.Where(a => a.Fiyat > 25).ToList();

            /*SELECT [k].[KitapId], [k].[Fiyat], [k].[ISBN], [k].[Kategori_ID], [k].[KitapAdi], [k].[KitapDetay_ID], [k].[YayinEvi_ID]
                FROM [Kitaplar] AS [k]
            //    WHERE [k].[Fiyat] > 25.0E0*/

            //Iqueryable database'de filtreleme yapar. Sunucuya performans sağlar. Yukarıda databse'de oluşturduğu sorgu output pencersinden alınıp eklenmiştir...

            IQueryable<Kitap> KitapListesi2 = _context.Kitaplar;
            var filtreleme2 = KitapListesi2.Where(a => a.Fiyat > 25).ToList();

            return RedirectToAction("Index");

        }
    }
}
