using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TicTacToe
{
    public class LoadSceneButton : MonoBehaviour
    {
        [SerializeField] private Button _loadSceneButton;
        [SerializeField] private string _sceneToLoad;

        private void Start()
        {
            _loadSceneButton.onClick.AddListener(OnLoadSceneButtonClick);
        }

        private void OnDestroy()
        {
            _loadSceneButton.onClick.RemoveAllListeners();
        }

        private void OnLoadSceneButtonClick()
        {
            SceneManager.LoadScene(_sceneToLoad);
        }
    }
}