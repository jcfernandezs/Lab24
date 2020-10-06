using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace ProyWin_Lab24
{
    public class conexion
    {
        private String cadena = "Data Source=.; Initial Catalog=pubs; Integrated Security = True";

        public List<curso> CursoListar()
        {
            List<curso> lstCursos = new List<curso>();
            try
            {
                SqlConnection conn = new SqlConnection(cadena);
                SqlDataAdapter da = new SqlDataAdapter("select * from cursos", conn);
                da.SelectCommand.CommandType = CommandType.Text;
                DataSet ds = new DataSet();
                da.Fill(ds, "cursos");
                for (int i = 0; i < (int)ds.Tables[0].Rows.Count; i++)
                {
                    curso objCurso = new curso();
                    objCurso.Nombre = ds.Tables[0].Rows[i]["nombre"].ToString();
                    objCurso.Duracion = Convert.ToInt32(ds.Tables[0].Rows[i]["duracion"].ToString());
                    objCurso.Descripcion = ds.Tables[0].Rows[i]["descripcion"].ToString();
                    lstCursos.Add(objCurso);
                }
                ds.Dispose();
                da.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstCursos;
        }

        public int CursoInsertar(curso objCurso)
        {
            try
            {
                SqlConnection conn = new SqlConnection(cadena);
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into cursos (nombre, duracion, descripcion) values(@Nombre, @Duracion, @Descripcion)", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Nombre", objCurso.Nombre);
                cmd.Parameters.AddWithValue("@Duracion", objCurso.Duracion);
                cmd.Parameters.AddWithValue("@Descripcion", objCurso.Descripcion);
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Insertado Exitosamente");
            }
            catch (Exception ex)
            {
                return 0;
            }
            return 1;
        }
        public int CursoEliminar(String nombre)
        {
            try
            {
                SqlConnection conn = new SqlConnection(cadena);
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from cursos where nombre = @Nombre", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Curso eliminado exitosamente");
            }
            catch (Exception ex)
            {
                return 0;
            }
            return 1;
        }
        public int CursoEditar(curso objCurso)
        {
            try
            {
                SqlConnection conn = new SqlConnection(cadena);
                conn.Open();
                SqlCommand cmd = new SqlCommand("update cursos set Descripcion = @Descripcion, Duracion = @Duracion where Nombre = @Nombre", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Nombre", objCurso.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", objCurso.Descripcion);
                cmd.Parameters.AddWithValue("@Duracion", objCurso.Duracion);
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Curso editado satisfactoriamente");
            }
            catch (Exception ex)
            {
                return 0;
            }
            return 1;
        }
    }
}
