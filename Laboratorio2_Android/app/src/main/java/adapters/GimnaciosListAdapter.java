package adapters;

import android.content.Context;
import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.constraintlayout.widget.ConstraintLayout;
import androidx.recyclerview.widget.RecyclerView;

import java.util.List;

import cr.ac.ucr.laboratorio2_android.ClienteActivity;
import cr.ac.ucr.laboratorio2_android.R;
import cr.ac.ucr.laboratorio2_android.StudentsListActivity;
import models.Gimnacios;
import models.RetrofitSingleton;


public class GimnaciosListAdapter extends RecyclerView.Adapter<GimnaciosListAdapter.GimnaciosViewHolder> {

    private List<Gimnacios> gimList;
    private Context context;

    public GimnaciosListAdapter(List<Gimnacios> gimList, Context context) {
        this.gimList = gimList;
        this.context = context;
    }



    @NonNull
    @Override
    public GimnaciosViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {

        LayoutInflater inflater = LayoutInflater.from(parent.getContext());
        View listItem = inflater.inflate(R.layout.gym_list_item, parent, false);
        GimnaciosListAdapter.GimnaciosViewHolder viewHolder = new GimnaciosListAdapter.GimnaciosViewHolder(listItem);

        return viewHolder;
    }



    @Override
    public void onBindViewHolder(@NonNull GimnaciosViewHolder holder, int position) {

        final Gimnacios student = gimList.get(position);
        holder.nombre.setText(student.getNombre_negocio());
        holder.descripcion.setText(student.getDescripcion());
        holder.lugar.setText(student.getUbicacion());
        holder.capacidad.setText(student.getCapacidad_maxima());

        holder.itemLayout.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Toast.makeText(context, "El gimnacio seleccionado es: "+student.getNombre_negocio(), Toast.LENGTH_SHORT).show();

                RetrofitSingleton singleton = RetrofitSingleton.getInstancia();
                singleton.setGimnacioCliente(student.getNombre_negocio());

                Intent intent = new Intent(context.getApplicationContext(), ClienteActivity.class);
                context.startActivity(intent);


            }
        });

    }

    @Override
    public int getItemCount() {
        return gimList.size();
    }

    public static class GimnaciosViewHolder extends RecyclerView.ViewHolder {

    public TextView nombre;
    public TextView descripcion;
    public TextView lugar;
    public TextView capacidad;
    public ConstraintLayout itemLayout;

    public GimnaciosViewHolder(@NonNull View itemView) {
        super(itemView);

        this.nombre =  (TextView) itemView.findViewById(R.id.tv_nombre_list);
        this.descripcion = (TextView) itemView.findViewById(R.id.tv_descripcion_list);
        this.lugar = (TextView) itemView.findViewById(R.id.tv_lugar_list);
        this.capacidad = (TextView) itemView.findViewById(R.id.tv_capacidad_list);
        this.itemLayout = (ConstraintLayout) itemView.findViewById(R.id.cl_gim_list_item);

    }
}

}
