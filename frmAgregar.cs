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
    public partial class frmAgregar : Form
    {
        public frmAgregar()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                curso objCurso = new curso();
                objCurso.Nombre = txtNombre.Text;
                objCurso.Duracion = Convert.ToInt32(txtDuracion.Text);
                objCurso.Descripcion = txtDescripcion.Text;

                conexion objConexion = new conexion();
                int resultado = objConexion.CursoInsertar(objCurso);
                if (resultado == 1)
                    MessageBox.Show("Insertado Correctamente");
                else
                    MessageBox.Show("Ocurrió un error");
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
