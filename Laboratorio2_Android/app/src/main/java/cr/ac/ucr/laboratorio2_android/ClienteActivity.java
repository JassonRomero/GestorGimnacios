package cr.ac.ucr.laboratorio2_android;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import models.RetrofitSingleton;

public class ClienteActivity extends AppCompatActivity {

    private RetrofitSingleton singleton;
    private ImageView iv_Seciones;
    private ImageView iv_clases;
    private ImageView iv_reservas;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cliente);

        singleton = RetrofitSingleton.getInstancia();

        TextView nombre =(TextView)findViewById(R.id.tv_ClienteGymMC);
        TextView gimnacio = (TextView)findViewById(R.id.tv_nombreGymMC);

        nombre.setText("Cliente: " + singleton.getNombreCliente());
        gimnacio.setText("Gimnacio:  " +singleton.getGimnacioCliente());

        iv_Seciones = (ImageView) findViewById(R.id.ic_SecionesCliente);
        iv_clases = (ImageView) findViewById(R.id.ic_clasesCliente);
        iv_reservas = (ImageView) findViewById(R.id.ic_historialCliente);

        iv_Seciones.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(getApplicationContext(), SecionesClienteActivity.class);
                startActivity(intent);
            }
        });


        iv_clases.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

//                Toast.makeText(getApplicationContext(), "El resumen se creo exitosamente. Esta almacenado en descargas", Toast.LENGTH_LONG).show();
                Intent intent = new Intent(getApplicationContext(), ClasesCliente.class);
                startActivity(intent);
            }
        });

        iv_reservas.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

//                Toast.makeText(getApplicationContext(), "El resumen se creo exitosamente. Esta almacenado en descargas", Toast.LENGTH_LONG).show();
                Intent intent = new Intent(getApplicationContext(), Reservas_Cliente_Activity.class);
                startActivity(intent);
            }
        });


    }



}
