using System.Collections;
using System.Collections.Generic;
using FMT.Network;
using UnityEngine.UI;
using UnityEngine;

namespace FMT.Gameplay
{
    public class SimpleMenuScene : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _quitButton;
        [SerializeField] private GameNetworkManager _networkManager;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            _startButton.onClick.AddListener(HandleStartButtonClick);
            _quitButton.onClick.AddListener(HandleQuitButtonClick);
        }

        private void HandleStartButtonClick()
        {
            _networkManager.StartHost();
        }

        private void HandleQuitButtonClick()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}
