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
import models.Clases;


public class ClasesListAdapter extends RecyclerView.Adapter<ClasesListAdapter.ClasesViewHolder> {

    private List<Clases> clasesList;
    private Context context;

    public ClasesListAdapter(List<Clases> gimList, Context context) {
        this.clasesList = gimList;
        this.context = context;
    }



    @NonNull
    @Override
    public ClasesViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {

        LayoutInflater inflater = LayoutInflater.from(parent.getContext());
        View listItem = inflater.inflate(R.layout.clases_list_item, parent, false);
        ClasesListAdapter.ClasesViewHolder viewHolder = new ClasesListAdapter.ClasesViewHolder(listItem);

        return viewHolder;
    }



    @Override
    public void onBindViewHolder(@NonNull ClasesViewHolder holder, int position) {

        final Clases student = clasesList.get(position);
        holder.nombre.setText(student.getNombreClase());
        holder.fecha.setText(student.getFecha());
        holder.hora.setText(student.getHora());


//        holder.itemLayout.setOnClickListener(new View.OnClickListener() {
//            @Override
//            public void onClick(View v) {
//                Toast.makeText(context, "El estudiante seleccionado es: "+student.getName()+" "+student.getLastname(), Toast.LENGTH_SHORT).show();
//            }
//        });

    }

    @Override
    public int getItemCount() {
        return clasesList.size();
    }

    public static class ClasesViewHolder extends RecyclerView.ViewHolder {

    public TextView nombre;
    public TextView fecha;
    public TextView hora;
    public ConstraintLayout itemLayout;


    public ClasesViewHolder(@NonNull View itemView) {
        super(itemView);

        this.nombre =  (TextView) itemView.findViewById(R.id.tv_nombre_clase);
        this.fecha = (TextView) itemView.findViewById(R.id.tv_fecha_clase);
        this.hora = (TextView) itemView.findViewById(R.id.tv_horario_clase);
        this.itemLayout = (ConstraintLayout) itemView.findViewById(R.id.cl_clases_list_item);

    }
}

}
