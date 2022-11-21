using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace CL
{
    public class Abm
    {
        public int id_pel { get; set; }
        public int id_director { get; set; }
        public int id_categoria { get; set; }
        public int id_productora { get; set; }
        public string titulo { get; set; }
        public string desc_pel { get; set; }
        public int cant_pel { get; set; }
        public int anio_pel { get; set; }
        public string Peliculas { get; set; }

        #region "Metodos"
        public bool Alta(Abm dato)
        {
            var conn = new OleDbConnection();
            var comando = new OleDbCommand();


            var base_de_datos = new Conexion();
            //variable que va a mostrar si se pudo hacer el alta del registo en la BD
            bool rta;

            try
            {
                conn = base_de_datos.Abrir();
                comando.Connection = conn;
                comando.CommandText = "INSERT INTO" + dato.Peliculas + " (titulo) VALUES ('" + dato.titulo + "')";
                comando.ExecuteNonQuery();
                rta = true;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(String.Concat(Ex.Message, Ex.StackTrace), "");
                rta = false;
            }
            finally 
            {
                if (conn.State == ConnectionState.Open) 
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return rta;
        }

        public bool Baja(Abm dato)
        {
            var conn = new OleDbConnection();
            var comando = new OleDbCommand();

            var base_de_datos = new Conexion();
            //variable que va a mostrar si se pudo hacer el alta del registo en la BD
            bool rta;

            try
            {
                conn = base_de_datos.Abrir();
                comando.Connection = conn;
                comando.CommandText = "DELETE FROM" +dato.Peliculas+ "WHERE titulo =" +dato.titulo;
                comando.ExecuteNonQuery();
                rta = true;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(String.Concat(Ex.Message, Ex.StackTrace), "");
                rta = false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return rta;
        }

        public bool Modificar(Abm dato)
        {
            var conn = new OleDbConnection();
            var comando = new OleDbCommand();

            var base_de_datos = new Conexion();
            //variable que va a mostrar si se pudo hacer el alta del registo en la BD
            bool rta;

            try
            {
                conn = base_de_datos.Abrir();
                comando.Connection = conn;
                comando.CommandText = "UPDATE" +dato.Peliculas+ "SET titulo='"+dato.titulo+"' WHERE id_pel=" +dato.id_pel;
                comando.ExecuteNonQuery();
                rta = true;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(String.Concat(Ex.Message, Ex.StackTrace), "");
                rta = false;
            }finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return rta;
        }

        public List<Abm>Listar (Abm dato)
        {
            var conn = new OleDbConnection();
            var comando = new OleDbCommand();
            var base_de_datos = new Conexion();
            var lista = new List<Abm>();

            try
            {
                conn = base_de_datos.Abrir();
                comando.Connection = conn;
                comando.CommandText = "SELECT id_pel,id_director,id_categoria,id_productora,titulo,desc_pel,cant_pel,anio_pel FROM"+dato.Peliculas;
                var rdr = comando.ExecuteReader();
                while (rdr != null && rdr.Read()) 
                {
                    var registro = new Abm();
                    registro.id_pel = (int)rdr["id_pel"];
                    registro.id_director = (int)rdr["id_director"];
                    registro.id_productora = (int)rdr["id_productora"];
                    registro.id_categoria = (int)rdr["id_categoria"];
                    registro.titulo = (string)rdr["titulo"];
                    registro.desc_pel = (string)rdr["desc_pel"];
                    registro.cant_pel = (int)rdr["cant_pel"];
                    registro.anio_pel = (int)rdr["anio_pel"];

                    lista.Add(registro);
                }


            }
            catch (Exception Ex)
            {
                MessageBox.Show(String.Concat(Ex.Message, Ex.StackTrace), "error2");
                lista=null;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return lista;
        }

    }

}
        #endregion
