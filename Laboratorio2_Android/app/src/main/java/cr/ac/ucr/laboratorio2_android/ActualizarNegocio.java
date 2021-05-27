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
import models.Gimnacios;
import models.Login;
import models.RetrofitSingleton;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;

public class ActualizarNegocio extends AppCompatActivity {

    private Button btn;
    String descripcion;
    String horaA;
    String horaB;
    String capacidad;
    String porcentaje;
    private List<Gimnacios> respuesta = new ArrayList<>();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_actualizar_negocio);

        btn = (Button) findViewById(R.id.btn_actualizar);

        btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                EditText etdescri = (EditText)findViewById(R.id.et_descripcion);
                EditText ethoraA = (EditText)findViewById(R.id.ed_horaA);
                EditText ethoraB = (EditText)findViewById(R.id.ethoraB);
                EditText capMax = (EditText)findViewById(R.id.et_capMax);
                EditText porc = (EditText)findViewById(R.id.etPorc);

                descripcion = etdescri.getText().toString();
                horaA = ethoraA.getText().toString();
                horaB = ethoraB.getText().toString();
                capacidad = capMax.getText().toString();
                porcentaje = porc.getText().toString();

//                Toast.makeText(getApplicationContext(), "Nombre:" + nombre + "  Contrasena: "+ contra, Toast.LENGTH_LONG).show();
                actualizaNegocio();

            }
        });

    }


    private void actualizaNegocio() {

        RetrofitSingleton retrofitSingleton = RetrofitSingleton.getInstancia();
        Retrofit retrofit = retrofitSingleton.getRetrofit();

        webapi api = retrofit.create(webapi.class);
        Call<List<Gimnacios>> call  = api.actualizarNegocio(retrofitSingleton.getLogin().getNombre_negocio(),
                descripcion,
                horaA,
                horaB,
                capacidad,
                porcentaje);



        call.enqueue(new Callback<List<Gimnacios>>() {

            @Override
            public void  onResponse(Call<List<Gimnacios>> call, Response<List<Gimnacios>> response) {
                if(response.isSuccessful()) {
                    respuesta = response.body();
                    if(respuesta.size()==0){
                        Toast.makeText(getApplicationContext(), "No se pudo realizar correctamente la actualizacion", Toast.LENGTH_LONG).show();

                    }else{
                        Intent intent = new Intent(getApplicationContext(), InicioAdministrador.class);
                        startActivity(intent);
                    }
                }
            }

            @Override
            public void onFailure(Call<List<Gimnacios>> call, Throwable t) {
//                Toast.makeText(getApplicationContext(), "No existen usuarios con esos valores", Toast.LENGTH_LONG).show();

            }


        });

//
//        Toast.makeText(getApplicationContext(), retrofitSingleton.getLogin().getNombre_negocio()+
//                descripcion+
//                horaA+
//                horaB+
//                capacidad+
//                porcentaje, Toast.LENGTH_LONG).show();


    }//getCountries




}
