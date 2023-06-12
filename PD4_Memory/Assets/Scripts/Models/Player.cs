using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models
{
    public class Player : ModelBaseClass
    {
        private string _name;
        private int _score;
        private bool _isActivePlayer = false;
        private float _elapsed;

        public string Name { get => _name; set { _name = value; OnPropertyChanged(); } }

        public int Score { get => _score; set { _score = value; OnPropertyChanged(); } }

        public bool IsActivePlayer { get => _isActivePlayer; set { _isActivePlayer = value; OnPropertyChanged(); } }

        public float Elapsed { get => _elapsed; set { if (!_isActivePlayer) { return; } _elapsed = value; OnPropertyChanged(); } }

        public int mm { get =>  (int)(Elapsed / 60); }

        public int ss { get => (int)(Elapsed % 60); }

        public int ms { get => (int)((Elapsed % 1) * 1000); }
    }
}


