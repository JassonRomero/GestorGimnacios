package cr.ac.ucr.laboratorio2_android;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.ImageView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;

import adapters.ReservaListAdapter;
import adapters.SesionesListAdapter;
import interfas.webapi;
import models.Reservas;
import models.RetrofitSingleton;
import models.Sesiones;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;

public class Reservas_Cliente_Activity extends AppCompatActivity {


    private Button btn;
    private DatePicker picker1;
    private DatePicker picker2;
    private Context context_;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_reservas__cliente_);
        context_= this;

        btn = (Button) findViewById(R.id.btn_reservas);
        picker1=(DatePicker)findViewById(R.id.dp_fechaInicio_recerva);
        picker2=(DatePicker)findViewById(R.id.dp_fechaInicio_recerva2);

        btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                String fechaIncio =picker1.getDayOfMonth()+ "-" + (picker1.getMonth() + 1 )+"-"+ picker1.getYear();
                String fechaFin =picker2.getDayOfMonth()+ "-" + (picker2.getMonth() + 1 )+"-"+ picker2.getYear();
                Toast.makeText(getApplicationContext(), fechaIncio  + "-" + fechaFin , Toast.LENGTH_LONG).show();
                getHistorial(fechaIncio, fechaFin);
//                Intent intent = new Intent(getApplicationContext(), SecionesClienteActivity.class);
//                startActivity(intent);

            }
        });



    }



    private void getHistorial(String fechaI, String fechaF) {

        RetrofitSingleton retrofitSingleton = RetrofitSingleton.getInstancia();
        Retrofit retrofit = retrofitSingleton.getRetrofit();

        webapi api = retrofit.create(webapi.class);
        Call<List<Reservas>> call  = api.getHistorialReservas(retrofitSingleton.getNombreCliente(), fechaI,fechaF);

        call.enqueue(new Callback<List<Reservas>>() {

            @Override
            public void  onResponse(Call<List<Reservas>> call, Response<List<Reservas>> response) {
//
                if(response.isSuccessful()) {

                    List<Reservas> reservasList = new ArrayList<>();
                    reservasList = response.body();
//
                    RetrofitSingleton retrofitSingleton = RetrofitSingleton.getInstancia();
                    retrofitSingleton.setReservasList(reservasList);

                    Intent intent = new Intent(getApplicationContext(), ReservasListActivity.class);
                    startActivity(intent);

//                    RecyclerView sesiones_list = findViewById(R.id.reservas_recycler);
//                    ReservaListAdapter adapter = new ReservaListAdapter(reservasList, context_);
//                    sesiones_list.setLayoutManager(new LinearLayoutManager(context_));
//                    sesiones_list.setAdapter(adapter);



                }


            }

            @Override
            public void onFailure(Call<List<Reservas>> call, Throwable t) {

            }


        });


    }//getCountries





}
