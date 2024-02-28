using System.Reflection;

namespace Pokedex.Dto
{
    public class showPokemonView
    {
        public int Order { get; set; }
        public string Name { get; set; }

        public string Foto { get; set; }

        public virtual List<Tipos> Tipo { get; set; } = new List<Tipos>();

        public class Tipos {
            public int Slot { get; set; }
            public string Name { get; set; }
        }
    }


}
