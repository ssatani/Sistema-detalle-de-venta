using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1.logico
{
    public class empleado
    {
        private int id_emp;
        private String nom;
        private String ape;
        private String sex;
        private String c;
        private String fon;
        private String dir;
        private String log;
        private String pas;

        public int id_empleado
        {
            get
            {
                return id_emp;
            }
            set
            {
                id_emp = value;
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
        public String apellidos
        {
            get
            {
                return ape;
            }
            set
            {
                ape = value;
            }
        }
        public String sexo
        {
            get
            {
                return sex;
            }
            set
            {
                sex = value;
            }
        }
        public String ci
        {
            get
            {
                return c;
            }
            set
            {
                c = value;
            }
        }
        public String fono
        {
            get
            {
                return fon;
            }
            set
            {
                fon = value;
            }
        }
        public String direccion
        {
            get
            {
                return dir;
            }
            set
            {
                dir = value;
            }
        }
        public String login
        {
            get
            {
                return log;
            }
            set
            {
                log = value;
            }
        }
        public String password
        {
            get
            {
                return pas;
            }
            set
            {
                pas = value;
            }
        }
        
    }
}
