using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

namespace Memory.Models.States
{
    public class BoardFinishedState : BoardStateBaseClass
    {
        public override BoardStates State { get => BoardStates.Finished; set => State = value; }

        public BoardFinishedState(MemoryBoard board) : base(board) { }

        public override void AddPreview(Tile tile)
        {
        }

        public override void TileAnimationEnded(Tile tile)
        {
        }
    }
}



