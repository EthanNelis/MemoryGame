using Memory.Models;
using Memory.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class MemoryGame : MonoBehaviour
{
    [SerializeField]
    private GameObject _tilePrefab;

    [SerializeField]
    private GameObject _memoryBoard;

    [SerializeField]
    private Material[] _materials;

    [SerializeField]
    private GameObject _playerGO1;

    [SerializeField]
    private GameObject _playerGO2;

    private Player _player1;

    private Player _player2;

    private MemoryBoard _board;

    private void Start()
    {
        int rows = 3;
        int columns = 3;
        
        _player1 = new Player();
        _player2 = new Player();

        _playerGO1.GetComponent<PlayerView>().Model = _player1;
        _playerGO2.GetComponent<PlayerView>().Model = _player2;

        _player1.IsActivePlayer = true;

        _player1.Name = "Player1";
        _player2.Name = "Player2";

        _board = new MemoryBoard(rows, columns);

        _board.Player1 = _player1;
        _board.Player2 = _player2;

        _memoryBoard.GetComponent<MemoryBoardView>().SetUpMemoryBoardView(_board, _tilePrefab, _materials);
    }
}
