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
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;
import java.util.Locale;


public class ZiyaretKayit extends Activity {

    ConnectionClass connectionClass;
    NPersonel sessionPersonel;
    double enlemBilgisi = 0.0;
    double boylamBilgisi = 0.0;
    double firmaEnlem = 0.0;
    double firmaBoylam = 0.0;
    String secilen_firma;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_ziyaret_kayit);

        connectionClass = new ConnectionClass();
        sessionPersonel = new NPersonel();

        //region Kontrol Tanimlamalari
        TextView txtAdSoyad = (TextView)findViewById(R.id.TxtAdSoyad);
        TextView txtUnvan = (TextView)findViewById(R.id.TxtUnvan);
        TextView txtDepartman = (TextView)findViewById(R.id.TxtDepartman);
        TextView txtTelefon = (TextView)findViewById(R.id.TxtTelefon);
        TextView txtWelcome = (TextView)findViewById(R.id.TxtWelcome);
        TextView txtEnlemBoylam = (TextView)findViewById(R.id.TxtEnlemBoylam);
        TextView txtKonum = (TextView)findViewById(R.id.TxtKonum);
        TextView txtLinkZiyaret = (TextView)findViewById(R.id.TxtLinkZiyaretSayfasi);
        Spinner spnFirma = (Spinner) findViewById(R.id.CmbFirmalar);
        Button btnMesaiGiris = (Button)findViewById(R.id.BtnMesaiGiris);
        List<String> liste_firma = new ArrayList<>();
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

        //region Firma Listesini Getiren Kod Blogu
        try{
            Connection con = connectionClass.CONN();
            String query2 = "SELECT Firma.firma_id, Firma.kisa_ad FROM Firma JOIN [Is] ON Firma.firma_id = [Is].firma_id JOIN IsPersonelOrtak ON [Is].is_id = IsPersonelOrtak.is_id JOIN Personel ON IsPersonelOrtak.personel_tc = Personel.personel_tc WHERE Personel.personel_tc = '"+sessionPersonel.getPersonel_tc()+"'";
            Statement stmt2 = con.createStatement();
            ResultSet rs2 = stmt2.executeQuery(query2);

            liste_firma.clear();
            liste_firma.add("Firma Seciniz..");

            while(rs2.next())
            {
                liste_firma.add(rs2.getString(1) + ": " + rs2.getString(2));
            }

            ArrayAdapter aa = new ArrayAdapter(this,R.layout.spinner_item, liste_firma);


            aa.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
            spnFirma.setAdapter(aa);
        }
        catch (Exception ex)
        {

        }
        //endregion

        spnFirma.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                secilen_firma = parent.getItemAtPosition(position).toString();
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });

        btnMesaiGiris.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                String[] ayir = secilen_firma.split(":");
                String secilenId = ayir[0].toString();
                int secilenFirmaId = Integer.parseInt(secilenId);

                try
                {
                    Connection con22 = connectionClass.CONN();
                    if (con22 == null) {
                        Toast.makeText(getApplicationContext(), "Veritabani Baglantisi Esnasinda Hata Olustu!", Toast.LENGTH_LONG).show();
                    } else {
                        String query22 = "SELECT enlem,boylam FROM Firma WHERE firma_id = '"+secilenId+"'";
                        Statement stmt22 = con22.createStatement();
                        ResultSet rs22 = stmt22.executeQuery(query22);

                        if(rs22.next())
                        {
                            firmaEnlem = rs22.getDouble("enlem");
                            firmaBoylam = rs22.getDouble("boylam");
                        }
                    }
                }
                catch(Exception ex)
                {
                    Toast.makeText(getApplicationContext(), ex.getMessage(), Toast.LENGTH_LONG).show();
                }

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
                        String query = "INSERT INTO Ziyaret(tur_id, firma_id, personel_tc, enlem, boylam, giris_tarih, giris_fark) VALUES(4, '"+secilenFirmaId+"', '"+sessionPersonel.getPersonel_tc()+"', '"+enlemBilgisi+"', '"+boylamBilgisi+"', CONVERT(DATE, DATEADD(HOUR, 3, GETUTCDATE())), '"+fark+"')";
                        Statement stmt = con.createStatement();
                        stmt.execute(query);

                        //SPLASH EKRANINI ÇALIÞTIR VE ANASAYFAYA DÖN

                        Intent intent = new Intent(ZiyaretKayit.this, Login.class);
                        startActivity(intent);
                    }
                }
                catch (Exception ex)
                {
                    Toast.makeText(getApplicationContext(),ex.getMessage(),Toast.LENGTH_LONG).show();
                }

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
