package cr.ac.ucr.laboratorio2_android;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.content.Context;
import android.os.Bundle;
import android.view.View;
import android.widget.DatePicker;
import android.widget.ImageView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;

import adapters.SesionesClienteListAdapter;
import adapters.SesionesListAdapter;
import interfas.webapi;
import models.RetrofitSingleton;
import models.Sesiones;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;

public class SecionesClienteActivity extends AppCompatActivity {


    private DatePicker picker;
    private ImageView iv_Play;
    private RecyclerView sesiones_list;
    Context context_;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_seciones_cliente);
        context_ = this;

        iv_Play = (ImageView) findViewById(R.id.ic_playSecionesCliente);
        picker=(DatePicker)findViewById(R.id.dp_cliente_sesiones);

        iv_Play.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                String salida =picker.getDayOfMonth()+ "-" + (picker.getMonth() + 1 )+"-"+ picker.getYear();
                Toast.makeText(getApplicationContext(), salida , Toast.LENGTH_LONG).show();
                getSeciones(salida);
            }
        });



    }



    private void getSeciones(String fecha) {

        RetrofitSingleton retrofitSingleton = RetrofitSingleton.getInstancia();
        Retrofit retrofit = retrofitSingleton.getRetrofit();

        webapi api = retrofit.create(webapi.class);
        Call<List<Sesiones>> call  = api.getSecionesAPI(retrofitSingleton.getGimnacioCliente(), fecha);

        call.enqueue(new Callback<List<Sesiones>>() {

            @Override
            public void  onResponse(Call<List<Sesiones>> call, Response<List<Sesiones>> response) {
//
                if(response.isSuccessful()) {

                    List<Sesiones> sesionesList = new ArrayList<>();
                    sesionesList = response.body();
//
                    sesiones_list = findViewById(R.id.sesionesCliente_list_recycler);

                    SesionesClienteListAdapter adapter = new SesionesClienteListAdapter(sesionesList, context_);
                    sesiones_list.setLayoutManager(new LinearLayoutManager(context_));
                    sesiones_list.setAdapter(adapter);

                }


            }

            @Override
            public void onFailure(Call<List<Sesiones>> call, Throwable t) {

            }


        });


    }//getCountries





}
