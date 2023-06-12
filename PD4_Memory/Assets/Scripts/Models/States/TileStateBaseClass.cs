using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models.States
{
    public abstract class TileStateBaseClass : ITileState
    {
        public Tile Tile { get; set; }
        public abstract TileStates State { get; set; }

        public TileStateBaseClass(Tile tile)
        {
            Tile = tile;
        }

    }
}



