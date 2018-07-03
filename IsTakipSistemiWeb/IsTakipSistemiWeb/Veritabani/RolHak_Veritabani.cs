using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IsTakipSistemiWeb.Entity;
using IsTakipSistemiWeb.Nesne;
using System.Data;
using System.Data.Entity;

namespace IsTakipSistemiWeb.Veritabani
{
    public class RolHak_Veritabani
    {
        dbIsTakipEntities entity = new dbIsTakipEntities();

        public NIslemSonuc<List<ViewRolHak>> Listele()
        {
            try
            {
                List<ViewRolHak> liste = (from rh in entity.RolHak
                                          join r in entity.Rol on rh.rol_id equals r.rol_id
                                          join h in entity.Hak on rh.hak_id equals h.hak_id
                                          select new ViewRolHak
                                          {
                                              hak_ad = h.ad,
                                              rol_id = r.rol_id,
                                              rol_ad = r.ad,
                                              hak_id = h.hak_id,
                                              link_id = h.link_id,
                                              rolhak_id = rh.rolhak_id,
                                              ust_link_id = h.ust_link_id
                                          }).ToList();

                return new NIslemSonuc<List<ViewRolHak>>
                {
                    basariliMi = true,
                    Veri = liste
                };
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<List<ViewRolHak>>
                {
                    basariliMi = false,
                    hata = new NHata
                    {
                        aciklama = "RolHak Listeleme Hatası",
                        mesaj = ex.Message,
                        sinif = "RolHak Veritabani",
                        strace = ex.StackTrace,
                        tarih = DateTime.Now
                    }
                };
            }
        }
        public NIslemSonuc<List<Rol>> RolListele()
        {
            try
            {
                List<Rol> liste = entity.Rol.ToList();

                return new NIslemSonuc<List<Rol>>
                {
                    basariliMi = true,
                    Veri = liste
                };
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<List<Rol>>
                {
                    basariliMi = false,
                    hata = new NHata
                    {
                        aciklama = "Rol Listeleme Hatası",
                        mesaj = ex.Message,
                        sinif = "RolHak Veritabani",
                        strace = ex.StackTrace,
                        tarih = DateTime.Now
                    }
                };
            }
        }
        public NIslemSonuc<List<Hak>> HakListele()
        {
            try
            {
                List<Hak> liste = entity.Hak.ToList();

                return new NIslemSonuc<List<Hak>>
                {
                    basariliMi = true,
                    Veri = liste
                };
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<List<Hak>>
                {
                    basariliMi = false,
                    hata = new NHata
                    {
                        aciklama = "Hak Listeleme Hatası",
                        mesaj = ex.Message,
                        sinif = "RolHak Veritabani",
                        strace = ex.StackTrace,
                        tarih = DateTime.Now
                    }
                };
            }
        }
        public NIslemSonuc<RolHak> RolHak_Ekle(RolHak data)
        {
            try
            {
                entity.RolHak.Add(data);
                entity.SaveChanges();
                return new NIslemSonuc<RolHak>
                {
                    basariliMi = true,
                    Veri = data,
                    mesaj = "RolHak Ekleme Başarılı"
                };
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<RolHak>
                {
                    basariliMi = false,
                    hata = new NHata
                    {
                        aciklama = "Ekleme Metodunda Hata",
                        mesaj = ex.Message,
                        sinif = "RolHak Veritabani",
                        strace = ex.StackTrace,
                        tarih = DateTime.Now
                    },
                    mesaj = ex.Message
                };
            }
        }
        public NIslemSonuc<int> Role_Ait_Kayitlari_Sil(int rolId)
        {
            try
            {
                entity.RolHak.RemoveRange(entity.RolHak.Where(x => x.rol_id == rolId));
                entity.SaveChanges();
                return new NIslemSonuc<int>
                {
                    basariliMi = true,
                    Veri = rolId,
                    mesaj = "RolHak Silme Başarılı"
                };
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<int>
                {
                    basariliMi = false,
                    hata = new NHata
                    {
                        aciklama = "Silme Metodunda Hata",
                        mesaj = ex.Message,
                        sinif = "RolHak Veritabani",
                        strace = ex.StackTrace,
                        tarih = DateTime.Now
                    },
                    mesaj = ex.Message
                };
            }
        }
    }
}