using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models.States
{
    public class TileFoundState : TileStateBaseClass
    {
        public override TileStates State { get => TileStates.Found; set => State = value; }


        public TileFoundState(Tile tile) : base(tile)
        {
        }

    }
}



