using UnityEngine;

namespace TicTacToe
{
    public class PlayerObject : MonoBehaviour
    {
        public string PlayerSign => _playerSign;
        
        [SerializeField] private string _playerSign;
    }
}