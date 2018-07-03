package istakipsistemi.konumbazlitakip;

import android.app.Activity;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.ProgressBar;
import android.widget.Toast;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.Statement;


public class Login extends Activity {

    ConnectionClass connectionClass;
    private static final String UserInfo = "UserInfo";
    public boolean KullaniciSharedKayitDurumu = false;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        connectionClass = new ConnectionClass();

        //region Kontrol Tanimlamalari
        ProgressBar pbbar = (ProgressBar) findViewById(R.id.ProgressLogin);
        EditText edtKullaniciAdi = (EditText) findViewById(R.id.TxtKullaniciAd);
        EditText edtSifre = (EditText) findViewById(R.id.TxtSifre);
        CheckBox chkHatirla = (CheckBox) findViewById(R.id.ChkHatirla);
        Button btnLogin = (Button) findViewById(R.id.BtnLogin);
        pbbar.setVisibility(View.GONE);
        //endregion

        //region Shared Preferences Ile Veri Al
        SharedPreferences preferences = getSharedPreferences(UserInfo, MODE_PRIVATE);
        SharedPreferences.Editor editor = preferences.edit();

        String kaydedilmisKullaniciAdi = preferences.getString("kaydedilmisKullaniciAdi", "");
        String kaydedilmisSifre = preferences.getString("kaydedilmisSifre","");

        if(kaydedilmisKullaniciAdi.equals(""))
        {
            KullaniciSharedKayitDurumu = false;
        } else {
            edtKullaniciAdi.setText(kaydedilmisKullaniciAdi);
            edtSifre.setText(kaydedilmisSifre);
            KullaniciSharedKayitDurumu = true;
        }
        //endregion

        btnLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(Utils.CheckInternetConnection(getApplicationContext()))
                {
                    if(Utils.CheckLocationProvider(getApplicationContext()))
                    {
                        DoLogin doLogin = new DoLogin();
                        doLogin.execute("");
                    }
                    else{
                        Toast.makeText(getApplicationContext(), "Lutfen Konumuzunu Aciniz!", Toast.LENGTH_LONG).show();
                    }
                }
                else{
                    Toast.makeText(getApplicationContext(), "Internet Baglantisi Bulunamadi!", Toast.LENGTH_LONG).show();
                }
            }
        });
    }

    public class DoLogin extends AsyncTask<String, String, String>
    {
        String z = "";
        Boolean isSuccess = false;
        EditText edtKullaniciAdi = (EditText) findViewById(R.id.TxtKullaniciAd);
        EditText edtSifre = (EditText) findViewById(R.id.TxtSifre);
        CheckBox chkHatirla = (CheckBox) findViewById(R.id.ChkHatirla);
        String userid = edtKullaniciAdi.getText().toString();
        String password = edtSifre.getText().toString();

        @Override
        protected void onPreExecute() {
            super.onPreExecute();
            ProgressBar pbbar = (ProgressBar) findViewById(R.id.ProgressLogin);
            pbbar.setVisibility(View.VISIBLE);
        }

        @Override
        protected void onPostExecute(String s) {
            super.onPostExecute(s);
            ProgressBar pbbar = (ProgressBar) findViewById(R.id.ProgressLogin);
            pbbar.setVisibility(View.GONE);
            Toast.makeText(Login.this,s,Toast.LENGTH_SHORT).show();
            if(isSuccess) {
                if(KullaniciSharedKayitDurumu == false)
                {
                    if(chkHatirla.isChecked())
                    {
                        SharedPreferences preferences = getSharedPreferences(UserInfo, MODE_PRIVATE);
                        SharedPreferences.Editor editor = preferences.edit();
                        editor.putString("kaydedilmisKullaniciAdi", userid);
                        editor.putString("kaydedilmisSifre", password);
                        editor.apply();
                    }
                }

                Intent i = new Intent(Login.this, Anasayfa.class);
                i.putExtra("tc",edtKullaniciAdi.getText().toString());
                startActivity(i);
                finish();
            }
        }

        @Override
        protected String doInBackground(String... params) {
            if(userid.trim().equals("")|| password.trim().equals(""))
                z = "Lutfen Bos Alan Birakmayiniz!";
            else
            {
                try {
                    Connection con = connectionClass.CONN();
                    if (con == null) {
                        z = "Veritabani Baglantisi Esnasinda Hata Olustu!";
                    } else {
                        String query = "SELECT * FROM Personel WHERE personel_tc='" + userid + "' AND sifre='" + password + "' AND silindi_mi = 0";
                        Statement stmt = con.createStatement();
                        ResultSet rs = stmt.executeQuery(query);

                        if(rs.next())
                        {
                            z = "Giris Basarili, Yonlendiriliyor..";
                            isSuccess=true;
                        }
                        else
                        {
                            z = "Yanlis Kullanici Adi veya Sifre";
                            isSuccess = false;
                        }

                    }
                }
                catch (Exception ex)
                {
                    isSuccess = false;
                    z = ex.getMessage();
                }
            }
            return z;
        }
    }


}
