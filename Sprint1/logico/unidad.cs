using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1.logico
{
    public class unidad
    {
        private int Id;
        private String nom;
        private String descrip;
        public int id
        {
            get
            {
                return Id;
            }
            set
            {
                Id = value;
            }
        }
        public String nombre
        {
            get
            {
                return nom;
            }
            set
            {
                nom = value;
            }
        }
        public String descripcion
        {
            get
            {
                return descrip;
            }
            set
            {
                descrip = value;
            }
        }
    }
}
