using Memory.Models.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models
{
    public class Tile : ModelBaseClass
    {
        private int _row;

        private int _column;

        private MemoryBoard _board;

        private int _memoryCardId;

        public int Row { get => _row; set { _row = value; OnPropertyChanged(); } }

        public int Column { get => _column; set { _column = value; OnPropertyChanged(); } }

        public MemoryBoard Board { get => _board; set { _board = value; OnPropertyChanged(); } }

        public int MemoryCardId { get => _memoryCardId; set { _memoryCardId = value; OnPropertyChanged(); } }

        private ITileState _state;

        public ITileState State { get => _state; set { _state = value; OnPropertyChanged(); } }

        public Tile(int row, int column, MemoryBoard board)
        {
            Row = row;
            Column = column;
            Board = board;
            State = new TileHiddenState(this);
        }

        public override string ToString()
        {
            return $"Tile({Row} , {Column})";
        }

    }
}




