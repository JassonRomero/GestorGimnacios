package cr.ac.ucr.laboratorio2_android;

import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.ActivityCompat;
import androidx.recyclerview.widget.LinearLayoutManager;

import android.Manifest;
import android.app.Activity;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.os.Bundle;
import android.os.Environment;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;


import com.lowagie.text.Document;
import com.lowagie.text.DocumentException;
import com.lowagie.text.Paragraph;
import com.lowagie.text.pdf.PdfPTable;
import com.lowagie.text.pdf.PdfTemplate;
import com.lowagie.text.pdf.PdfWriter;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.util.ArrayList;
import java.util.List;

import adapters.AdministradorAdapter;
import adapters.GimnaciosListAdapter;
import interfas.webapi;
import models.Login;
import models.RegistroPDF;
import models.Reservas;
import models.RetrofitSingleton;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;

public class InicioAdministrador extends AppCompatActivity {


    private Login logn;
    private TextView nombre;
    private TextView descripcion;
    private TextView lugar;
    private TextView capacidad;
    private TextView horaA;
    private TextView horaB;
    private ImageView ic_actualizar;
    private ImageView iv_resumen;
    private ImageView iv_Seciones;
    private ImageView iv_clases;


    private String NOMBRE_DIRECTORIO = "MisPDFs";
    private String NOMBRE_DOCUMENTO = "MiPDF.pdf";


    @Override
    protected void onCreate(Bundle savedInstanceState) {

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_inicio_administrador);
        //Login logn = (Login) getIntent().getSerializableExtra("login");
        RetrofitSingleton singleton = RetrofitSingleton.getInstancia();
        logn = singleton.getLogin();
        nombre = (TextView)findViewById(R.id.tv_nombreCentroAdmi);
        descripcion = (TextView)findViewById(R.id.tv_descripcionAdmi);
        lugar = (TextView)findViewById(R.id.tv_lugar);
        capacidad = (TextView)findViewById(R.id.tv_capacidadAmi);
        horaA = (TextView)findViewById(R.id.tv_horarioA);
        horaB = (TextView)findViewById(R.id.tv_horarioB);

        nombre.setText("" + logn.getNombre_negocio());
        descripcion.setText("" +logn.getDescripcion());
        lugar.setText("" +logn.getUbicacion());
        capacidad.setText("Capacidad: " +logn.getCapacidad_maxima());
        horaA.setText("Horario apertura: " +logn.getHorarioA());
        horaB.setText("Horario cierre: " +logn.getHorarioC());

        ic_actualizar = (ImageView) findViewById(R.id.ic_actualizarCentro);
        iv_resumen = (ImageView) findViewById(R.id.ic_resumen);
        iv_Seciones = (ImageView) findViewById(R.id.ic_Seciones);
        iv_clases = (ImageView) findViewById(R.id.ic_clases);


        //PERMISOS
        if(ActivityCompat.checkSelfPermission(this,Manifest.permission.WRITE_EXTERNAL_STORAGE)  !=  PackageManager.PERMISSION_GRANTED  &&
                ActivityCompat.checkSelfPermission(this,Manifest.permission.WRITE_EXTERNAL_STORAGE) != PackageManager.PERMISSION_GRANTED){
            ActivityCompat.requestPermissions(this, new String[]{Manifest.permission.WRITE_EXTERNAL_STORAGE}, 1000 );
        }

        ic_actualizar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(getApplicationContext(), ActualizarNegocio.class);
                startActivity(intent);
            }
        });

        iv_resumen.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                crearPDF();
                Toast.makeText(getApplicationContext(), "El resumen se creo exitosamente. Esta almacenado en descargas", Toast.LENGTH_LONG).show();
            }
        });

        iv_Seciones.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(getApplicationContext(), SecionesActivity.class);
                startActivity(intent);

                Toast.makeText(getApplicationContext(), "El resumen se creo exitosamente. Esta almacenado en descargas", Toast.LENGTH_LONG).show();


            }
        });

        iv_clases.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(getApplicationContext(), ClasesAdministrador.class);
                startActivity(intent);

            }
        });

    }

    public void crearPDF(){






            RetrofitSingleton retrofitSingleton = RetrofitSingleton.getInstancia();
            Retrofit retrofit = retrofitSingleton.getRetrofit();
            webapi api = retrofit.create(webapi.class);
            Call<List<RegistroPDF>> call  = api.getRegistroPDF(retrofitSingleton.getLogin().getNombre_negocio(),"01-01-2020","30-12-2020");

            call.enqueue(new Callback<List<RegistroPDF>>() {

                @Override
                public void  onResponse(Call<List<RegistroPDF>> call, Response<List<RegistroPDF>> response) {
//
                    if(response.isSuccessful()) {

                        Document documento= new Document();
                        File file  = crearFichero(NOMBRE_DOCUMENTO);
                        FileOutputStream ficheroPDF = null;
                        try {
                            ficheroPDF = new FileOutputStream(file.getAbsolutePath());

                        PdfWriter writer = PdfWriter.getInstance(documento,ficheroPDF);
                        documento.open();

                        List<RegistroPDF> reservasList = new ArrayList<>();
                        reservasList = response.body();

                        PdfPTable tabla = new PdfPTable(4);
                        for (int i = -1; i <reservasList.size(); i++){

                            if(i==-1){
                                tabla.addCell("Gimnacio");
                                tabla.addCell("Fecha");
                                tabla.addCell("Horario");
                                tabla.addCell("Cliente");

                            }else{
                                tabla.addCell(reservasList.get(i).getNombreCliente());
                                tabla.addCell(reservasList.get(i).getFechaReserva());
                                tabla.addCell(reservasList.get(i).getHorario());
                                tabla.addCell(reservasList.get(i).getNombreCliente());

                            }

                        }


                        documento.add(new Paragraph( "Resúmenes de reservas del Gimnacio"));
                            documento.add(new Paragraph( "\n\n"));
                        documento.add(tabla);
                        } catch (FileNotFoundException e) {
                            e.printStackTrace();
                        } catch (DocumentException e) {
                            e.printStackTrace();
                        } finally {
                            documento.close();
                        }



                    }


                }

                @Override
                public void onFailure(Call<List<RegistroPDF>> call, Throwable t) {

                }


            });




//

    }

    public File crearFichero(String nombreFichero){
        File ruta = getRuta();
        File fichero = null;
        if(ruta!=null){
            fichero = new File(ruta, nombreFichero);
        }
        return fichero;
    }

    public File getRuta(){
        File ruta = null;
        if(Environment.MEDIA_MOUNTED.equals(Environment.getExternalStorageState())){
//            ruta = new File(Environment.getExternalStoragePublicDirectory(Environment.DIRECTORY_DOWNLOADS), NOMBRE_DIRECTORIO);
            ruta = new File(Environment.getExternalStoragePublicDirectory(Environment.DIRECTORY_DOWNLOADS), NOMBRE_DIRECTORIO);

            if(ruta !=null){
                if(!ruta.mkdirs()){
                    if(!ruta.exists()){
                        return null;
                    }

                }

            }
        }

        return ruta;
    }



}
