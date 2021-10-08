using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revista.Models
{
    public class ClsMensaje
    {
        int id_men { set; get; }
        String fecha { set; get; }
        String email_dest { set; get; }
        String ced { set; get; }
        String asunto { set; get; }
        String mensaje { set; get; }

        NpgsqlConnection cone; //Se agrega para variable tipo NpgsqlConnection

        public ClsMensaje(int id_men, string fecha, string email_dest, string ced, string asunto, string mensaje)
        {
            this.id_men = id_men;
            this.fecha = fecha;
            this.email_dest = email_dest;
            this.ced = ced;
            this.asunto = asunto;
            this.mensaje = mensaje;
        }

        public void conectar()
        {
            this.cone = new NpgsqlConnection("Server= 127.0.0.1; User Id=admin; Password=123; Database=RevistaDB ");
            this.cone.Open();
        }
        public String ingresarMensaje()
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                String sql = "INSERT INTO mensaje VALUES (DEFAULT,'" + this.fecha + "','" + this.email_dest + "','" + this.ced + "','" + this.asunto + "','" + this.mensaje + "')";
                cmd = new NpgsqlCommand(sql, this.cone);
                cmd.ExecuteNonQuery();
                return "Mensjae ingresado satisfactoriamente";

            }
            catch (Exception)
            {
                return "Error, los datos no fueron guardados";
            }

        }

        public String eliminarMensaje()
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                String sql = "DELETE FROM mensaje WHERE id_mensaje = " + this.id_men;
                cmd = new NpgsqlCommand(sql, this.cone);
                cmd.ExecuteNonQuery();
                return "Mensaje eliminado satisfactoriamente";

            }
            catch (Exception)
            {
                return "Error, el mensaje no fue eliminado";
            }

        }
    }
}
