using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWTrace_beta
{
    class Pallette : Conexion
    {
        int id_pallette;
        string pallette;

        public int Id_pallette { get => id_pallette; set => id_pallette = value; }
        public string Pallettes { get => pallette; set => pallette = value; }
    }
}
