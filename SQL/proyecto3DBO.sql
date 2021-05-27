use Proyecto3LenguajesLuisJasson

drop table negocio
Create table negocio(
id_negocio int IDENTITY(1,1) PRIMARY KEY,
nombre_negocio varchar(100) unique not null, 
contrasena varchar(100) not null, 
descripcion  varchar(1000)not null,
ubicacion varchar(500)not null,
telefono varchar(100) not null, 
correo varchar(60) not null,
horarioA time not null,
horarioC time not null,
capacidad_maxima int not null,
porcentaje_permitido int not null,

)
delete negocio where id_negocio=6
select* from negocio
select*from sesiones
select*from cliente
select*from intermediaSesionCliente
select*from claseOnline

-------------------------------------------------------------
drop table cliente
Create table cliente(
idCliente int IDENTITY(1,1) PRIMARY KEY,
nombre varchar(100) unique not null, 
contrasena varchar(100) not null
)

select* from cliente
insert into cliente(nombre,contrasena)values('Naranjo','123');
insert into cliente(nombre,contrasena)values('Brenes','123');
insert into cliente(nombre,contrasena)values('Romero','123');
-------------------------------------------------------------
drop table sesiones
Create table sesiones(
codSesion int IDENTITY(1,1) PRIMARY KEY,
gimnasioReserva varchar(80),
fechaReserva varchar(50) not null,
horario varchar(50) not null,
cupos int not null
)
select* from sesiones
-------------------------------------------------------------
drop table claseOnline
Create table claseOnline(
idClase int IDENTITY(1,1) PRIMARY KEY,
nombreGym varchar(100) not null,
nombreClase varchar(100) not null, 
fecha date not null,
hora time not null
foreign key (nombreGym) references negocio (nombre_negocio) ON DELETE Cascade ON UPDATE CASCADE,
)
insert into claseOnline(nombreGym,nombreClase,fecha,hora) values('Snake','Running','04/07/2020','10:00:00')

-------------------------------------------------------------
drop table intermediaSesionCliente
Create table intermediaSesionCliente(
codIntermedia int IDENTITY(1,1) PRIMARY KEY,
codSesion int not null,
nombreCliente varchar(100)
foreign key (codSesion) references sesiones (codSesion) ON DELETE Cascade ON UPDATE CASCADE,
foreign key (nombreCliente) references cliente (nombre) ON DELETE Cascade ON UPDATE CASCADE
)
select* from intermediaSesionCliente
------------------------------------------------------------
drop procedure Proc_claseOnline
create procedure Proc_claseOnline
@nombre varchar(100)
as begin 
begin try
	if exists(select*from claseOnline where claseOnline.nombreGym=@nombre and claseOnline.fecha>=CONVERT(DATE, GETDATE(),3))begin
		select claseOnline.nombreGym, negocio.descripcion, negocio.ubicacion, claseOnline.nombreClase,CONVERT(varchar(50), claseOnline.fecha,5) as fecha, Convert(varchar(50),claseOnline.hora,108)as hora from claseOnline
		inner join negocio on negocio.nombre_negocio=claseOnline.nombreGym where claseOnline.nombreGym=@nombre and claseOnline.fecha>=CONVERT(DATE, GETDATE(),3);
	end
end try 
begin catch
	print('Error')
end catch
end

select CONVERT(DATE, GETDATE(),108)
select getDate();
execute Proc_claseOnline 'Snake'
------------------------------------------------------------
drop procedure Proc_claseOnlineMovil
create procedure Proc_claseOnlineMovil
@nombre varchar(100)
as begin 
begin try
	if exists(select*from claseOnline where claseOnline.nombreGym=@nombre and claseOnline.fecha>=CONVERT(DATE, GETDATE(),3))begin
		select claseOnline.nombreGym, claseOnline.nombreClase,CONVERT(varchar(50), claseOnline.fecha,5) as fecha, Convert(varchar(50),claseOnline.hora,108)as hora from claseOnline 
		where claseOnline.nombreGym=@nombre and claseOnline.fecha>=CONVERT(DATE, GETDATE(),3);
	end
