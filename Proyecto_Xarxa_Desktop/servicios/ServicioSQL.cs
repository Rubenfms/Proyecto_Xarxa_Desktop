using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Xarxa_Desktop.servicios
{
    class ServicioSQL
    {
        // Devuelve el último lote registrado con X numero de curso y X modalidad
        public static int HallarUltLote(int numeroCurso, int numeroModalidad)
        {
            // Conexión a BD
            using (MySqlConnection cn = new MySqlConnection("server = 127.0.0.1; database = bdxarxa; Uid = root; pwd =1234"))
            {
                cn.Open();

                // Creamos la query y la ejecutamos
                MySqlDataReader dr = new MySqlCommand($"select id_lote from lote where id_lote LIKE '{numeroCurso}{numeroModalidad}%' ORDER BY 1 DESC LIMIT 1;", cn).ExecuteReader();

                if (dr.Read())
                {
                    return Int32.Parse(dr[0].ToString()) + 1; // Devolvemos el último lote registrado + 1 que será el próximo número libre
                }
                else return 1;
            }
        }
    }
}
