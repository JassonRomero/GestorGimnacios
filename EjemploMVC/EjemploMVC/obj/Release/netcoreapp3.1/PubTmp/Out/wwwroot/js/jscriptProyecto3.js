function registrarNegocioScript(Nombre, Contrasena, Descripcion, Ubicacion, Telefono, Correo, HorarioA, HorarioC, Capacidad, Porcentaje, Logo, Imagen1, Imagen2, Imagen3, Imagen4, Imagen5) {
    
   

    var parametros = { "nombre": Nombre, "contrasena": Contrasena, "descripcion": Descripcion, "ubicacion": Ubicacion, "telefono": Telefono, "correo": Correo, "horarioA": HorarioA, "horarioC": HorarioC, "capacidad": Capacidad, "porcentaje": Porcentaje, "logo": Logo, "imagen1": Imagen1, "imagen2": Imagen2, "imagen3": Imagen3, "imagen4": Imagen4, "imagen5": Imagen5 };
    var data1 = new FormData(parametros);

    $.ajax(
        {
            data: data1,
            enctype: 'multipart/form-data',
            url: '/Principal/RegistrarNegocio',
            type: 'post',
            beforeSend: function () {
                $("#resultadoREGISTRAR").html("Procesando, espere por favor ...");
            },
            success: function (response) {

                //$("#resultadoREGISTRAR").html(response);
                if (response == "Encontrado") {

                    $("#resultadoREGISTRAR").html("Este gimnasio ya esta registrado");

                } else {
                    redireccion('/Principal/Login');

                }


            }
        }
    );
}


function loginNegocioScript(Nombre, Contrasena) {

  
    sessionStorage.removeItem("NombreGym");
    sessionStorage.setItem("NombreGym", Nombre);

    var parametros = { "nombre": Nombre, "contrasena": Contrasena};
    $.ajax(
        {
            data: parametros,
            url: '/Principal/Login',
            type: 'post',
            beforeSend: function () {
                $("#resultadoLogin").html("Procesando, espere por favor ...");
            },
            success: function (response) {

                //$("#resultadoLogin").html(response);
                if (response == "Encontrado") {
                   
                    redireccion('/Principal/ModuloAdmin');                   

                } else {
                   $("#resultadoLogin").html("No hay coincidencias");   
                }
                
            }
        }
    );
}



function actualizarNegocio(Descripcion, HorarioA, HorarioC, Capacidad, Porcentaje) {
    var parametros = { "nombre": sessionStorage.getItem("NombreGym"), "descripcion": Descripcion, "horarioA": HorarioA, "horarioC": HorarioC, "capacidad": Capacidad, "Porcentaje": Porcentaje };
    $.ajax(
        {
            data: parametros,
            url: '/Principal/GestionarEstablecimiento',
            type: 'post',
            beforeSend: function () {
                $("#resultadoACTUALIZAR").html("Procesando, espere por favor ...");
            },
            success: function (response) {
                $("#resultadoACTUALIZAR").html(response);
                
            }
        }
    );
} 


function iniciarCliente(Nombre) {
    sessionStorage.removeItem("NombreGimnasio");
    sessionStorage.setItem("NombreGimnasio", Nombre);

    redireccion('/Principal/LoginCliente');    
}


function loginClienteScript(Nombre, Contrasena) {

    sessionStorage.removeItem("NombreCliente");
    sessionStorage.setItem("NombreCliente", Nombre);

    //alert(sessionStorage.getItem("NombreCliente"));
    //alert(sessionStorage.getItem("NombreGimnasio"));

    var parametros = { "nombre": Nombre, "contrasena": Contrasena };
    $.ajax(
        {
            data: parametros,
            url: '/Principal/LoginCliente',
            type: 'post',
            beforeSend: function () {
                $("#resultadoLoginCliente").html("Procesando, espere por favor ...");
            },
            success: function (response) {

                //$("#resultadoLogin").html(response);
                if (response == "Encontrado") {
                   // $("#resultadoLoginCliente").html("EL USUARIO FUE ENCONTRADO");
                    redireccion('/Principal/ModuloCliente');

                } else {
                    $("#resultadoLoginCliente").html("No hay coincidencias");
                }

            }
        }
    );
    
}


