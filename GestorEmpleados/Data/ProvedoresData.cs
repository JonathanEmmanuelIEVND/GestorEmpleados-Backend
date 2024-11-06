using GestorEmpleados.API.Models;
using Microsoft.EntityFrameworkCore;
using MiWebAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace MiWebAPI.Data
{
    public class ProvedorData
    {

        private readonly string conexion;
        public ProvedorData(IConfiguration configuration)
        {
            conexion = configuration.GetConnectionString("CadenaSQL")!;
        }


        /// <summary>
        /// Consulta lista de empleados
        /// </summary>
        /// <returns></returns>
        public async Task<List<Provedor>> GetProvedor(string filtro)
        {
            List<Provedor> lista = new List<Provedor>();

            using (var con = new SqlConnection(conexion))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("SP_SELECIONARPROVEDOR", con);
                cmd.Parameters.AddWithValue("@filtro", filtro);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        lista.Add(new Provedor
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nombre = reader["NombreCompleto"].ToString(),
                            Direccion = reader["Direccion"].ToString(),
                            Telefono = Convert.ToInt32(reader["Telefono"]),
                            Edad = Convert.ToInt32(reader["Edad"]),
                            Empresa = reader["Empresa"].ToString(),




                        });
                    }
                }
            }
            return lista;
        }

        /// <summary>
        /// Agrega un empleado
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public async Task<RespuestaDB> AddProvedor(Provedor objeto)
        {
            var resultado = new RespuestaDB();

            using (var con = new SqlConnection(conexion))
            {

                SqlCommand cmd = new SqlCommand("SP_AgregarProvedores", con);
                cmd.Parameters.AddWithValue("@Nombre", objeto.Nombre);
                cmd.Parameters.AddWithValue("@ApellidoPaterno", objeto.ApellidoPaterno);
                cmd.Parameters.AddWithValue("@ApellidoMaterno", objeto.ApellidoMaterno);
                cmd.Parameters.AddWithValue("@Direccion", objeto.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", objeto.Telefono);
                cmd.Parameters.AddWithValue("@Edad", objeto.Edad);
                cmd.Parameters.AddWithValue("@Empresa", objeto.Empresa);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {

                        resultado.TipoError = Convert.ToInt32(reader["TipoError"]);
                        resultado.Mensaje = reader["Mensaje"].ToString();


                    }
                }

            }
            return resultado;
        }

        public async Task<RespuestaDB> UpdateProvedor(Provedor objeto)
        {
            var resultado = new RespuestaDB();

            using (var con = new SqlConnection(conexion))
            {

                SqlCommand cmd = new SqlCommand("SP_ActualizarProvedor", con);
                cmd.Parameters.AddWithValue("@id", objeto.Id);
                cmd.Parameters.AddWithValue("@Nombre", objeto.Nombre);
                cmd.Parameters.AddWithValue("@ApellidoPaterno", objeto.ApellidoPaterno);
                cmd.Parameters.AddWithValue("@ApellidoMaterno", objeto.ApellidoMaterno);
                cmd.Parameters.AddWithValue("@Direccion", objeto.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", objeto.Telefono);
                cmd.Parameters.AddWithValue("@Edad", objeto.Edad);
                cmd.Parameters.AddWithValue("@Empresa", objeto.Empresa);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {

                        resultado.TipoError = Convert.ToInt32(reader["TipoError"]);
                        resultado.Mensaje = reader["Mensaje"].ToString();


                    }
                }

            }
            return resultado;
        }

        public async Task<RespuestaDB> DeleteProvedor(int Id)
        {
            var resultado = new RespuestaDB();

            using (var con = new SqlConnection(conexion))
            {

                SqlCommand cmd = new SqlCommand("SP_EliminarProvedor", con);
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {

                        resultado.TipoError = Convert.ToInt32(reader["TipoError"]);
                        resultado.Mensaje = reader["Mensaje"].ToString();


                    }
                }

            }
            return resultado;
        }

    }
}
