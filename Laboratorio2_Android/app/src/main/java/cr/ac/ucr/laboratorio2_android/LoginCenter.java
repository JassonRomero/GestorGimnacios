package cr.ac.ucr.laboratorio2_android;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.Toast;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

import adapters.GimnaciosListAdapter;
import interfas.webapi;
import models.Gimnacios;
import models.Login;
import models.RetrofitSingleton;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;

public class LoginCenter extends AppCompatActivity  {


    private Button btn;
    private List<Login> loginList = new ArrayList<>();
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login_center);

        btn = (Button) findViewById(R.id.btn_login);

        btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
//                Intent intent = new Intent(getApplicationContext(), StudentsListActivity.class);
//                startActivity(intent);

                EditText text2 = (EditText)findViewById(R.id.et_contra);
                String contra = text2.getText().toString();
                EditText text = (EditText)findViewById(R.id.et_name);
                String nombre = text.getText().toString();
//                Toast.makeText(getApplicationContext(), "Nombre:" + nombre + "  Contrasena: "+ contra, Toast.LENGTH_LONG).show();
                consultaLoginAdmi(nombre,contra);
//                Toast.makeText(getApplicationContext(), "Hola mundo" , Toast.LENGTH_LONG).show();


            }
        });

    }

    private void consultaLoginAdmi(String nombre, String contra) {

        RetrofitSingleton retrofitSingleton = RetrofitSingleton.getInstancia();
        Retrofit retrofit = retrofitSingleton.getRetrofit();

        webapi api = retrofit.create(webapi.class);
//        Call<List<Login>> call  = api.getLogin();

        Call<List<Login>> call  = api.getLogin(nombre,contra);
//        Call<List<Login>> call  = api.getLogResúmenes:in("Snake","123");
        Toast.makeText(getApplicationContext(), "Espere un momento, gracias. ", Toast.LENGTH_LONG).show();


        call.enqueue(new Callback<List<Login>>() {

            @Override
            public void  onResponse(Call<List<Login>> call, Response<List<Login>> response) {
                if(response.isSuccessful()) {
                    loginList = response.body();
                    if(loginList.size()==0){

                        Toast.makeText(getApplicationContext(), "No existen negocios con esos valores", Toast.LENGTH_LONG).show();
                    }else{
//                        Toast.makeText(getApplicationContext(), "EXITO!", Toast.LENGTH_LONG).show();

//                        Login login = loginList.get(0);

                        RetrofitSingleton   singleton = RetrofitSingleton.getInstancia();
                        singleton.setLogin(loginList.get(0));
//                        Toast.makeText(getApplicationContext(), " " + loginList.get(0).toString() , Toast.LENGTH_LONG).show();


                        Intent intent = new Intent(getApplicationContext(), InicioAdministrador.class);
                        startActivity(intent);

                        // intent.putExtra("login",loginList.get(0));
                    }
                }
            }

            @Override
            public void onFailure(Call<List<Login>> call, Throwable t) {
//                Toast.makeText(getApplicationContext(), "No existen usuarios con esos valores", Toast.LENGTH_LONG).show();

            }


        });


    }//getCountries



}
