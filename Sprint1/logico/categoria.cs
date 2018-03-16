using Sprint1.dato;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sprint1.logico
{
    public class categoria
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
