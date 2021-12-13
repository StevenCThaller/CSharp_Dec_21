using System.Collections.Generic;

namespace _01_Many_To_Many.Models
{
    public class MoveInfoView
    {
        public Move ToRender { get; set; }
        public List<Pokemon> ToTeachTo { get; set; }
        public PokemonHasMove TeachForm { get; set; }
    }
}