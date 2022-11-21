using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace CL
{
    public class Conexion
    {
        private readonly string _connString;
        public Conexion() 
        {
            //Cadena de conexion para Access 2019
            //_connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Franco\\source\repos\\ABM_peliculas_lafon\\CD\\BDpelis.c;Persist Security Info=False;";
            _connString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\\Users\\Franco\\source\\repos\\ABM_peliculas_lafon\\CD\\BDpelis.accdb";
        }

        public OleDbConnection Abrir()
        {
            var conn = new OleDbConnection(_connString);
            conn.Open();
            return conn;
        }
    }
}
