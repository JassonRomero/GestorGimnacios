package cr.ac.ucr.laboratorio2_android;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {


    ImageView ic_students_list;
    ImageView ic_center_lp;
//    ImageView ic_students_remove;
//
//    ImageView ic_social_facebook;
//    ImageView ic_social_mail;
//    ImageView ic_social_location;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        ic_students_list = (ImageView) findViewById(R.id.ic_students_list);
        ic_center_lp = (ImageView) findViewById(R.id.ic_center_lp);
//        ic_students_remove = (ImageView) findViewById(R.id.ic_students_remove);
//
//        ic_social_facebook = (ImageView) findViewById(R.id.ic_social_facebook);
//        ic_social_mail = (ImageView) findViewById(R.id.ic_social_mail);
//        ic_social_location = (ImageView) findViewById(R.id.ic_social_location);



        ic_students_list.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
//                Intent intent = new Intent(getApplicationContext(), StudentsListActivity.class);
//                startActivity(intent);

                Intent intent = new Intent(getApplicationContext(), LoginClienteActivity.class);
                startActivity(intent);


            }
        });

        ic_center_lp.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                Intent intent = new Intent(getApplicationContext(), LoginCenter.class);
                startActivity(intent);
                Toast.makeText(getApplicationContext(), "Se selecciona el center", Toast.LENGTH_LONG).show();
            }
        });
//
//        ic_students_remove.setOnClickListener(new View.OnClickListener() {
//            @Override
//            public void onClick(View v) {
//                Toast.makeText(getApplicationContext(), "Se selecciona Remover Estudiante", Toast.LENGTH_LONG).show();
//            }
//        });
//
//        ic_social_facebook.setOnClickListener(new View.OnClickListener() {
//            @Override
//            public void onClick(View v) {
//                Intent intent = new Intent(Intent.ACTION_VIEW, Uri.parse("https://www.facebook.com/UniversidadCostaRica/"));
//                startActivity(intent);
//            }
//        });

//        ic_social_mail.setOnClickListener(new View.OnClickListener() {
//            @Override
//            public void onClick(View v) {
//
//                Intent emailIntent = new Intent(Intent.ACTION_SENDTO, Uri.parse("mailto:"));
//                emailIntent.putExtra(Intent.EXTRA_SUBJECT, "Mensaje de prueba");
//                emailIntent.putExtra(Intent.EXTRA_TEXT, "Este es un mensaje de prueba que se enviará por correo!");
//                startActivity(Intent.createChooser(emailIntent, "Seleccione una aplicación"));
//
//            }
//        });
//
//        ic_social_location.setOnClickListener(new View.OnClickListener() {
//            @Override
//            public void onClick(View v) {
//
//                Uri locationUri = Uri.parse("geo:9.902379, -83.670819");
//                Intent mapIntent = new Intent(Intent.ACTION_VIEW, locationUri);
//
//                mapIntent.setPackage("com.google.android.apps.maps");
//
//                if(mapIntent.resolveActivity( getPackageManager() ) != null ){
//                    startActivity(mapIntent);
//                }
//
//            }
//        });






    }



    @Override
    protected void onPause() {
        super.onPause();
//        Toast.makeText(getApplicationContext(), "Aplicación entrará en Pausa!", Toast.LENGTH_LONG).show();
    }

    @Override
    protected void onResume() {
        super.onResume();

//        Toast.makeText(getApplicationContext(), "Aplicación se reanuda!", Toast.LENGTH_LONG).show();
    }
}
