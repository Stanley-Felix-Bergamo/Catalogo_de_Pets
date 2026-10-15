using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo_de_cadastro_de_Pets
{
    internal class Propriedades
    {
        public struct Pet
        {
            public string s_TipoAnimal { get; set; }
            public string s_Raca { get; set; }
            public string s_Nome { get; set; }
            public string s_Vacina { get; set; }
            public int i_Idade { get; set; }
        }
    }
}
