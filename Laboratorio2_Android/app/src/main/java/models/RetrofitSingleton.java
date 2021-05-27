package models;


import java.util.List;

import okhttp3.OkHttpClient;
import okhttp3.logging.HttpLoggingInterceptor;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class RetrofitSingleton {

    //variables
    private static RetrofitSingleton instancia;
    private Retrofit retrofit;
    private Login login;
    private String nombreCliente;
    private String gimnacioCliente;
    private String pais;
    List<Reservas> reservasList;

    public  static RetrofitSingleton getInstancia() {

        if (instancia==null) {

            instancia=new RetrofitSingleton();
        }
        return instancia;
    }//getInstancia

    private RetrofitSingleton(){

//        HttpLoggingInterceptor logging = new HttpLoggingInterceptor();
//        logging.setLevel(HttpLoggingInterceptor.Level.BODY);
//
//        // Asociamos el interceptor a las peticiones
//        OkHttpClient.Builder httpClient = new OkHttpClient.Builder();
//        httpClient.addInterceptor(logging);

       retrofit = new Retrofit.Builder()
                  .baseUrl("https://webapiproyectotresluisjasson.azurewebsites.net/")
                  .addConverterFactory(GsonConverterFactory.create())
//                  .client(httpClient.build()) // <-- usamos el log level
                  .build();

        pais="";
    }//constructor


    //gets and sets


    public List<Reservas> getReservasList() {
        return reservasList;
    }

    public void setReservasList(List<Reservas> reservasList) {
        this.reservasList = reservasList;
    }

    public String getGimnacioCliente() {
        return gimnacioCliente;
    }

    public void setGimnacioCliente(String gimnacioCliente) {
        this.gimnacioCliente = gimnacioCliente;
    }

    public String getNombreCliente() {
        return nombreCliente;
    }

    public void setNombreCliente(String nombreCliente) {
        this.nombreCliente = nombreCliente;
    }

    public Retrofit getRetrofit() {
        return retrofit;
    }

    public void setRetrofit(Retrofit retrofit) {
        this.retrofit = retrofit;
    }

    public String getPais() {
        return pais;
    }

    public void setPais(String pais) {
        this.pais = pais;
    }

    public Login getLogin() {
        return login;
    }

    public void setLogin(Login login) {
        this.login = login;
    }
}//class
