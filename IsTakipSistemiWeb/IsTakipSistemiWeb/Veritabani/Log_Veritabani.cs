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
    public class Log_Veritabani
    {        
        public static void Ekle(Log data)
        {
            try
            {
                dbIsTakipEntities entity = new dbIsTakipEntities();
                entity.Log.Add(data);
                entity.SaveChanges();
            }
            catch(Exception ex)
            {
                
            }
        }       
    }
}