using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApiProyectoTres.Models;

namespace WebApiProyectoTres.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NegociosController : ControllerBase
    {
        private readonly Proyecto3LenguajesLuisJassonContext _context;

        public NegociosController(Proyecto3LenguajesLuisJassonContext context)
        {
            _context = context;
        }

        // GET: api/Negocios/getall
        [HttpGet]
        [ActionName("getall")]
        public async Task<ActionResult<IEnumerable<Negocio>>> GetNegocio()
        {
            return await _context.Negocio.ToListAsync();
        }

        // GET: api/Negocios/login/
        [HttpGet("{nombreLog}&{contrasenaLog}")]
        [ActionName("login")]
        public async Task<ActionResult<object>> login(string nombreLog,string contrasenaLog)
        {
            if (nombreLog != null && contrasenaLog != null) {
                using (var cmd = _context.Database.GetDbConnection().CreateCommand())
                {
                    cmd.CommandText = "Proc_LoginNegocio";
                    cmd.CommandType = CommandType.StoredProcedure;
                    // set some parameters of the stored procedure
                    cmd.Parameters.Add(new SqlParameter("@nombre_negocio",
                        SqlDbType.VarChar)
                    { Value = nombreLog });
                    cmd.Parameters.Add(new SqlParameter("@contrasena",
                        SqlDbType.VarChar)
                    { Value = contrasenaLog });

                    if (cmd.Connection.State != ConnectionState.Open)
                        cmd.Connection.Open();

                    var retObject = new List<dynamic>();
                    using (var dataReader = await cmd.ExecuteReaderAsync())
                    {
                        while (await dataReader.ReadAsync())
                        {
                            var dataRow = new ExpandoObject() as IDictionary<string, object>;
                            for (var iFiled = 0; iFiled < dataReader.FieldCount; iFiled++)
                            {
                                dataRow.Add(
                                    dataReader.GetName(iFiled),
                                    dataReader.IsDBNull(iFiled) ? null : dataReader[iFiled] // use null instead of {}
                                );
                            }

                            retObject.Add((ExpandoObject)dataRow);
                        }
                    }
                    return retObject;
                }
            }
            return "[]";
        }

        // GET: api/Negocios/loginMovil/
        [HttpGet("{nombreLog}&{contrasenaLog}")]
        [ActionName("loginMovil")]
        public async Task<ActionResult<object>> loginMovil(string nombreLog, string contrasenaLog)
        {
            if (nombreLog != null && contrasenaLog != null)
            {
                using (var cmd = _context.Database.GetDbConnection().CreateCommand())
                {
                    cmd.CommandText = "Proc_LoginNegocioMovil";
                    cmd.CommandType = CommandType.StoredProcedure;
                    // set some parameters of the stored procedure
                    cmd.Parameters.Add(new SqlParameter("@nombre_negocio",
                        SqlDbType.VarChar)
                    { Value = nombreLog });
                    cmd.Parameters.Add(new SqlParameter("@contrasena",
                        SqlDbType.VarChar)
                    { Value = contrasenaLog });

                    if (cmd.Connection.State != ConnectionState.Open)
                        cmd.Connection.Open();

                    var retObject = new List<dynamic>();
                    using (var dataReader = await cmd.ExecuteReaderAsync())
                    {
                        while (await dataReader.ReadAsync())
                        {
                            var dataRow = new ExpandoObject() as IDictionary<string, object>;
                            for (var iFiled = 0; iFiled < dataReader.FieldCount; iFiled++)
                            {
                                dataRow.Add(
                                    dataReader.GetName(iFiled),
                                    dataReader.IsDBNull(iFiled) ? null : dataReader[iFiled] // use null instead of {}
                                );
                            }

                            retObject.Add((ExpandoObject)dataRow);
                        }
                    }
                    return retObject;
                }
            }
            return "[]";
        }

        // GET: api/Negocios/loginCliente/
        [HttpGet("{nombreLog}&{contrasenaLog}")]
        [ActionName("loginCliente")]
        public async Task<ActionResult<object>> loginCliente(string nombreLog, string contrasenaLog)
        {
            if (nombreLog != null && contrasenaLog != null)
            {
                using (var cmd = _context.Database.GetDbConnection().CreateCommand())
                {
                    cmd.CommandText = "Proc_LoginCliente";
                    cmd.CommandType = CommandType.StoredProcedure;
                    // set some parameters of the stored procedure
                    cmd.Parameters.Add(new SqlParameter("@nombreCliente",
                        SqlDbType.VarChar)
                    { Value = nombreLog });
                    cmd.Parameters.Add(new SqlParameter("@contrasena",
                        SqlDbType.VarChar)
                    { Value = contrasenaLog });

                    if (cmd.Connection.State != ConnectionState.Open)
                        cmd.Connection.Open();

                    var retObject = new List<dynamic>();
                    using (var dataReader = await cmd.ExecuteReaderAsync())
                    {
                        while (await dataReader.ReadAsync())
                        {
                            var dataRow = new ExpandoObject() as IDictionary<string, object>;
                            for (var iFiled = 0; iFiled < dataReader.FieldCount; iFiled++)
                            {
                                dataRow.Add(
                                    dataReader.GetName(iFiled),
                                    dataReader.IsDBNull(iFiled) ? null : dataReader[iFiled] // use null instead of {}
                                );
                            }

                            retObject.Add((ExpandoObject)dataRow);
                        }
                    }
                    return retObject;
                }
            }
            return "[]";
        }


        //GET: api/Negocios/registrar/
        [HttpGet("{nombre}&{contrasena}&{descripcion}&{ubicacion}&{telefono}&{correo}&{horarioA}&{horarioC}&{capacidadMaxima}&{porcentajePermitido}")]
        [ActionName("registrar")]
        public async Task<ActionResult<object>> registrarNegocio(string nombre, string contrasena, string descripcion, string ubicacion, string telefono, string correo, TimeSpan horarioA, TimeSpan horarioC, int capacidadMaxima, int porcentajePermitido)
        {
            if (nombre!=null && contrasena!=null && descripcion!=null && ubicacion!=null && telefono!=null && correo!=null && horarioA!=null && horarioC!=null && capacidadMaxima!=0 && porcentajePermitido!=0) {
                using (var cmd = _context.Database.GetDbConnection().CreateCommand())
                {
                    cmd.CommandText = "Proc_RegistrarNegocio";
                    cmd.CommandType = CommandType.StoredProcedure;
                    // set some parameters of the stored procedure
                    cmd.Parameters.Add(new SqlParameter("@nombre_negocio",
                        SqlDbType.VarChar)
                    { Value = nombre });

                    cmd.Parameters.Add(new SqlParameter("@contrasena",
                        SqlDbType.VarChar)
                    { Value = contrasena });

                    cmd.Parameters.Add(new SqlParameter("@descripcion",
                       SqlDbType.VarChar)
                    { Value = descripcion });

                    cmd.Parameters.Add(new SqlParameter("@ubicacion",
                       SqlDbType.VarChar)
                    { Value = ubicacion });

                    cmd.Parameters.Add(new SqlParameter("@telefono",
                       SqlDbType.VarChar)
                    { Value = telefono });

                    cmd.Parameters.Add(new SqlParameter("@correo",
                       SqlDbType.VarChar)
                    { Value = correo });

                    cmd.Parameters.Add(new SqlParameter("@horarioA",
                       SqlDbType.Time)
                    { Value = horarioA });

                    cmd.Parameters.Add(new SqlParameter("@horarioC",
                       SqlDbType.Time)
                    { Value = horarioC });

                    cmd.Parameters.Add(new SqlParameter("@capacidad_maxima",
                       SqlDbType.Int)
                    { Value = capacidadMaxima });

                    cmd.Parameters.Add(new SqlParameter("@porcentaje_permitido ",
                        SqlDbType.Int)
                    { Value = porcentajePermitido });


                    if (cmd.Connection.State != ConnectionState.Open)
                        cmd.Connection.Open();

                    await cmd.ExecuteReaderAsync();

                    return "[]";
                }
            }
            return "[]";
        }

        //GET: api/Negocios/actualizar/
        [HttpGet("{nombre}&{descripcion}&{horarioA}&{horarioC}&{capacidadMaxima}&{porcentajePermitido}")]
        [ActionName("actualizar")]
        public async Task<ActionResult<object>> actualizarNegocio(string nombre, string descripcion, TimeSpan horarioA, TimeSpan horarioC, int capacidadMaxima, int porcentajePermitido)
        {
            if (nombre != null && descripcion != null && horarioA != null && horarioC != null && capacidadMaxima != 0 && porcentajePermitido != 0)
            {
                using (var cmd = _context.Database.GetDbConnection().CreateCommand())
                {
                    cmd.CommandText = "Proc_ActualizarNegocio";
                    cmd.CommandType = CommandType.StoredProcedure;
                    // set some parameters of the stored procedure
                    cmd.Parameters.Add(new SqlParameter("@nombre_negocio",
                        SqlDbType.VarChar)
                    { Value = nombre });

                    cmd.Parameters.Add(new SqlParameter("@descripcion",
                       SqlDbType.VarChar)
                    { Value = descripcion });

                    cmd.Parameters.Add(new SqlParameter("@horarioA",
                       SqlDbType.Time)
                    { Value = horarioA });

                    cmd.Parameters.Add(new SqlParameter("@horarioC",
                       SqlDbType.Time)
                    { Value = horarioC });

                    cmd.Parameters.Add(new SqlParameter("@capacidad_maxima",
                       SqlDbType.Int)
                    { Value = capacidadMaxima });

                    cmd.Parameters.Add(new SqlParameter("@porcentaje_permitido ",
                        SqlDbType.Int)
                    { Value = porcentajePermitido });


                    if (cmd.Connection.State != ConnectionState.Open)
                        cmd.Connection.Open();

                    var retObject = new List<dynamic>();
                    using (var dataReader = await cmd.ExecuteReaderAsync())
                    {
                        while (await dataReader.ReadAsync())
                        {
                            var dataRow = new ExpandoObject() as IDictionary<string, object>;
                            for (var iFiled = 0; iFiled < dataReader.FieldCount; iFiled++)
                            {
                                dataRow.Add(
                                    dataReader.GetName(iFiled),
                                    dataReader.IsDBNull(iFiled) ? null : dataReader[iFiled] // use null instead of {}
                                );
                            }

                            retObject.Add((ExpandoObject)dataRow);
                        }
                    }
                    return retObject;

                }
                
            }
            return "[]";
        }

        // GET: api/Negocios/getNegocios/
        [HttpGet()]
        [ActionName("getNegocios")]
        public async Task<ActionResult<object>> getNegocios()
        {
            using (var cmd = _context.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = "Proc_GetNegocios";
                cmd.CommandType = CommandType.StoredProcedure;
                // set some parameters of the stored procedure


                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                var retObject = new List<dynamic>();
                using (var dataReader = await cmd.ExecuteReaderAsync())
                {
                    while (await dataReader.ReadAsync())
                    {
                        var dataRow = new ExpandoObject() as IDictionary<string, object>;
                        for (var iFiled = 0; iFiled < dataReader.FieldCount; iFiled++)
                        {
                            dataRow.Add(
                                dataReader.GetName(iFiled),
                                dataReader.IsDBNull(iFiled) ? null : dataReader[iFiled] // use null instead of {}
                            );
                        }

                        retObject.Add((ExpandoObject)dataRow);
                    }
                }
                return retObject;

            }
        }


        // GET: api/Negocios/getNegociosMovil/
        [HttpGet()]
        [ActionName("getNegociosMovil")]
        public async Task<ActionResult<object>> getNegociosMovil()
        {
            using (var cmd = _context.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = "Proc_GetNegociosMovil";
                cmd.CommandType = CommandType.StoredProcedure;
                // set some parameters of the stored procedure


                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                var retObject = new List<dynamic>();
                using (var dataReader = await cmd.ExecuteReaderAsync())
                {
                    while (await dataReader.ReadAsync())
                    {
                        var dataRow = new ExpandoObject() as IDictionary<string, object>;
                        for (var iFiled = 0; iFiled < dataReader.FieldCount; iFiled++)
                        {
                            dataRow.Add(
                                dataReader.GetName(iFiled),
                                dataReader.IsDBNull(iFiled) ? null : dataReader[iFiled] // use null instead of {}
                            );
                        }

                        retObject.Add((ExpandoObject)dataRow);
                    }
                }
                return retObject;

            }
        }

        // GET: api/Negocios/getNegocioNombre/
        [HttpGet("{nombre}")]
        [ActionName("getNegocioNombre")]
        public async Task<ActionResult<object>> getNegocioNombre(string nombre)
        {
            if (nombre != null)
            {
                using (var cmd = _context.Database.GetDbConnection().CreateCommand())
                {
                    cmd.CommandText = "Proc_GetNegocioNombre";
                    cmd.CommandType = CommandType.StoredProcedure;
                    // set some parameters of the stored procedure
                    cmd.Parameters.Add(new SqlParameter("@nombre_negocio",
                        SqlDbType.VarChar)
                    { Value = nombre });
 

                    if (cmd.Connection.State != ConnectionState.Open)
                        cmd.Connection.Open();

                    var retObject = new List<dynamic>();
                    using (var dataReader = await cmd.ExecuteReaderAsync())
                    {
                        while (await dataReader.ReadAsync())
                        {
                            var dataRow = new ExpandoObject() as IDictionary<string, object>;
                            for (var iFiled = 0; iFiled < dataReader.FieldCount; iFiled++)
                            {
                                dataRow.Add(
                                    dataReader.GetName(iFiled),
                                    dataReader.IsDBNull(iFiled) ? null : dataReader[iFiled] // use null instead of {}
                                );
                            }

                            retObject.Add((ExpandoObject)dataRow);
                        }
                    }
                    return retObject;
                }
            }
            return "[]";
        }

        // GET: api/Negocios/getNegocioNombreMovil/
        [HttpGet("{nombre}")]
        [ActionName("getNegocioNombreMovil")]
        public async Task<ActionResult<object>> getNegocioNombreMovil(string nombre)
        {
            if (nombre != null)
            {
                using (var cmd = _context.Database.GetDbConnection().CreateCommand())
                {
                    cmd.CommandText = "Proc_GetNegocioNombreMovil";
                    cmd.CommandType = CommandType.StoredProcedure;
                    // set some parameters of the stored procedure
                    cmd.Parameters.Add(new SqlParameter("@nombre_negocio",
                        SqlDbType.VarChar)
                    { Value = nombre });


                    if (cmd.Connection.State != ConnectionState.Open)
                        cmd.Connection.Open();

                    var retObject = new List<dynamic>();
                    using (var dataReader = await cmd.ExecuteReaderAsync())
                    {
                        while (await dataReader.ReadAsync())
                        {
                            var dataRow = new ExpandoObject() as IDictionary<string, object>;
                            for (var iFiled = 0; iFiled < dataReader.FieldCount; iFiled++)
                            {
                                dataRow.Add(
                                    dataReader.GetName(iFiled),
                                    dataReader.IsDBNull(iFiled) ? null : dataReader[iFiled] // use null instead of {}
                                );
                            }

                            retObject.Add((ExpandoObject)dataRow);
                        }
                    }
                    return retObject;
                }
            }
            return "[]";
        }


        // GET: api/Negocios/reservar/
        [HttpGet("{codSesion}&{nombreCliente}")]
        [ActionName("reservar")]
        public async Task<ActionResult<object>> reservar(int codSesion, string nombreCliente)
        {
            if (codSesion >-1 && nombreCliente !=null)
            {
                using (var cmd = _context.Database.GetDbConnection().CreateCommand())
                {
                    cmd.CommandText = "Proc_registraReserva";
                    cmd.CommandType = CommandType.StoredProcedure;
                    // set some parameters of the stored procedure
                    cmd.Parameters.Add(new SqlParameter("@codSesion",
                        SqlDbType.VarChar)
                    { Value = codSesion });

                    cmd.Parameters.Add(new SqlParameter("@nombreCliente",
                        SqlDbType.VarChar)
                    { Value = @nombreCliente });


                    if (cmd.Connection.State != ConnectionState.Open)
                        cmd.Connection.Open();

                    var retObject = new List<dynamic>();
                    using (var dataReader = await cmd.ExecuteReaderAsync())
                    {
                        while (await dataReader.ReadAsync())
                        {
                            var dataRow = new ExpandoObject() as IDictionary<string, object>;
                            for (var iFiled = 0; iFiled < dataReader.FieldCount; iFiled++)
                            {
                                dataRow.Add(
                                    dataReader.GetName(iFiled),
                                    dataReader.IsDBNull(iFiled) ? null : dataReader[iFiled] // use null instead of {}
                                );
                            }

                            retObject.Add((ExpandoObject)dataRow);
                        }
                    }
                    return retObject;
                }
            }
            return "[]";
        }

        // GET: api/Negocios/consultaFecha/
        [HttpGet("{nombre}&{fecha}")]
        [ActionName("consultaFecha")]
        public async Task<ActionResult<object>> consultaFecha(string nombre, string fecha)
        {
            if (nombre != null)
            {
                using (var cmd = _context.Database.GetDbConnection().CreateCommand())
                {
                    cmd.CommandText = "Proc_consultaFecha";
                    cmd.CommandType = CommandType.StoredProcedure;
                    // set some parameters of the stored procedure
                    cmd.Parameters.Add(new SqlParameter("@nombre",
                        SqlDbType.VarChar)
                    { Value = nombre });

                    cmd.Parameters.Add(new SqlParameter("@fecha",
                       SqlDbType.VarChar)
                    { Value = fecha });


                    if (cmd.Connection.State != ConnectionState.Open)
                        cmd.Connection.Open();

                    var retObject = new List<dynamic>();
                    using (var dataReader = await cmd.ExecuteReaderAsync())
                    {
                        while (await dataReader.ReadAsync())
                        {
                            var dataRow = new ExpandoObject() as IDictionary<string, object>;
                            for (var iFiled = 0; iFiled < dataReader.FieldCount; iFiled++)
                            {
                                dataRow.Add(
                                    dataReader.GetName(iFiled),
                                    dataReader.IsDBNull(iFiled) ? null : dataReader[iFiled] // use null instead of {}
                                );
                            }

                            retObject.Add((ExpandoObject)dataRow);
                        }
                    }
                    return retObject;
                }
            }
            return "[]";
        }


        // GET: api/Negocios/listarReserva/
        [HttpGet("{nombre}&{fechaI}&{fechaF}")]
        [ActionName("listarReserva")]
        public async Task<ActionResult<object>> listarReserva(string nombre, string fechaI, string fechaF)
        {
            if (nombre != null && fechaI != null && fechaF !=null)
            {
                using (var cmd = _context.Database.GetDbConnection().CreateCommand())
                {
                    cmd.CommandText = "Proc_ListarReserva";
                    cmd.CommandType = CommandType.StoredProcedure;
                    // set some parameters of the stored procedure
                    cmd.Parameters.Add(new SqlParameter("@nombre",
                        SqlDbType.VarChar)
                    { Value = nombre });

                    cmd.Parameters.Add(new SqlParameter("@fechaI",
                       SqlDbType.VarChar)
                    { Value = fechaI });

                    cmd.Parameters.Add(new SqlParameter("@fechaF",
                       SqlDbType.VarChar)
                    { Value = fechaF });


                    if (cmd.Connection.State != ConnectionState.Open)
                        cmd.Connection.Open();

                    var retObject = new List<dynamic>();
                    using (var dataReader = await cmd.ExecuteReaderAsync())
                    {
                        while (await dataReader.ReadAsync())
                        {
                            var dataRow = new ExpandoObject() as IDictionary<string, object>;
                            for (var iFiled = 0; iFiled < dataReader.FieldCount; iFiled++)
                            {
                                dataRow.Add(
                                    dataReader.GetName(iFiled),
                                    dataReader.IsDBNull(iFiled) ? null : dataReader[iFiled] // use null instead of {}
                                );
                            }

                            retObject.Add((ExpandoObject)dataRow);
                        }
                    }
                    return retObject;
                }
            }
            return "[]";
        }
        // GET: api/Negocios/consultaClaseOnline/
        [HttpGet("{nombre}")]
        [ActionName("consultaClaseOnline")]
        public async Task<ActionResult<object>> consultaClaseOnline(string nombre)
        {
            if (nombre != null)
            {
                using (var cmd = _context.Database.GetDbConnection().CreateCommand())
                {
                    cmd.CommandText = "Proc_claseOnline";
                    cmd.CommandType = CommandType.StoredProcedure;
                    // set some parameters of the stored procedure
                    cmd.Parameters.Add(new SqlParameter("@nombre",
                        SqlDbType.VarChar)
                    { Value = nombre });


                    if (cmd.Connection.State != ConnectionState.Open)
                        cmd.Connection.Open();

                    var retObject = new List<dynamic>();
                    using (var dataReader = await cmd.ExecuteReaderAsync())
                    {
                        while (await dataReader.ReadAsync())
                        {
                            var dataRow = new ExpandoObject() as IDictionary<string, object>;
                            for (var iFiled = 0; iFiled < dataReader.FieldCount; iFiled++)
                            {
                                dataRow.Add(
                                    dataReader.GetName(iFiled),
                                    dataReader.IsDBNull(iFiled) ? null : dataReader[iFiled] // use null instead of {}
                                );
                            }

                            retObject.Add((ExpandoObject)dataRow);
                        }
                    }
                    return retObject;
                }
            }
            return "[]";
        }

        // GET: api/Negocios/consultaClaseOnlineMovil/
        [HttpGet("{nombre}")]
        [ActionName("consultaClaseOnlineMovil")]
        public async Task<ActionResult<object>> consultaClaseOnlineMovil(string nombre)
        {
            if (nombre != null)
            {
                using (var cmd = _context.Database.GetDbConnection().CreateCommand())
                {
                    cmd.CommandText = "Proc_claseOnlineMovil";
                    cmd.CommandType = CommandType.StoredProcedure;
                    // set some parameters of the stored procedure
                    cmd.Parameters.Add(new SqlParameter("@nombre",
                        SqlDbType.VarChar)
                    { Value = nombre });


                    if (cmd.Connection.State != ConnectionState.Open)
                        cmd.Connection.Open();

                    var retObject = new List<dynamic>();
                    using (var dataReader = await cmd.ExecuteReaderAsync())
                    {
                        while (await dataReader.ReadAsync())
                        {
                            var dataRow = new ExpandoObject() as IDictionary<string, object>;
                            for (var iFiled = 0; iFiled < dataReader.FieldCount; iFiled++)
                            {
                                dataRow.Add(
                                    dataReader.GetName(iFiled),
                                    dataReader.IsDBNull(iFiled) ? null : dataReader[iFiled] // use null instead of {}
                                );
                            }

                            retObject.Add((ExpandoObject)dataRow);
                        }
                    }
                    return retObject;
                }
            }
            return "[]";
        }

        // GET: api/Negocios/insertClaseOnline/
        [HttpGet("{nombreGym}&{nombreClase}&{fecha}&{hora}")]
        [ActionName("insertClaseOnline")]
        public async Task<ActionResult<object>> insertClaseOnline(string nombreGym, string nombreClase, string fecha, TimeSpan hora)
        {
            if (nombreGym != null && nombreClase != null && fecha != null && hora != null)
            {
                using (var cmd = _context.Database.GetDbConnection().CreateCommand())
                {
                    cmd.CommandText = "Proc_InsertclaseOnline";
                    cmd.CommandType = CommandType.StoredProcedure;
                    // set some parameters of the stored procedure
                    cmd.Parameters.Add(new SqlParameter("@nombreGym",
                        SqlDbType.VarChar)
                    { Value = nombreGym });

                    cmd.Parameters.Add(new SqlParameter("@nombreClase",
                        SqlDbType.VarChar)
                    { Value = nombreClase });

                    cmd.Parameters.Add(new SqlParameter("@fecha",
                       SqlDbType.VarChar)
                    { Value = fecha });

                    cmd.Parameters.Add(new SqlParameter("@hora",
                       SqlDbType.Time)
                    { Value = hora });



                    if (cmd.Connection.State != ConnectionState.Open)
                        cmd.Connection.Open();

                    var retObject = new List<dynamic>();
                    using (var dataReader = await cmd.ExecuteReaderAsync())
                    {
                        while (await dataReader.ReadAsync())
                        {
                            var dataRow = new ExpandoObject() as IDictionary<string, object>;
                            for (var iFiled = 0; iFiled < dataReader.FieldCount; iFiled++)
                            {
                                dataRow.Add(
                                    dataReader.GetName(iFiled),
                                    dataReader.IsDBNull(iFiled) ? null : dataReader[iFiled] // use null instead of {}
                                );
                            }

                            retObject.Add((ExpandoObject)dataRow);
                        }
                    }
                    return retObject;
                }
            }
            return "[]";
        }

        // GET: api/Negocios/verResumen/
        [HttpGet("{nombre}&{fecha1}&{fecha2}")]
        [ActionName("verResumen")]
        public async Task<ActionResult<object>> verResumen(string nombre, string fecha1, string fecha2)
        {
            if (nombre != null && fecha1 != null && fecha2 != null)
            {
                using (var cmd = _context.Database.GetDbConnection().CreateCommand())
                {
                    cmd.CommandText = "Proc_verResumen";
                    cmd.CommandType = CommandType.StoredProcedure;
                    // set some parameters of the stored procedure
                    cmd.Parameters.Add(new SqlParameter("@nombre",
                        SqlDbType.VarChar)
                    { Value = nombre });

                    cmd.Parameters.Add(new SqlParameter("@fecha1",
                       SqlDbType.VarChar)
                    { Value = fecha1 });

                    cmd.Parameters.Add(new SqlParameter("@fecha2",
                       SqlDbType.VarChar)
                    { Value = fecha2 });


                    if (cmd.Connection.State != ConnectionState.Open)
                        cmd.Connection.Open();

                    var retObject = new List<dynamic>();
                    using (var dataReader = await cmd.ExecuteReaderAsync())
                    {
                        while (await dataReader.ReadAsync())
                        {
                            var dataRow = new ExpandoObject() as IDictionary<string, object>;
                            for (var iFiled = 0; iFiled < dataReader.FieldCount; iFiled++)
                            {
                                dataRow.Add(
                                    dataReader.GetName(iFiled),
                                    dataReader.IsDBNull(iFiled) ? null : dataReader[iFiled] // use null instead of {}
                                );
                            }

                            retObject.Add((ExpandoObject)dataRow);
                        }
                    }
                    return retObject;
                }
            }
            return "[]";
        }

        // PUT: api/Negocios/5----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNegocio(int id, Negocio negocio)
        {
            if (id != negocio.IdNegocio)
            {
                return BadRequest();
            }

            _context.Entry(negocio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NegocioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Negocios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Negocio>> PostNegocio(Negocio negocio)
        {
            _context.Negocio.Add(negocio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNegocio", new { id = negocio.IdNegocio }, negocio);
        }

        // DELETE: api/Negocios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Negocio>> DeleteNegocio(int id)
        {
            var negocio = await _context.Negocio.FindAsync(id);
            if (negocio == null)
            {
                return NotFound();
            }

            _context.Negocio.Remove(negocio);
            await _context.SaveChangesAsync();

            return negocio;
        }

        private bool NegocioExists(int id)
        {
            return _context.Negocio.Any(e => e.IdNegocio == id);
        }
    }
}
