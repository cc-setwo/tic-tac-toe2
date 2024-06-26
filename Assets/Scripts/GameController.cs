using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class GameController : MonoBehaviour
    {
        protected int _currentPlayerIndex;
        
        [SerializeField] protected List<Cell> _cells;
        [SerializeField] protected WinPopup _winPopup;
        [SerializeField] private List<PlayerObject> _playerPrefabs;

        private readonly List<string> _occupiedCells = new();

        protected virtual void OnCellClick(Vector2 clickPos, int index)
        {
            var newObj = Instantiate(_playerPrefabs[_currentPlayerIndex], clickPos, Quaternion.identity, transform);
            _occupiedCells[index] = newObj.PlayerSign;

            var gameRes = CheckFinish();

            if (!string.IsNullOrEmpty(gameRes))
            {
                _winPopup.Init(gameRes);
                return;
            }

            if (++_currentPlayerIndex >= _playerPrefabs.Count)
            {
                _currentPlayerIndex = 0;
            }
        }

        private void Start()
        {
            for (var i = 0; i < _cells.Count; i++)
            {
                _cells[i].Init(OnCellClick);
                _occupiedCells.Add(string.Empty);
            }
        }

        private string CheckFinish()
        {
            // Check for horizontal
            for (var i = 0; i < 9; i += 3)
            {
                if (_occupiedCells[i] != "" && _occupiedCells[i] == _occupiedCells[i + 1] &&
                    _occupiedCells[i] == _occupiedCells[i + 2])
                {
                    return _occupiedCells[i] + " Wins!";
                }
            }

            // Check for vertical
            for (var i = 0; i < 3; i++)
            {
                if (_occupiedCells[i] != "" && _occupiedCells[i] == _occupiedCells[i + 3] &&
                    _occupiedCells[i] == _occupiedCells[i + 6])
                {
                    return _occupiedCells[i] + " Wins!";
                }
            }

            // Check for diagonal
            if (_occupiedCells[0] != "" && _occupiedCells[0] == _occupiedCells[4] &&
                _occupiedCells[0] == _occupiedCells[8])
            {
                return _occupiedCells[0] + " Wins!";
            }

            if (_occupiedCells[2] != "" && _occupiedCells[2] == _occupiedCells[4] &&
                _occupiedCells[2] == _occupiedCells[6])
            {
                return _occupiedCells[2] + " Wins!";
            }

            // Check for draw
            if (_occupiedCells.TrueForAll(cell => cell != ""))
            {
                return "Draw!";
            }

            // The game continues
            return string.Empty;
        }
    }
}
