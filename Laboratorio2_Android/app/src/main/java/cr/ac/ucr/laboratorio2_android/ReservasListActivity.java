package cr.ac.ucr.laboratorio2_android;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.os.Bundle;

import adapters.ReservaListAdapter;
import models.RetrofitSingleton;

public class ReservasListActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_reservas_list);


        RetrofitSingleton retrofitSingleton = RetrofitSingleton.getInstancia();


        RecyclerView sesiones_list = findViewById(R.id.reservas_recycler);
        ReservaListAdapter adapter = new ReservaListAdapter(retrofitSingleton.getReservasList(), this);
        sesiones_list.setLayoutManager(new LinearLayoutManager(this));
        sesiones_list.setAdapter(adapter);

    }




}
