package cr.ac.ucr.laboratorio2_android;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;

import interfas.webapi;
import models.Login;
import models.LoginCliente;
import models.RetrofitSingleton;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;

public class LoginClienteActivity extends AppCompatActivity {


    private List<LoginCliente> loginList = new ArrayList<>();
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login_cliente);


        Button btn = (Button) findViewById(R.id.btn_loginCliente);
        btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                EditText text = (EditText) findViewById(R.id.et_loginCliente_nombre);
                String nombre = text.getText().toString();
                EditText text2 = (EditText) findViewById(R.id.et_loginCliente_contrasena);
                String contra = text2.getText().toString();


//                Toast.makeText(getApplicationContext(), "Nombre:" + nombre + "  Contrasena: "+ contra, Toast.LENGTH_LONG).show();
                consultaLoginCliente(nombre, contra);
            }
        });
    }


    private void consultaLoginCliente(String nombre, String contra) {

        RetrofitSingleton retrofitSingleton = RetrofitSingleton.getInstancia();
        Retrofit retrofit = retrofitSingleton.getRetrofit();

        webapi api = retrofit.create(webapi.class);
        Call<List<LoginCliente>> call  = api.getLoginCliente(nombre,contra);
        Toast.makeText(getApplicationContext(), "Espere un momento, se esta consultando a la Base de Datos. ", Toast.LENGTH_LONG).show();


        call.enqueue(new Callback<List<LoginCliente>>() {

            @Override
            public void  onResponse(Call<List<LoginCliente>> call, Response<List<LoginCliente>> response) {
                if(response.isSuccessful()) {
                    loginList = response.body();
                    if(loginList.size()==0){

                        Toast.makeText(getApplicationContext(), "No existen negocios con esos valores", Toast.LENGTH_LONG).show();
                    }else{


                        RetrofitSingleton   singleton = RetrofitSingleton.getInstancia();
                        singleton.setNombreCliente(loginList.get(0).getNombre());
//                        Toast.makeText(getApplicationContext(), " " + loginList.get(0).toString() , Toast.LENGTH_LONG).show();

                        Intent intent = new Intent(getApplicationContext(), StudentsListActivity.class);
                        startActivity(intent);

                        // intent.putExtra("login",loginList.get(0));
                    }
                }
            }

            @Override
            public void onFailure(Call<List<LoginCliente>> call, Throwable t) {
//                Toast.makeText(getApplicationContext(), "No existen usuarios con esos valores", Toast.LENGTH_LONG).show();

            }

        });


    }//getCountries
}