end try 
begin catch
	print('Error')
end catch
end

select CONVERT(DATE, GETDATE(),108)
select getDate();
execute Proc_claseOnlineMovil 'Snake'
-------------------------------------------------------------
drop procedure Proc_InsertclaseOnline
create procedure Proc_InsertclaseOnline
@nombreGym varchar(100),
@nombreClase varchar(100),
@fecha date,
@hora time
as begin 
begin try
	if not exists(select*from claseOnline where claseOnline.nombreGym=@nombreGym and claseOnline.fecha=@fecha and claseOnline.hora=@hora)begin
		insert into claseOnline(nombreGym,nombreClase,fecha,hora) values(@nombreGym,@nombreClase,@fecha,@hora);
		select claseOnline.nombreGym, claseOnline.nombreClase, CONVERT(varchar(50), claseOnline.fecha,5) as fecha, Convert(varchar(50),claseOnline.hora,108)as hora from claseOnline 
			where claseOnline.nombreGym=@nombreGym and claseOnline.fecha=@fecha and claseOnline.hora=@hora and claseOnline.nombreClase=@nombreClase
	end
end try 
begin catch
	print('Error')
end catch
end

select*from claseOnline
execute Proc_InsertclaseOnline 'Snake','Rapidin','08/07/2020','10:00:00'
-------------------------------------------------------------
drop procedure Proc_consultaFecha

create procedure Proc_consultaFecha
@nombre varchar(100), 
@fecha date
as begin 
begin try

	if exists(select*from sesiones where sesiones.fechaReserva=@fecha and sesiones.gimnasioReserva=@nombre)begin
		select sesiones.codSesion,sesiones.gimnasioReserva,sesiones.fechaReserva,sesiones.horario, sesiones.cupos from sesiones 
		where sesiones.fechaReserva=@fecha and sesiones.cupos>0 and sesiones.gimnasioReserva=@nombre;
	end else begin
		Declare @horaI time, @horaF time,@capacidad int , @porcentaje int, @cupos int;
		select @horaI=negocio.horarioA, @horaF=negocio.horarioC,@capacidad=negocio.capacidad_maxima, @porcentaje=negocio.porcentaje_permitido from
		negocio where @nombre=negocio.nombre_negocio
		set @cupos=@capacidad*(@porcentaje/100.0);
		while @horaI<@horaF begin
			insert into	sesiones(gimnasioReserva,fechaReserva,horario,cupos) values(@nombre,CONVERT(VARCHAR(50),  @fecha, 103),CONVERT(VARCHAR(50),  @horaI, 8),@cupos);
			set @horaI=Convert(Time,DATEADD(hour, 2, @horaI),108);
		end
		select sesiones.codSesion,sesiones.gimnasioReserva,sesiones.fechaReserva,sesiones.horario, sesiones.cupos from sesiones 
		where sesiones.fechaReserva=@fecha and sesiones.cupos>0 and sesiones.gimnasioReserva=@nombre;
	end
end try 
begin catch
	print('Error')
end catch
end

execute Proc_consultaFecha 'Snake','10-07-2020'
delete sesiones where gimnasioReserva='picha'
select*from sesiones
select*from negocio
select*from intermediaSesionCliente
-------------------------------------------------------------
drop procedure Proc_verResumen

create procedure Proc_verResumen
@nombre varchar(100), 
@fecha1 date,
@fecha2 date
as begin 
begin try
	if exists(select*from sesiones inner join intermediaSesionCliente on intermediaSesionCliente.codSesion =sesiones.codSesion where sesiones.gimnasioReserva=@nombre)begin
		select sesiones.gimnasioReserva, sesiones.fechaReserva,sesiones.horario,intermediaSesionCliente.nombreCliente from sesiones
		inner join intermediaSesionCliente on intermediaSesionCliente.codSesion=sesiones.codSesion 
		where sesiones.gimnasioReserva=@nombre and sesiones.fechaReserva >= @fecha1 and sesiones.fechaReserva<=@fecha2 ORDER BY sesiones.fechaReserva ASC	
	end
