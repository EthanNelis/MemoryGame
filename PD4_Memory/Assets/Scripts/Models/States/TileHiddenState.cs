using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models.States
{
    public class TileHiddenState : TileStateBaseClass
    {
        public override TileStates State { get => TileStates.Hidden; set => State = value; }


        public TileHiddenState(Tile tile) : base(tile)
        {
        }

    }
}

