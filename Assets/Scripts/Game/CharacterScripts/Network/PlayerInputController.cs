using System;
using System.Collections;
using MLAPI;
using MLAPI.Connection;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;
using UnityEngine;
using Zenject;

namespace Game.CharacterScripts.Network
{
    public class PlayerInputController : NetworkBehaviour
    {
        [Inject] private IInputController _inputController;

        public override void NetworkStart()
        {
            StartCoroutine(FindOwnCharacter());
        }

        private IEnumerator FindOwnCharacter()
        {
            Debug.Log(1);
            NetworkClient networkedClient = null;
            while (networkedClient == null)
            {
                yield return new WaitForFixedUpdate();
                NetworkManager.Singleton.ConnectedClients.TryGetValue(
                    NetworkManager.Singleton.LocalClientId, out networkedClient);
            }

            Debug.Log(2);
            var player = networkedClient.PlayerObject.GetComponent<CharacterNetwork>();
            Debug.Log(networkedClient.PlayerObject.ToString());
            Debug.Log(player);
            if (player)
            {
                Debug.Log(3);
                // player.Init(_inputController);
            }
        }

        // private void Move()
        // {
        //     if (NetworkManager.Singleton.IsServer)
        //     {
        //         Position.Value = _inputController.MovingDirection;
        //         RotationAngle.Value = _inputController.FindLookAngle(transform.position);
        //         IsFire.Value = _inputController.IsFire;
        //     }
        //     else
        //     {
        //         SubmitPositionRequestServerRpc();
        //     }
        // }
        //
        // [ServerRpc]
        // void SubmitPositionRequestServerRpc(ServerRpcParams rpcParams = default)
        // {
        //     Position.Value = _inputController.MovingDirection;
        //     RotationAngle.Value = _inputController.FindLookAngle(transform.position);
        //     IsFire.Value = _inputController.IsFire;
        // }
    }
}