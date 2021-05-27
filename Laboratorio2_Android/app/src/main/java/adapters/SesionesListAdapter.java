package adapters;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.constraintlayout.widget.ConstraintLayout;
import androidx.recyclerview.widget.RecyclerView;

import java.util.List;

import cr.ac.ucr.laboratorio2_android.R;
import models.Sesiones;
import models.Student;

public class SesionesListAdapter extends RecyclerView.Adapter<SesionesListAdapter.SecionesViewHolder> {


    private List<Sesiones> sesionesList;
    private Context context;



    public SesionesListAdapter(List<Sesiones> studentsList, Context context) {
        this.sesionesList = studentsList;
        this.context = context;
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
//        holder.itemLayout.setOnClickListener(new View.OnClickListener() {
//            @Override
//            public void onClick(View v) {
//                Toast.makeText(context, "El estudiante seleccionado es: "+student.getName()+" "+student.getLastname(), Toast.LENGTH_SHORT).show();
//            }
//        });
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
