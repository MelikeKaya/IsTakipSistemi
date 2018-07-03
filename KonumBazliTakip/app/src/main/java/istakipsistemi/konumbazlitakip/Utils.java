package istakipsistemi.konumbazlitakip;

import android.content.ContentProvider;
import android.content.Context;
import android.net.ConnectivityManager;
import android.provider.Settings;

public class Utils {

    public static boolean CheckInternetConnection(Context context)
    {
        ConnectivityManager cm = (ConnectivityManager) context.getSystemService(Context.CONNECTIVITY_SERVICE);
        return cm.getActiveNetworkInfo() != null && cm.getActiveNetworkInfo().isConnectedOrConnecting();
    }

    public static boolean CheckLocationProvider(Context context)
    {
        String locationProviders = Settings.Secure.getString(context.getContentResolver(), Settings.Secure.LOCATION_PROVIDERS_ALLOWED);
        if (locationProviders == null || locationProviders.equals("")) {
            return false;
        }
        return true;
    }

}