end try 
begin catch
	print('Error')
end catch
end

execute Proc_verResumen 'Snake','03-07-2020','20-07-2020'
delete sesiones where gimnasioReserva='picha'
select*from sesiones
select*from negocio
select*from intermediaSesionCliente
-------------------------------------------------------------
drop procedure Proc_registraReserva

create procedure Proc_registraReserva
@codSesion int, 
@nombreCliente varchar(100)
as begin 
begin try
	if exists(select*from sesiones where @codSesion=codSesion and cupos>=1)begin
		insert into intermediaSesionCliente(codSesion,nombreCliente) values(@codSesion,@nombreCliente);
		update sesiones set cupos=cupos-1 where codSesion=@codSesion;
		select sesiones.codSesion, sesiones.gimnasioReserva, sesiones.fechaReserva, sesiones.horario, sesiones.cupos from sesiones where codSesion=@codSesion
	end
end try 
begin catch
	print('Error')
end catch
end


select*from sesiones
select*from negocio
-------------------------------------------------------------
drop procedure Proc_RegistrarNegocio

create procedure Proc_RegistrarNegocio 

@nombre_negocio varchar(100), 
@contrasena varchar(100), 
@descripcion varchar(1000),
@ubicacion varchar(500),
@telefono  varchar(100),
@correo varchar(60) ,
@horarioA time,
@horarioC time,
@capacidad_maxima int ,
@porcentaje_permitido int


as

 Begin

	if not exists (select * from negocio where nombre_negocio = @nombre_negocio) begin
		insert into negocio (nombre_negocio, contrasena, descripcion, ubicacion, telefono, correo, horarioA, horarioC, capacidad_maxima, porcentaje_permitido)
		VALUES (@nombre_negocio, @contrasena, @descripcion, @ubicacion, @telefono, @correo, @horarioA, @horarioC, @capacidad_maxima, @porcentaje_permitido);
	end

  END
   
 GO

 EXECUTE Proc_RegistrarNegocio '1', '1', 'Gran calidad en sus clases', 'Turrialba Cartago detras de las palmeras', '22569705', 'snake07@gmail.com','06:00', '06:00', '100', '60'
 select*from negocio
 delete negocio where id_negocio=6

---exec Proc_RegistrarNegocio @nombre_negocio='Snake', @contrasena='123',  @descripcion='Gran calidad en sus clases', @ubicacion='Turrialba Cartago detras de las palmeras', @telefono='22569705',  @correo='snake07@gmail.com', @horario='hola', @capacidad_maxima='100', @porcentaje_permitido='60'

--EXECUTE Proc_ActualizarNegocio 

-------------------------------------------------------------
drop  procedure Proc_ActualizarNegocio
create procedure Proc_ActualizarNegocio 

@nombre_negocio varchar(100),
@descripcion varchar(1000),
@horarioA time,
@horarioC time,
@capacidad_maxima int ,
@porcentaje_permitido int

as

 Begin

  update negocio set descripcion = @descripcion, horarioA = @horarioA, horarioC = @horarioC, capacidad_maxima = @capacidad_maxima, porcentaje_permitido =@porcentaje_permitido
  Where nombre_negocio = @nombre_negocio

  select nombre_negocio,descripcion,ubicacion,capacidad_maxima,porcentaje_permitido from negocio where nombre_negocio=@nombre_negocio;
  END

 GO
-------------------------------------------------------------
drop  procedure Proc_LoginNegocio

create procedure Proc_LoginNegocio 

@nombre_negocio varchar(100),
@contrasena varchar(100)


