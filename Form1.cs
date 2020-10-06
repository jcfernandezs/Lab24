using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyWin_Lab24
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cargar();
        }
        
        private void Cargar()
        {
            conexion objConexion = new conexion();
            dataGridView1.DataSource = objConexion.CursoListar();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmAgregar frm = new frmAgregar();
            frm.ShowDialog();
            Cargar();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            curso objCurso = new curso();
            objCurso.Nombre = dataGridView1.SelectedRows[0].Cells["nombre"].Value.ToString();
            objCurso.Duracion = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["duracion"].Value.ToString());
            objCurso.Descripcion = dataGridView1.SelectedRows[0].Cells["descripcion"].Value.ToString();
            
            frmEditar frm = new frmEditar();
            frm.Cargar(objCurso);
            frm.ShowDialog();
            Cargar();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                String nombre = dataGridView1.SelectedRows[0].Cells["Nombre"].Value.ToString();
                conexion objConexion = new conexion();
                int resultado = objConexion.CursoEliminar(nombre);
                if (resultado == 1)
                    MessageBox.Show("Curso eliminado satisfactoriamente");
                else
                    MessageBox.Show("Ocurrió un error");
                Cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
