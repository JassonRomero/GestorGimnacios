package interfas;

import java.util.List;

import models.Clases;
import models.Gimnacios;
import models.Login;
import models.LoginCliente;
import models.RegistroPDF;
import models.Reservas;
import models.Sesiones;
import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Path;
import retrofit2.http.Query;


public interface webapi {

    @GET("api/Negocios/getNegociosMovil")
    Call<List<Gimnacios>> getGm();


//    @GET("api/Negocios/login/Luis&123")
//    Call<List<Login>> getLogin();

    @GET("api/Negocios/loginMovil/{centro}&{contra}")
    Call<List<Login>> getLogin(@Path("centro") String centro,@Path("contra") String contra);


    @GET("api/Negocios/actualizar/{nombre}&{descripcion}&{horarioA}&{horarioC}&{capacidadMaxima}&{porcentajePermitido}")
    Call<List<Gimnacios>> actualizarNegocio(  @Path("nombre") String nombre,
                      @Path("descripcion") String descripcion,
                      @Path("horarioA") String horarioA,
                      @Path("horarioC") String horarioC,
                      @Path("capacidadMaxima") String capacidadMaxima,
                      @Path("porcentajePermitido") String porcentajePermitido
                        );

    @GET("api/Negocios/consultaFecha/{nombre}&{fecha}")
    Call<List<Sesiones>> getSecionesAPI(@Path("nombre") String nombre, @Path("fecha") String fecha);

    @GET("api/Negocios/consultaClaseOnlineMovil/{nombre}")
    Call<List<Clases>> getClasesAdmi(@Path("nombre") String nombre);


    @GET("api/Negocios/loginCliente/{nombre}&{contra}")
    Call<List<LoginCliente>> getLoginCliente(@Path("nombre") String nombre, @Path("contra") String contra);

    @GET("api/Negocios/reservar/{codSesion}&{nombre}")
    Call<List<Sesiones>> reservarSecion(@Path("codSesion") int codSesion, @Path("nombre") String nombre);


    @GET("api/Negocios/insertClaseOnline/{nombreGym}&{nombreClase}&{fecha}&{hora}")
    Call<List<Clases>> reservarClase( @Path("nombreGym") String nombregym,@Path("nombreClase") String nombreClase,@Path("fecha") String fecha,@Path("hora") String hora);

    @GET("api/Negocios/listarReserva/{nombre}&{fechaI}&{fechaF}")
    Call<List<Reservas>> getHistorialReservas(@Path("nombre") String nombre, @Path("fechaI") String fechaI, @Path("fechaF") String fechaF);

    @GET("api/Negocios/verResumen/{nombre}&{fechaI}&{fechaF}")
    Call<List<RegistroPDF>> getRegistroPDF(@Path("nombre") String nombre, @Path("fechaI") String fechaI, @Path("fechaF") String fechaF);




}
