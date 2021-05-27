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
import models.Reservas;
import models.Sesiones;

public class ReservaListAdapter extends RecyclerView.Adapter<ReservaListAdapter.ReservaViewHolder> {


    private List<Reservas> reservaList;
    private Context context;


    public ReservaListAdapter(List<Reservas> studentsList, Context context) {
        this.reservaList = studentsList;
        this.context = context;
    }


    /*
    Permite construir cada item en base al layout que asigne
    */
    @NonNull
    @Override
    public ReservaViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {

        LayoutInflater inflater = LayoutInflater.from(parent.getContext());
        View listItem = inflater.inflate(R.layout.reserva_list_item, parent, false);
        ReservaViewHolder viewHolder = new ReservaViewHolder(listItem);
        return viewHolder;

    }

    @Override
    public void onBindViewHolder(@NonNull ReservaViewHolder holder, int position) {

        final Reservas reservas = reservaList.get(position);
        holder.nombre.setText(reservas.getGimnasioReserva());
        holder.fecha.setText(reservas.getFechaReserva());
        holder.hora.setText(reservas.getHorario());

//        holder.lastname.setText(reservas.getLastname());
//
//        holder.itemLayout.setOnClickListener(new View.OnClickListener() {
//            @Override
//            public void onClick(View v) {
//                Toast.makeText(context, "El estudiante seleccionado es: "+reservas.getName()+" "+reservas.getLastname(), Toast.LENGTH_SHORT).show();
//            }
//        });
    }

    /*
     Me permite conocer el tamaño de la lista en tiempo real
     */
    @Override
    public int getItemCount() {
        return reservaList.size();
    }


    //View holder para lograr llenar el contenido de cada item
    public static class ReservaViewHolder extends RecyclerView.ViewHolder {

        public TextView nombre;
        public TextView fecha;
        public TextView hora;

        public ConstraintLayout itemLayout;


        public ReservaViewHolder(@NonNull View itemView) {
            super(itemView);

            this.nombre = (TextView) itemView.findViewById(R.id.tv_nombreGymReserva_list);
            this.fecha = (TextView) itemView.findViewById(R.id.tv_fechaReserva_list);
            this.hora = (TextView) itemView.findViewById(R.id.tv_horaReserva_list);
            this.itemLayout = (ConstraintLayout) itemView.findViewById(R.id.cl_reserva_list_item);

        }
    }
}
