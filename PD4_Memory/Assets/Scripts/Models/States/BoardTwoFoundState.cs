using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Memory.Models.States
{
    public class BoardTwoFoundState : BoardStateBaseClass
    {
        public override BoardStates State { get => BoardStates.TwoFound; set => State = value; }

        public BoardTwoFoundState(MemoryBoard board) : base(board) { }

        public override void AddPreview(Tile tile)
        {
        }

        public override void TileAnimationEnded(Tile tile)
        {
            // Works but is probably not be 100% correctly implemented:
            // if condition will always return true

            tile.Board.PreviewingTiles.Clear();
            if (tile.Board.PreviewingTiles.Count == 0)
            {
                if (Board.Tiles.Where(t => t.State.State == TileStates.Hidden).Count() < 2)
                {
                    tile.Board.State = new BoardFinishedState(Board);
                }
                else
                {
                    tile.Board.State = new BoardNoPreviewState(Board);
                }
            }
        }
    }
}


