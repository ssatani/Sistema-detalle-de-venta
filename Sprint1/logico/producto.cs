using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1.logico
{
    public class producto
    {
       
        private categoria __cate=new categoria();
        private unidad __unid=new unidad();

        private int id_prod;
        private String cod;
        private String nom;
        private String descrip;
        private Image image;

        public int id_producto
        {
            get
            {
                return id_prod;
            }
            set
            {
                id_prod = value;
            }
        }
        public String codigo
        {
            get
            {
                return cod;
            }
            set
            {
                cod = value;
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
        public Image imagen
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
            }
        }
        
        public categoria Cate { get => __cate; set => __cate = value; }
        public unidad Unid { get => __unid; set => __unid = value; }

       
    }
}
