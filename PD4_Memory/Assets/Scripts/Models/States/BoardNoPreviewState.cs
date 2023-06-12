using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models.States
{
    public class BoardNoPreviewState : BoardStateBaseClass
    {
        public override BoardStates State { get => BoardStates.NoPreview; set => State = value; }

        public BoardNoPreviewState(MemoryBoard board) : base(board)
        {
        }

        public override void AddPreview(Tile tile)
        {
            if (tile.State.State != TileStates.Hidden)
            {
                return;
            }
            tile.State = new TilePreviewState(tile);
            tile.Board.PreviewingTiles.Add(tile);
            tile.Board.State = new BoardOnePreviewState(Board);
        }

        public override void TileAnimationEnded(Tile tile)
        {
        }
    }
}


