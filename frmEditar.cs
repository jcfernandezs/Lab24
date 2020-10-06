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
    public partial class frmEditar : Form
    {
        public frmEditar()
        {
            InitializeComponent();
        }

        public void Cargar(curso objCurso)
        {
            txtNombre.Text = objCurso.Nombre;
            txtDescripcion.Text = objCurso.Descripcion;
            txtDuracion.Text = objCurso.Duracion.ToString();
        }

        private void frmGuardar_Click(object sender, EventArgs e)
        {
            curso objCurso = new curso();
            objCurso.Nombre = txtNombre.Text;
            objCurso.Descripcion = txtDescripcion.Text;
            objCurso.Duracion = Convert.ToInt32(txtDuracion.Text);

            conexion objConexion = new conexion();
            int resultado = objConexion.CursoEditar(objCurso);
            if (resultado == 1)
                MessageBox.Show("Editado correctamente");
            else
                MessageBox.Show("Ocurrió un error");
            this.Close();
        }
    }
}
