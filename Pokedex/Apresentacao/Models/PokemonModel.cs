using Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Models
{
    public class PokemonModel
    {
        public string Numero { get; set; }
        public string Nome { get; set; }
        public string TipoPrimario { get; set; }
        public string TipoSecundario { get; set; }
        public string Categoria { get; set; }
        public string Habilidade { get; set; }
        public string Descricao { get; set; }
    }
}
