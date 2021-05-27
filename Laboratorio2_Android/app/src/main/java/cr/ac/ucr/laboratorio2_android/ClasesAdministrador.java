package cr.ac.ucr.laboratorio2_android;

import androidx.annotation.RequiresApi;
import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.content.Context;
import android.os.Build;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TimePicker;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;

import adapters.ClasesListAdapter;
import adapters.SesionesListAdapter;
import interfas.webapi;
import models.Clases;
import models.RetrofitSingleton;
import models.Sesiones;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;

public class ClasesAdministrador extends AppCompatActivity {


    private TimePicker tp ;
    private DatePicker picker;
    private RecyclerView clases_list;
    private Context context_;
    private RetrofitSingleton retrofitSingleton ;
    private Button btn;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_clases_administrador);
        context_ = this;

        retrofitSingleton= RetrofitSingleton.getInstancia();

        picker=(DatePicker)findViewById(R.id.dp_clases);
        btn = (Button) findViewById(R.id.btn_crearClase);

        tp = (TimePicker) findViewById(R.id.timepicker);
        tp.setIs24HourView(true);

        getClases();

        btn.setOnClickListener(new View.OnClickListener() {
            @RequiresApi(api = Build.VERSION_CODES.M)
            @Override
            public void onClick(View v) {


                EditText text = (EditText)findViewById(R.id.tv_nombreClaseAdmi);
                String nombreClase = text.getText().toString();

                String fecha =picker.getDayOfMonth()+ "-" + (picker.getMonth() + 1 )+"-"+ picker.getYear();
                String hora =tp.getHour()+ ":" +  tp.getMinute();

//                Toast.makeText(getApplicationContext(), retrofitSingleton.getLogin().getNombre_negocio()+ "-"+
//                        nombreClase + "-" + fecha + "-"+  hora, Toast.LENGTH_LONG).show();

                newClase(retrofitSingleton.getLogin().getNombre_negocio(),nombreClase,fecha,hora);

            }
        });


        //tp.setIs24HourView(false);

    }


    private void getClases() {


        Retrofit retrofit = retrofitSingleton.getRetrofit();

        webapi api = retrofit.create(webapi.class);
        Call<List<Clases>> call  = api.getClasesAdmi(retrofitSingleton.getLogin().getNombre_negocio());

        call.enqueue(new Callback<List<Clases>>() {

            @Override
            public void  onResponse(Call<List<Clases>> call, Response<List<Clases>> response) {
//
                if(response.isSuccessful()) {

                    List<Clases> clasesList = new ArrayList<>();
                    clasesList = response.body();
//
                    clases_list = findViewById(R.id.clases_admi_list_recycler);

                    ClasesListAdapter adapter = new ClasesListAdapter(clasesList, context_);
                    clases_list.setLayoutManager(new LinearLayoutManager(context_));
                    clases_list.setAdapter(adapter);

                }


            }

            @Override
            public void onFailure(Call<List<Clases>> call, Throwable t) {

            }


        });


    }//getCountries


    private void newClase(String gym,String clase,String fecha, String hora) {


        Retrofit retrofit = retrofitSingleton.getRetrofit();

        webapi api = retrofit.create(webapi.class);
        Call<List<Clases>> call  = api.reservarClase(gym,clase,fecha,hora);

        call.enqueue(new Callback<List<Clases>>() {

            @Override
            public void  onResponse(Call<List<Clases>> call, Response<List<Clases>> response) {
//
                if(response.isSuccessful()) {

                    List<Clases> clasesList = new ArrayList<>();
                    clasesList = response.body();
//
                    if(clasesList.size()>0){
                        Toast.makeText(getApplicationContext(), "Clase registrada con exito!", Toast.LENGTH_LONG).show();

                    }else{
                        Toast.makeText(getApplicationContext(), "Problemas al registrar la clase.", Toast.LENGTH_LONG).show();

                    }

                }


            }

            @Override
            public void onFailure(Call<List<Clases>> call, Throwable t) {

            }


        });


    }//getCountries


}
