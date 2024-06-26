using System;
using UnityEngine;

namespace TicTacToe
{
    public class Cell : MonoBehaviour
    {
        public bool IsOccupied { get; private set; }
        public int Index => _index;

        [SerializeField] private int _index;
        private Action<Vector2, int> _callback;
        
        public void Init(Action<Vector2, int> callback)
        {
            _callback = callback;
        }

        public void OnMouseDown()
        {
            IsOccupied = true;
            _callback.Invoke(transform.position, _index);
        }
    }
}