using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models.States
{
    public abstract class BoardStateBaseClass : IBoardState
    {
        public abstract BoardStates State { get; set; }

        public MemoryBoard Board { get; set; }

        public BoardStateBaseClass(MemoryBoard board)
        {
            Board = board;
        }

        public abstract void AddPreview(Tile tile);

        public abstract void TileAnimationEnded(Tile tile);
    }
}