as

 Begin

  select nombre_negocio from negocio where nombre_negocio = @nombre_negocio and contrasena = @contrasena

 END

 GO

 EXECUTE Proc_LoginNegocio 'Luis', '123'
-----------------------------------------------------------
select*from sesiones
select*from intermediaSesionCliente
drop  procedure Proc_ListarReserva

create procedure Proc_ListarReserva 

@nombre varchar(100),
@fechaI date,
@fechaF date

as Begin
begin try
	if exists (select*from intermediaSesionCliente where @nombre=nombreCliente)begin
		select sesiones.gimnasioReserva, sesiones.horario, sesiones.fechaReserva from intermediaSesionCliente
		inner join sesiones on sesiones.codSesion=intermediaSesionCliente.codSesion
		where intermediaSesionCliente.nombreCliente=@nombre and sesiones.fechaReserva>=@fechaI and sesiones.fechaReserva<=@fechaF ORDER BY sesiones.fechaReserva ASC
	end
end try 
begin catch

end catch
 end

 GO

 EXECUTE Proc_ListarReserva 'Naranjo', '03/07/2020','20/07/2020'
 select*from sesiones
-----------------------------------------------------------
drop  procedure Proc_LoginNegocioMovil

create procedure Proc_LoginNegocioMovil 

@nombre_negocio varchar(100),
@contrasena varchar(100)


as

 Begin

  select nombre_negocio, descripcion, ubicacion, capacidad_maxima,porcentaje_permitido,Convert(varchar(50),horarioA,108) as horarioA,Convert(varchar(50),horarioC,108)as horarioC  from negocio where nombre_negocio = @nombre_negocio and contrasena = @contrasena

 END

 GO

 EXECUTE Proc_LoginNegocioMovil 'Luis', '123'
-----------------------------------------------------------
drop  procedure Proc_GetNegocios

create procedure Proc_GetNegocios 

as begin 
	begin try

		select nombre_negocio, ubicacion from negocio

	end try
	begin catch
		print('OCURRIO UN ERROR EN LA CONSULTA')
	end catch
end
go
 EXECUTE Proc_GetNegocios
 -------------------------------------------------------------
drop  procedure Proc_GetNegociosMovil

create procedure Proc_GetNegociosMovil 

as begin 
	begin try

		select nombre_negocio, descripcion, ubicacion, capacidad_maxima,porcentaje_permitido from negocio

	end try
	begin catch
		print('OCURRIO UN ERROR EN LA CONSULTA')
	end catch
end
go
 EXECUTE Proc_GetNegociosMovil
 -------------------------------------------------------------

drop  procedure Proc_GetNegocioNombre

create procedure Proc_GetNegocioNombre 
@nombre_negocio varchar(100)

as begin 
	begin try

		select * from negocio where nombre_negocio=@nombre_negocio

	end try
	begin catch
		print('OCURRIO UN ERROR EN LA CONSULTA')
	end catch
end
go
 EXECUTE Proc_GetNegocioNombre '1'
 --------------------------------------------------------------
 
drop  procedure Proc_GetNegocioNombreMovil

create procedure Proc_GetNegocioNombreMovil 
@nombre_negocio varchar(100)

as begin 
	begin try

		select nombre_negocio, descripcion, ubicacion, capacidad_maxima,porcentaje_permitido from negocio where nombre_negocio=@nombre_negocio

	end try
	begin catch
		print('OCURRIO UN ERROR EN LA CONSULTA')
	end catch
end
go
 EXECUTE Proc_GetNegocioNombreMovil 'Luis'
 --------------------------------------------------------------
 drop  procedure Proc_LoginCliente

create procedure Proc_LoginCliente 

@nombreCliente varchar(100),
@contrasena varchar(100)


as

 Begin

  select nombre from cliente where nombre = @nombreCliente and contrasena = @contrasena

 END

 GO

 EXECUTE Proc_LoginCliente 'Naranjo', '123'