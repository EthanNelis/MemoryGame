using Memory.Models.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models.States
{
    public class BoardOnePreviewState : BoardStateBaseClass
    {
        public override BoardStates State { get => BoardStates.OnePreview; set => State = value; }

        public BoardOnePreviewState(MemoryBoard board) : base(board) { }

        public override void AddPreview(Tile tile)
        {
            if(tile.State.State != TileStates.Hidden)
            {
                return;
            }

            tile.Board.PreviewingTiles.Add(tile);

            if (tile.Board.IsCombinationFound)
            {
                tile.Board.State = new BoardTwoFoundState(Board);
                foreach(Tile previewedTile in tile.Board.PreviewingTiles)
                {
                    previewedTile.State = new TileFoundState(previewedTile);
                }
            }
            else
            {
                tile.Board.State = new BoardTwoPreviewState(Board);
                tile.State = new TilePreviewState(tile);
            }
        }

        public override void TileAnimationEnded(Tile tile)
        {
        }
    }
}


