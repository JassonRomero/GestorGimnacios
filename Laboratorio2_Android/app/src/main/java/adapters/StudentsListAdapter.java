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
import models.Student;

public class StudentsListAdapter extends RecyclerView.Adapter<StudentsListAdapter.StudentViewHolder> {


    private List<Student> studentsList;
    private Context context;



    public StudentsListAdapter(List<Student> studentsList, Context context) {
        this.studentsList = studentsList;
        this.context = context;
    }


    /*
    Permite construir cada item en base al layout que asigne
    */
    @NonNull
    @Override
    public StudentViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {

        LayoutInflater inflater = LayoutInflater.from(parent.getContext());
//        View listItem = inflater.inflate(R.layout.students_list_item, parent, false);
//        StudentViewHolder viewHolder = new StudentViewHolder(listItem);

//        return viewHolder;
        return null;
    }

    @Override
    public void onBindViewHolder(@NonNull StudentViewHolder holder, int position) {

        final Student student = studentsList.get(position);
        holder.id.setText(student.getId());
        holder.name.setText(student.getName());
        holder.lastname.setText(student.getLastname());

        holder.itemLayout.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Toast.makeText(context, "El estudiante seleccionado es: "+student.getName()+" "+student.getLastname(), Toast.LENGTH_SHORT).show();
            }
        });
    }

    /*
     Me permite conocer el tamaño de la lista en tiempo real
     */
    @Override
    public int getItemCount() {
        return studentsList.size();
    }


    //View holder para lograr llenar el contenido de cada item
    public static class StudentViewHolder extends RecyclerView.ViewHolder {

        public TextView id;
        public TextView name;
        public TextView lastname;
        public ConstraintLayout itemLayout;

        public StudentViewHolder(@NonNull View itemView) {
            super(itemView);
//            this.id = (TextView) itemView.findViewById(R.id.tv_id);
//            this.name = (TextView) itemView.findViewById(R.id.tv_name);
//            this.lastname = (TextView) itemView.findViewById(R.id.tv_lastname);
//            this.itemLayout = (ConstraintLayout) itemView.findViewById(R.id.cl_students_list_item);
        }
    }
}
