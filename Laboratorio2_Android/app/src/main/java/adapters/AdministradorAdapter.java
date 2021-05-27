package adapters;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.constraintlayout.widget.ConstraintLayout;
import androidx.recyclerview.widget.RecyclerView;

import java.util.List;

import cr.ac.ucr.laboratorio2_android.R;
import models.Gimnacios;
import models.Login;


public class AdministradorAdapter extends RecyclerView.Adapter<AdministradorAdapter.AdministradorViewHolder> {

    private Context context;
    private Login login;

    public AdministradorAdapter(Login lg, Context context) {

        this.context = context;
        this.login=lg;
    }



    @NonNull
    @Override
    public AdministradorViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {

        LayoutInflater inflater = LayoutInflater.from(parent.getContext());
        View listItem = inflater.inflate(R.layout.activity_inicio_administrador, parent, false);
        AdministradorAdapter.AdministradorViewHolder viewHolder = new AdministradorAdapter.AdministradorViewHolder(listItem);

        return viewHolder;
    }



    @Override
    public void onBindViewHolder(@NonNull AdministradorViewHolder holder, int position) {

        //final Gimnacios student = gimList.get(position);
        holder.nombre.setText(login.getNombre_negocio());
        holder.descripcion.setText(login.getDescripcion());
        holder.lugar.setText(login.getUbicacion());
        holder.capacidad.setText(login.getCapacidad_maxima());

//        holder.itemLayout.setOnClickListener(new View.OnClickListener() {
//            @Override
//            public void onClick(View v) {
//                Toast.makeText(context, "El estudiante seleccionado es: "+student.getName()+" "+student.getLastname(), Toast.LENGTH_SHORT).show();
//            }
//        });

    }

    @Override
    public int getItemCount() {
        return 0;
    }

    public static class AdministradorViewHolder extends RecyclerView.ViewHolder {

    public TextView nombre;
    public TextView descripcion;
    public TextView lugar;
    public TextView capacidad;
   // public ConstraintLayout itemLayout;

    public AdministradorViewHolder(@NonNull View itemView) {
        super(itemView);

        this.nombre =  (TextView) itemView.findViewById(R.id.tv_nombreCentroAdmi);
        this.descripcion = (TextView) itemView.findViewById(R.id.tv_descripcionAdmi);
        this.lugar = (TextView) itemView.findViewById(R.id.tv_lugar);
        this.capacidad = (TextView) itemView.findViewById(R.id.tv_capacidadAmi);
        //this.itemLayout = (ConstraintLayout) itemView.findViewById(R.id.cl_gim_list_item);

    }
}

}
