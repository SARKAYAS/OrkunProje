using BL.Session;
using DAL.Entities;
using DAL.Repository;
using OrkunProje.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrkunProje.Controllers
{
    [Oturum]
    public class SepetController : Repository<Sepet>
    {
        public SepetController()
        {
        }

        public ActionResult Index()
        {
            if (SessionKontrol.Kontrol == null)
            {
                // Kullanıcı girişi yapılmamışsa, giriş yapılması için uyarma ekranı göster
                TempData["Uyari"] = "Sepete girebilmek için giriş yapmalısınız.";
                return RedirectToAction("Giris", "Hesap"); // Örnek bir giriş sayfası adı ve controller adı
            }

            // Sepetteki tüm ürünleri al
            var sepetler = GetWhere<Sepet>(s => s.KullaniciId == SessionKontrol.Kontrol.Id);
            decimal toplamFiyat = 0;

            // Toplam fiyatı hesaplamak için bir değişken oluştur

            // Her ürün için fiyatı topla
            foreach (var sepet in sepetler)
            {
                // Ürün fiyatını al ve adet ile çarp, toplam fiyata ekle
                toplamFiyat += sepet.Olta.Fiyat * sepet.Adet;
            }

            // View'a toplam fiyatı ve sepeti gönder
            ViewBag.ToplamFiyat = toplamFiyat;

            return View(sepetler);
        }

        public ActionResult Ekle(int id)
        {
            Sepet sepet = new Sepet();
            sepet.Adet = 1;
            sepet.OltaId = id;
            sepet.KullaniciId = SessionKontrol.Kontrol.Id;

            Sepet sepettekiUrun = GetById(s => s.KullaniciId == SessionKontrol.Kontrol.Id && s.OltaId == id);
            if (sepettekiUrun != null)
            {
                sepettekiUrun.Adet++;
                Save();
            }
            else
            {


                Add(sepet);
            }

            ViewBag.ToplamAdet = sepet.Adet;

            return RedirectToAction("Index");
        }



        public ActionResult Sil(int id)
        {
            Sepet sepet = GetById(s => s.Id == id);
            //decimal fiyatDususu = sepet.Olta.Fiyat * sepet.Adet; // Silinen ürünün fiyatının toplam fiyattan düşülmesi için

            Remove(sepet);
           // toplamFiyat -= fiyatDususu;

            return RedirectToAction("Index");
        }

     
    }
}