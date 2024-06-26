using UnityEngine;

namespace TicTacToe
{
    public class GameControllerAi : GameController
    {
        private int? _aiPlayerIndex;
        
        protected override void OnCellClick(Vector2 clickPos, int index)
        {
            base.OnCellClick(clickPos, index);

            _aiPlayerIndex ??= _currentPlayerIndex;

            if (_aiPlayerIndex != _currentPlayerIndex || _winPopup.gameObject.activeSelf)
            {
                return;
            }

            var freeCells = _cells.FindAll(a => !a.IsOccupied);
            freeCells[Random.Range(0, freeCells.Count)].OnMouseDown();
        }
    }
}