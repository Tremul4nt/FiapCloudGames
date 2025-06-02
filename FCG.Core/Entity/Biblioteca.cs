using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCG.Core.Entity
{
    public class Biblioteca: EntityBase
    {
        public int UsuarioId { get; set; }
        public int JogoId { get; set; }
        public Usuario Usuario { get; set; }
        public Jogo  Jogo { get; set; }
    }
}
