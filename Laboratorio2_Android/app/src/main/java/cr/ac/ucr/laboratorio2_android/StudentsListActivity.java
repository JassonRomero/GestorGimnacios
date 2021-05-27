package cr.ac.ucr.laboratorio2_android;

import android.content.Context;
import android.os.Bundle;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import java.util.ArrayList;
import java.util.List;

import adapters.GimnaciosListAdapter;
import adapters.StudentsListAdapter;
import interfas.webapi;
import models.Gimnacios;
import models.RetrofitSingleton;
import models.Student;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;

public class StudentsListActivity extends AppCompatActivity {

    private RecyclerView students_list_recycler;
    private List<Student> studentList = new ArrayList<>();
    private List<Gimnacios> gimnaciosList = new ArrayList<>();
    Context context_;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_students_list);

        context_ = this;
        getGimnaciosAPI();
        
    }



    private void getGimnaciosAPI() {

        RetrofitSingleton retrofitSingleton = RetrofitSingleton.getInstancia();
        Retrofit retrofit = retrofitSingleton.getRetrofit();

        webapi api = retrofit.create(webapi.class);
        Call<List<Gimnacios>>  call  = api.getGm();

        call.enqueue(new Callback<List<Gimnacios>>() {

            @Override
            public void  onResponse(Call<List<Gimnacios>> call, Response<List<Gimnacios>> response) {
//
                if(response.isSuccessful()) {

                    gimnaciosList = response.body();
//
                    students_list_recycler = findViewById(R.id.students_list_recycler);

                    GimnaciosListAdapter adapter = new GimnaciosListAdapter(gimnaciosList, context_);
                    students_list_recycler.setLayoutManager(new LinearLayoutManager(context_));
                    students_list_recycler.setAdapter(adapter);

                }


            }

            @Override
            public void onFailure(Call<List<Gimnacios>> call, Throwable t) {



            }

        });


    }//getCountries



}
