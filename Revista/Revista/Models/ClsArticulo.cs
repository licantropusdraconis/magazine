using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revista.Models
{
    public class ClsArticulo
    {
        int id_art { set; get; }
        String ced { set; get; }
        String titulo { set; get; }
        String desc { set; get; }
        String cont { set; get; }
        Boolean estado { set; get; }
        String fecha { set; get; }

        NpgsqlConnection cone; //Se agrega para variable tipo NpgsqlConnection

        public ClsArticulo(int id_art, string ced, string titulo, string desc, string cont, bool estado, string fecha)
        {
            this.id_art = id_art;
            this.ced = ced;
            this.titulo = titulo;
            this.desc = desc;
            this.cont = cont;
            this.estado = estado;
            this.fecha = fecha;
        }

        public void conectar()
        {
            this.cone = new NpgsqlConnection("Server= 127.0.0.1; User Id=admin; Password=123; Database=RevistaDB ");
            this.cone.Open();
        }
        public String ingresarArticulo()
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                String sql = "INSERT INTO articulo VALUES (DEFAULT,'" + this.ced + "','" + this.titulo + "','" + this.desc + "','" + this.cont + "'," + this.estado + ",'" + this.fecha + "')";
                cmd = new NpgsqlCommand(sql, this.cone);
                cmd.ExecuteNonQuery();
                return "Datos ingresados satisfactoriamente";

            }
            catch (Exception)
            {
                return "Error, los datos no fueron guardados";
            }

        }

        public String eliminarArticulo()
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                String sql = "DELETE FROM articulo WHERE cedula = '" + this.ced + "' and titulo = '"+this.titulo+"'" ;
                cmd = new NpgsqlCommand(sql, this.cone);
                cmd.ExecuteNonQuery();
                return "Articulo eliminado satisfactoriamente";

            }
            catch (Exception e)
            {
                return "Error, el articulo no fue eliminado. "+e;
            }

        }

    }
}
