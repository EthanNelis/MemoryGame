using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models.States
{
    public class TilePreviewState : TileStateBaseClass
    {
        public override TileStates State { get => TileStates.Preview; set => State = value; }


        public TilePreviewState(Tile tile) : base(tile)
        {
        }
    }
}

