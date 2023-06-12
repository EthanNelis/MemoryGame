using Memory.Models.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models.States
{
    public class BoardTwoHidingState : BoardStateBaseClass
    {
        public override BoardStates State { get => BoardStates.TwoHiding; set => State = value; }

        public BoardTwoHidingState(MemoryBoard board) : base(board) { }

        public override void AddPreview(Tile tile)
        {
        }

        public override void TileAnimationEnded(Tile tile)
        {
            tile.Board.PreviewingTiles.Remove(tile);
            if(tile.Board.PreviewingTiles.Count == 0)
            {
                tile.Board.State = new BoardNoPreviewState(Board);
            }
        }
    }
}


