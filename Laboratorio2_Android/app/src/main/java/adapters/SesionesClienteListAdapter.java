package adapters;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.constraintlayout.widget.ConstraintLayout;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import java.util.ArrayList;
import java.util.List;

import cr.ac.ucr.laboratorio2_android.R;
import interfas.webapi;
import models.RetrofitSingleton;
import models.Sesiones;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;

public class SesionesClienteListAdapter extends RecyclerView.Adapter<SesionesClienteListAdapter.SecionesViewHolder> {


    private List<Sesiones> sesionesList;
    private Context context;
    RetrofitSingleton retrofitSingleton;



    public SesionesClienteListAdapter(List<Sesiones> studentsList, Context context) {
        this.sesionesList = studentsList;
        this.context = context;
        retrofitSingleton = RetrofitSingleton.getInstancia();
    }


    /*
    Permite construir cada item en base al layout que asigne
    */
    @NonNull
    @Override
    public SecionesViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {

        LayoutInflater inflater = LayoutInflater.from(parent.getContext());
        View listItem = inflater.inflate(R.layout.sesiones_list_item, parent, false);
        SecionesViewHolder viewHolder = new SecionesViewHolder(listItem);
        return viewHolder;

    }

    @Override
    public void onBindViewHolder(@NonNull SecionesViewHolder holder, int position) {



        final Sesiones student = sesionesList.get(position);
        holder.hora.setText(student.getHorario());
        holder.capacidad.setText("Cupos: " +student.getCupos());
//        holder.lastname.setText(student.getLastname());
//
        holder.itemLayout.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                Toast.makeText(context, "La sesion  seleccionada es: "+student.getCodSesion() +  "  - " + retrofitSingleton.getNombreCliente(), Toast.LENGTH_SHORT).show();

                registrarCliente(student.getCodSesion(),retrofitSingleton.getNombreCliente());

            }
        });
    }



    public void registrarCliente(int codigo ,String cliente ){


        Retrofit retrofit = retrofitSingleton.getRetrofit();

        webapi api = retrofit.create(webapi.class);
        Call<List<Sesiones>> call  = api.reservarSecion(codigo, cliente);
//                Call<List<Sesiones>> call  = api.reservarSecion("45', retrofitSingleton.getNombreCliente());

        call.enqueue(new Callback<List<Sesiones>>() {

            @Override
            public void  onResponse(Call<List<Sesiones>> call, Response<List<Sesiones>> response) {
//
                if(response.isSuccessful()) {

                    List<Sesiones> sesionesList = new ArrayList<>();
                    sesionesList = response.body();

                    Toast.makeText(context, "Exito, se ha reservado la secion", Toast.LENGTH_SHORT).show();


                }

            }

            @Override
            public void onFailure(Call<List<Sesiones>> call, Throwable t) {

            }

        });

    }

    /*
     Me permite conocer el tamaño de la lista en tiempo real
     */
    @Override
    public int getItemCount() {
        return sesionesList.size();
    }


    //View holder para lograr llenar el contenido de cada item
    public static class SecionesViewHolder extends RecyclerView.ViewHolder {

        public TextView hora;
        public TextView capacidad;
        public ConstraintLayout itemLayout;


        public SecionesViewHolder(@NonNull View itemView) {
            super(itemView);

            this.hora = (TextView) itemView.findViewById(R.id.tv_hora);
            this.capacidad = (TextView) itemView.findViewById(R.id.tv_capacidad_list);
            this.itemLayout = (ConstraintLayout) itemView.findViewById(R.id.cl_seciones_admi);

        }
    }
}
