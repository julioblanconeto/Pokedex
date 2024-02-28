namespace Pokedex.Model
{
    public class PokemonData
    {
        public class Rootobject
        {
            public string Form_name { get; set; }
            public object[] Form_names { get; set; }
            public int Form_order { get; set; }
            public int Id { get; set; }
            public bool Is_battle_only { get; set; }
            public bool Is_default { get; set; }
            public bool Is_mega { get; set; }
            public string Name { get; set; }
            public object[] Names { get; set; }
            public int Order { get; set; }
            public Pokemon Pokemon { get; set; }
            public Sprites Sprites { get; set; }
            public Type[] Types { get; set; }
            public Version_Group Version_group { get; set; }
        }

        public class Pokemon
        {
            public string Name { get; set; }
            public string Url { get; set; }
        }

        public class Sprites
        {
            public string Back_default { get; set; }
            public object Back_female { get; set; }
            public string Back_shiny { get; set; }
            public object Back_shiny_female { get; set; }
            public string Front_default { get; set; }
            public object Front_female { get; set; }
            public string Front_shiny { get; set; }
            public object Front_shiny_female { get; set; }
        }

        public class Version_Group
        {
            public string Name { get; set; }
            public string Url { get; set; }
        }

        public class Type
        {
            public int Slot { get; set; }
            public Type1 type { get; set; }
        }

        public class Type1
        {
            public string Name { get; set; }
            public string Url { get; set; }
        }

    }
}
