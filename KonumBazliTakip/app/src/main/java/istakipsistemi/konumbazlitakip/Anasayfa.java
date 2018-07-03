package istakipsistemi.konumbazlitakip;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.location.Address;
import android.location.Criteria;
import android.location.Geocoder;
import android.location.Location;
import android.location.LocationManager;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import org.w3c.dom.Text;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.Statement;
import java.util.List;
import java.util.Locale;


public class Anasayfa extends Activity {

    ConnectionClass connectionClass;
    NPersonel sessionPersonel;
    double enlemBilgisi = 0.0;
    double boylamBilgisi = 0.0;
    double firmaEnlem = 0.0;
    double firmaBoylam = 0.0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_anasayfa);

        connectionClass = new ConnectionClass();
        sessionPersonel = new NPersonel();

        //region Kontrol Tanimlamalari
        TextView txtAdSoyad = (TextView)findViewById(R.id.TxtAdSoyad);
        TextView txtUnvan = (TextView)findViewById(R.id.TxtUnvan);
        TextView txtDepartman = (TextView)findViewById(R.id.TxtDepartman);
        TextView txtTelefon = (TextView)findViewById(R.id.TxtTelefon);
        TextView txtMail = (TextView)findViewById(R.id.TxtMail);
        TextView txtVarsayilanGirisSaati = (TextView)findViewById(R.id.TxtVarsayilanGiris);
        TextView txtVarsayilanCikisSaati = (TextView)findViewById(R.id.TxtVarsayilanCikis);
        TextView txtWelcome = (TextView)findViewById(R.id.TxtWelcome);
        TextView txtEnlemBoylam = (TextView)findViewById(R.id.TxtEnlemBoylam);
        TextView txtKonum = (TextView)findViewById(R.id.TxtKonum);
        TextView txtLinkZiyaret = (TextView)findViewById(R.id.TxtLinkZiyaretSayfasi);
        Button btnMesaiGiris = (Button)findViewById(R.id.BtnMesaiGiris);
        Button btnMesaiCikis = (Button)findViewById(R.id.BtnMesaiCikis);
        //endregion

        //region Personelin Bilgilerini Getir
        Intent intent = getIntent();
        String personelTc = intent.getStringExtra("tc");
        try
        {
            Connection con = connectionClass.CONN();
            if (con == null) {
                Toast.makeText(getApplicationContext(), "Veritabani Baglantisi Esnasinda Hata Olustu!", Toast.LENGTH_LONG).show();
            } else {
                String query = "SELECT Personel.personel_tc, Personel.ad, soyad, mail, sifre, telefon, unvan, PersonelDepartman.ad as 'departman', CONVERT(varchar(10), varsayilan_giris_saat, 20) as 'varsayilan_giris_saat', CONVERT(varchar(10), varsayilan_cikis_saat, 20) as 'varsayilan_cikis_saat', (SELECT TOP 1 enlem FROM SirketProfilBilgileri) as 'enlem', (SELECT TOP 1 boylam FROM SirketProfilBilgileri) as 'boylam' FROM Personel JOIN PersonelDepartman ON Personel.departman_id = PersonelDepartman.departman_id WHERE Personel.personel_tc='" + personelTc + "'";
                Statement stmt = con.createStatement();
                ResultSet rs = stmt.executeQuery(query);

                if(rs.next())
                {
                    sessionPersonel.setAd(rs.getString("ad"));
                    sessionPersonel.setMail(rs.getString("mail"));
                    sessionPersonel.setPersonel_tc(rs.getString("personel_tc"));
                    sessionPersonel.setSifre(rs.getString("sifre"));
                    sessionPersonel.setSoyad(rs.getString("soyad"));
                    sessionPersonel.setTelefon(rs.getString("telefon"));
                    sessionPersonel.setUnvan(rs.getString("unvan"));
                    sessionPersonel.setVarsayilan_giris_saat(rs.getString("varsayilan_giris_saat"));
                    sessionPersonel.setVarsayilan_cikis_saat(rs.getString("varsayilan_cikis_saat"));
                    sessionPersonel.setDepartman(rs.getString("departman"));
                    firmaEnlem = rs.getDouble("enlem");
                    firmaBoylam = rs.getDouble("boylam");
                }
            }
        }
        catch(Exception ex)
        {
            Toast.makeText(getApplicationContext(), ex.getMessage(), Toast.LENGTH_LONG).show();
        }
        //endregion

        //region Personel Bilgilerini Label Kontrollerine Aktar
        txtAdSoyad.setText("Ad & Soyad: " + sessionPersonel.getAd() + " " + sessionPersonel.getSoyad());
        txtUnvan.setText("Unvan: " + sessionPersonel.getUnvan());
        txtDepartman.setText("Departman: " + sessionPersonel.getDepartman());
        txtTelefon.setText("Telefon: " + sessionPersonel.getTelefon());
        txtMail.setText("Mail Adresi: " + sessionPersonel.getMail());
        txtVarsayilanGirisSaati.setText("Varsayilan Giris Saati: " + sessionPersonel.getVarsayilan_giris_saat());
        txtVarsayilanCikisSaati.setText("Varsayilan Cikisþþ Saati: " + sessionPersonel.getVarsayilan_cikis_saat());
        txtWelcome.setText("Hosgeldiniz, " + sessionPersonel.getAd() + " " + sessionPersonel.getSoyad());
        //endregion

        //region Konum Bilgilerini Alan Kod Blogu
        String bestProvider = null;
        Geocoder geocoder;
        List<Address> user;
        LocationManager lm = (LocationManager)this.getSystemService(Context.LOCATION_SERVICE);
        Criteria criteria = new Criteria();
        criteria.setAccuracy(Criteria.ACCURACY_COARSE);
        criteria.setAltitudeRequired( false );
        criteria.setBearingRequired( false );
        criteria.setCostAllowed( true );
        criteria.setPowerRequirement( Criteria.POWER_LOW );
        bestProvider = lm.getBestProvider(criteria, true);
        Location location = lm.getLastKnownLocation(bestProvider);
        if (location == null){
            txtEnlemBoylam.setText("Konumunuza Erisilemiyor!");
        }else{
            geocoder = new Geocoder(this, Locale.getDefault());
            try {
                String konum = "Konum: ";
                enlemBilgisi = location.getLatitude();
                boylamBilgisi = location.getLongitude();
                txtEnlemBoylam.setText("Enlem: " + String.format("%.6f", enlemBilgisi) + " Boylam: " + String.format("%.6f", boylamBilgisi));
                user = geocoder.getFromLocation(location.getLatitude(), location.getLongitude(), 1);

                if(user == null || user.size() == 0)
                {
                    konum = konum + " Konum Yok";
                }
                else{
                    Address adresBilgi = user.get(0);
                    konum = konum + " " + String.valueOf(adresBilgi.getMaxAddressLineIndex());

                    if (adresBilgi.getMaxAddressLineIndex() > 0) {
                        for (int i = 0; i < adresBilgi.getMaxAddressLineIndex(); i++) {
                            konum = konum + " " + adresBilgi.getAddressLine(i);
                        }
                    } else {
                        try {
                            konum = konum + " " + adresBilgi.getAddressLine(0);
                        } catch (Exception ignored) {}
                    }
                }

                txtKonum.setText(konum);
            }catch (Exception ex) {
                txtEnlemBoylam.setText(ex.getMessage());
            }
        }
        //endregion

        //region Mesai Giriþi Kaydý Yapan Kod Blogu
        btnMesaiGiris.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                try
                {
                    Connection con = connectionClass.CONN();
                    if (con == null)
                    {

                    }
                    else
                    {
                        double fark = 0.0;
                        fark = FarkHesapla(firmaEnlem,firmaBoylam,enlemBilgisi,boylamBilgisi);

                        String query = "INSERT INTO MesaiKayit(personel_tc, tarih, giris_saat, giris_enlem, giris_boylam, giris_fark) VALUES('"+sessionPersonel.getPersonel_tc()+"', CONVERT(DATE, DATEADD(HOUR, 3, GETUTCDATE())), CONVERT(TIME, DATEADD(HOUR, 3, GETUTCDATE())), '"+enlemBilgisi+"', '"+boylamBilgisi+"', '"+fark+"')";
                        Statement stmt = con.createStatement();
                        stmt.execute(query);

                        //SPLASH EKRANINI ÇALIÞTIR VE ANASAYFAYA DÖN

                        Intent intent = new Intent(Anasayfa.this, Login.class);
                        startActivity(intent);
                    }
                }
                catch (Exception ex)
                {
                    Toast.makeText(getApplicationContext(),ex.getMessage(),Toast.LENGTH_LONG).show();
                }

            }
        });
        //endregion

        //region Mesai Çýkýþý Kaydý Yapan Kod Blogu
        btnMesaiCikis.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                try
                {
                    Connection con = connectionClass.CONN();
                    if (con == null)
                    {

                    }
                    else
                    {
                        double fark = 0.0;
                        fark = FarkHesapla(firmaEnlem,firmaBoylam,enlemBilgisi,boylamBilgisi);

                        String query = "UPDATE MesaiKayit SET cikis_saat = CONVERT(TIME, DATEADD(HOUR, 3, GETUTCDATE())), cikis_enlem = '"+enlemBilgisi+"', cikis_boylam = '"+boylamBilgisi+"', cikis_fark = '"+fark+"', ek_mesai = 10 WHERE personel_tc = '"+sessionPersonel.getPersonel_tc()+"' AND tarih = CONVERT(DATE, DATEADD(HOUR, 3, GETUTCDATE())) AND cikis_saat IS NULL";
                        Statement stmt = con.createStatement();
                        stmt.execute(query);

                        //SPLASH EKRANINI ÇALIÞTIR VE ANASAYFAYA DÖN

                        Intent intent = new Intent(Anasayfa.this, Login.class);
                        startActivity(intent);
                    }
                }
                catch (Exception ex)
                {
                    Toast.makeText(getApplicationContext(),ex.getMessage(),Toast.LENGTH_LONG).show();
                }

            }
        });
        //endregion

        txtLinkZiyaret.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent i = new Intent(Anasayfa.this, ZiyaretKayit.class);
                i.putExtra("tc",sessionPersonel.getPersonel_tc());
                startActivity(i);
            }
        });
    }

    //region Mesafe Farki Hesaplama Kod Blogu
    public double FarkHesapla(double lat1, double lon1, double lat2, double lon2)
    {
        double R = 6371; // Radius of the earth in km
        double dLat = deg2rad(lat2-lat1);  // deg2rad below
        double dLon = deg2rad(lon2-lon1);
        double a =
                Math.sin(dLat / 2) * Math.sin(dLat / 2) +
                        Math.cos(deg2rad(lat1)) * Math.cos(deg2rad(lat2)) *
                                Math.sin(dLon / 2) * Math.sin(dLon / 2)
                ;
        double c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
        double d = R * c; // Distance in km
        return Math.round((d * 1000));
    }
    public double deg2rad(double deg) {
        return deg * (Math.PI / 180);
    }
    //endregion
}
