using Memory.Models.States;
using Memory.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Memory.Models
{
    public class MemoryBoard : ModelBaseClass
    {
        private int _rows;

        private int _columns;

        private List<Tile> _tiles;

        private List<Tile> _previewTiles;

        public int Rows { get => _rows; set { _rows = value; OnPropertyChanged(); } }

        public int Columns { get => _columns; set { _columns = value; OnPropertyChanged(); } }

        public List<Tile> Tiles { get => _tiles; set { _tiles = value; OnPropertyChanged(); } }

        public List<Tile> PreviewingTiles { get => _previewTiles; set { _previewTiles = value; OnPropertyChanged(); } }

        private IBoardState _state;

        public IBoardState State { get => _state; set { _state = value; OnPropertyChanged(); } }

        public Player Player1 { get; set; }

        public Player Player2 { get; set; }

        public bool IsCombinationFound
        {
            get
            {
                if (PreviewingTiles.Count == 2 &&
                    PreviewingTiles[0].MemoryCardId == PreviewingTiles[1].MemoryCardId)
                {
                    return true;
                }
                else return false;
            }
        }

        public MemoryBoard(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Tiles = new List<Tile>(rows * columns);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Tile tile = new Tile(i, j, this);
                    Tiles.Add(tile);
                }
            }

            AssignMemoryCardIds();

            State = new BoardNoPreviewState(this);

            PreviewingTiles = new List<Tile>();
        }

        private void AssignMemoryCardIds()
        {
            Tiles = ExtensionMethods.Shuffle(Tiles);

            //Should probably depend on the number of rows and columns
            List<int> ids = new List<int>() { 0,0,1,1,2,2,3,3,4,4};
            
            ids = ExtensionMethods.Shuffle(ids);

            for (int i = 0; i < Tiles.Count; i++)
            {
                Tiles[i].MemoryCardId = ids[i];
            }
        }

        public override string ToString()
        {
            return $"MemoryBoard({Rows} , {Columns})";
        }

        public void ToggleActivePlayer()
        {
            Player1.IsActivePlayer = !Player1.IsActivePlayer;
            Player2.IsActivePlayer = !Player2.IsActivePlayer;
        }
    }
}


