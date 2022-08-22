using System.Collections;
using System.Collections.Generic;
using FMT.Gameplay;
using FMT.Player;
using UnityEngine;
using Mirror;

namespace FMT.Network
{
    public class GameNetworkManager : NetworkManager
    {
        [SerializeField]
        private PlayerMotor _playerPrefab;

        private SpawnPoint[] _spawnPoints;

        public static GameNetworkManager Instance => singleton as GameNetworkManager;

        public override void OnServerAddPlayer(NetworkConnectionToClient conn)
        {
            _spawnPoints = FindObjectsOfType<SpawnPoint>();

            PlayerMotor player = Instantiate(_playerPrefab, _spawnPoints[0].Position, _spawnPoints[0].Rotation);

            NetworkServer.AddPlayerForConnection(conn, player.gameObject);

            Debug.Log("Player " + numPlayers + " Connected");
        }

        public override void OnServerChangeScene(string newSceneName)
        {
            _spawnPoints = FindObjectsOfType<SpawnPoint>();
        }
    }
}