function verSesionesReserva(fechaSesion) {
    //alert(fechaSesion);
    var fecha = new Date();


    var fechaValidacion = fecha.getFullYear() + "-";
    if (fecha.getMonth() < 10) {
        fechaValidacion += "0";
    }
    fechaValidacion += fecha.getMonth() + 1 + "-";
    if ((fecha.getDate()+7) < 10) {
        fechaValidacion += "0";
    }
    fechaValidacion += fecha.getDate() + 7;

    var fechaValidacionHoy = fecha.getFullYear() + "-";
    if (fecha.getMonth() < 10) {
        fechaValidacionHoy += "0";
    }
    fechaValidacionHoy += fecha.getMonth() + 1 + "-";
    if (fecha.getDate() < 10) {
        fechaValidacionHoy += "0";
    } 
    fechaValidacionHoy += fecha.getDate();
    


    if (fechaValidacionHoy > fechaSesion) {
       // alert("La fecha ingresada es menor a la fecha actual");
        $("#resultadoVerSesiones").html("La fecha ingresada es menor a la fecha actual");
    } else if (fechaSesion > fechaValidacion) {
       // alert("Aún no se han cargado sesiones para esa fechas");
        $("#resultadoVerSesiones").html("Aún no se han cargado sesiones para esa fechas");
    } else {

        var parametros = { "gimnasioReserva": sessionStorage.getItem("NombreGimnasio"), "fechaReserva": fechaSesion };
        $.ajax(
            {
                data: parametros,
                url: '/Principal/ModuloCliente',
                type: 'post',
                beforeSend: function () {
                    $("#resultadoVerSesiones").html("Procesando, espere por favor ...");
                },
                success: function (response) {

                    $("#resultadoVerSesiones").html(response);

                }
            }
        );
    }

}






function realizarReservacion(codNombre) {
    //alert("LLUEGUE AL LUGAR " + codNombre);
    var parametros = { "nombreCliente": sessionStorage.getItem("NombreCliente"), "CodSesion": codNombre };
    $.ajax(
        {
            data: parametros,
            url: '/Principal/VerSesiones',
            type: 'post',
            beforeSend: function () {
                $("#resultadoReservarSesion").html("Procesando, espere por favor ...");
            },
            success: function (response) {

               // $("#resultadoReservarSesion").html(response);
                redireccion('/Principal/PantallaReservas');


            }
        }
    );
}

function listarTodasSesiones(fechaInicio, fechaFin) {
   // alert("LLUEGUE AL LUGAR " + fechaInicio);

    var parametros = { "gimnasioReserva": sessionStorage.getItem("NombreCliente"), "fechaReserva": fechaInicio, "codSesion": fechaFin };
    $.ajax(
        {
            data: parametros,
            url: '/Principal/PantallaReservas',
            type: 'post',
            beforeSend: function () {
                $("#resultadoListaReservas").html("Procesando, espere por favor ...");
            },
            success: function (response) {

                $("#resultadoListaReservas").html(response);
               // redireccion('/Principal/PantallaReservas');


            }
        }
    );
}



function informacionGimansio() {
    //alert("CARGUE EL METODO");
    var parametros = { "gimnasioReserva": sessionStorage.getItem("NombreGimnasio")};
    $.ajax(
        {
            data: parametros,
            url: '/Principal/InfoNegocioGym',
            type: 'post',
            beforeSend: function () {
                $("#resultadoInfoNegocioGym").html("Procesando, espere por favor ...");
            },
            success: function (response) {

                $("#resultadoInfoNegocioGym").html(response);
                // redireccion('/Principal/PantallaReservas');


            }
        }
    );
}


function insertClaseOnline(nombreClase, fecha, hora) {
    //alert("CARGUE EL METODO" + nombreClase + fecha + hora);
    var parametros = { "nombreGym": sessionStorage.getItem("NombreGym"), "nombreClase": nombreClase, "fecha": fecha, "hora": hora };
    $.ajax(
        {
            data: parametros,
            url: '/Principal/ClaseOnline',
            type: 'post',
            beforeSend: function () {
                $("#resultadoInsertClaseOnline").html("Procesando, espere por favor ...");
            },
            success: function (response) {
               // $("#resultadoInsertClaseOnline").html(response);
                if (response == "Insertado") {
                    // $("#resultadoLoginCliente").html("EL USUARIO FUE ENCONTRADO");
                    $("#resultadoInsertClaseOnline").html("Registro con exito");                  

                } else {
                    $("#resultadoInsertClaseOnline").html("Ya existe una clase en esta fecha y este horario");
                }


            }
        }
    );
}



function verResumenPDF(fechaInicial, fechaFinal) {
 
    var parametros = { "gimnasioReserva": sessionStorage.getItem("NombreGym"), "fechaReserva": fechaInicial, "codSesion": fechaFinal  }
    $.ajax(
        {
            data: parametros,
            url: '/Principal/VerResumen',
            type: 'post',
            beforeSend: function () {
                $("#resultadoVERRESUMEN").html("Procesando, espere por favor ...");
            },
            success: function (response) {

               // $("#resultadoVERRESUMEN").html("Registro con exito");

                var html = '<div class="intro-section bgimg" data-stellar-background-ratio="0.5" id="home-section">  <div class="container"> <div class="row align-items-center">  <div class="col-lg-12 mx-auto text-center" data-aos="fade-up"> <div class="wrap-contact100">';
                html += '<iframe type="application/pdf" src=/resumen/' + sessionStorage.getItem("NombreGym") + '/ResumenClientes.pdf width = "100%" height = "1080px"  </iframe>  </div> </div> </div> </div> ';                                                                                   

               
                document.getElementById("verResumenEnPDF").innerHTML = html;
                  
            }
        }
    );
}





function redireccion(direccion) {
    document.location.href = direccion;
}