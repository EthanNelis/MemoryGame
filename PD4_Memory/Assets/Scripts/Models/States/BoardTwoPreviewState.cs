using Memory.Models.States;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Memory.Models.States
{
    public class BoardTwoPreviewState : BoardStateBaseClass
    {
        public override BoardStates State { get => BoardStates.TwoPreview; set => State = value; }

        public BoardTwoPreviewState(MemoryBoard board) : base(board) { }

        public override void AddPreview(Tile tile)
        {
        }

        public override void TileAnimationEnded(Tile tile)
        {
            if (tile.Board.PreviewingTiles[tile.Board.PreviewingTiles.Count - 1] == tile)
            {
                tile.Board.State = new BoardTwoHidingState(Board);
                foreach (Tile previewedTile in tile.Board.PreviewingTiles)
                {
                    previewedTile.State = new TileHiddenState(previewedTile);
                }
            }
        }
    }
}


