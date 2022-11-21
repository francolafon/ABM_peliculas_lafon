using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using CL;


namespace ABM_peliculas_lafon
{
    public partial class Form1 : Form
    {
        private readonly Abm _abm;
        public Form1()
        {
            _abm = new Abm();
            InitializeComponent();
            
        }
        public void CargarGrilla (Abm abm)
        {
            //Vacio de grilla antes de cargarla
            Grilla.Rows.Clear();
            var lista = _abm.Listar(_abm);
            foreach (var registro in lista)
            {
                Grilla.Rows.Add(registro.id_pel, registro.titulo, registro.id_director, registro.desc_pel, registro.id_categoria, registro.id_productora, registro.anio_pel, registro.cant_pel);
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            //Dar de alta registros
            if(Grilla.CurrentRow != null)
            {
                _abm.titulo = (string)Grilla.CurrentRow.Cells[1].Value;
                _abm.Alta(_abm);
            }
            _abm.titulo = "";
            CargarGrilla(_abm);
        }


    }
}
