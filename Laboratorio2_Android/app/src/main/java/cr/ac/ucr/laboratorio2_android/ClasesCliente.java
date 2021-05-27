package cr.ac.ucr.laboratorio2_android;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.content.Context;
import android.os.Bundle;

import java.util.ArrayList;
import java.util.List;

import adapters.ClasesListAdapter;
import interfas.webapi;
import models.Clases;
import models.RetrofitSingleton;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;

public class ClasesCliente extends AppCompatActivity {


    private RecyclerView clases_list;
    Context context_;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_clases_cliente);
        context_ = this;
        getClases();


    }


    private void getClases() {

        RetrofitSingleton retrofitSingleton = RetrofitSingleton.getInstancia();
        Retrofit retrofit = retrofitSingleton.getRetrofit();

        webapi api = retrofit.create(webapi.class);
        Call<List<Clases>> call  = api.getClasesAdmi(retrofitSingleton.getGimnacioCliente());

        call.enqueue(new Callback<List<Clases>>() {

            @Override
            public void  onResponse(Call<List<Clases>> call, Response<List<Clases>> response) {
//
                if(response.isSuccessful()) {

                    List<Clases> clasesList = new ArrayList<>();
                    clasesList = response.body();
//
                    clases_list = findViewById(R.id.clases_cliente_list_recycler);

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



}
