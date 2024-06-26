using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TicTacToe
{
    public class WinPopup : MonoBehaviour
    {
        [SerializeField] private Button _continueButton;
        [SerializeField] private Text _winnerText;
        
        public void Init(string gameRes)
        {
            gameObject.SetActive(true);
            _winnerText.text = gameRes;
            _continueButton.onClick.AddListener(OnContinueButtonClick);
        }

        private void OnContinueButtonClick()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}