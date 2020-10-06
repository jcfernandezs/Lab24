using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyWin_Lab24
{
    public class curso
    {
        private String mvarNombre;
        private int mvarDuracion;
        private String mvarDescripcion;

        public String Nombre
        {
            get { return mvarNombre; }
            set { mvarNombre = value; }
        }
        
        public int Duracion
        {
            get { return mvarDuracion; }
            set { mvarDuracion = value; }
        }
        
        public String Descripcion
        {
            get { return mvarDescripcion; }
            set { mvarDescripcion = value; }
        }
    }
}
