using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;
using UnityEngine;
using Zenject;

namespace Game.CharacterScripts.Network
{
    public class CharacterNetwork : NetworkBehaviour
    {
        [SerializeField] private Character _character;

        [Inject] private IInputController _inputController;
        // private CharacterNetwork _characterNetwork;

        public NetworkVariableVector2 Position = new NetworkVariableVector2(new NetworkVariableSettings
        {
            WritePermission = NetworkVariablePermission.ServerOnly,
            ReadPermission = NetworkVariablePermission.Everyone
        }, Vector2.zero);

        public NetworkVariableFloat RotationAngle = new NetworkVariableFloat(new NetworkVariableSettings
        {
            WritePermission = NetworkVariablePermission.ServerOnly,
            ReadPermission = NetworkVariablePermission.Everyone
        }, 0);

        public NetworkVariableBool IsFire = new NetworkVariableBool(new NetworkVariableSettings
        {
            WritePermission = NetworkVariablePermission.ServerOnly,
            ReadPermission = NetworkVariablePermission.Everyone
        }, false);

        public override void NetworkStart()
        {
            _inputController = new KeyboardController();
            // if (NetworkManager.Singleton.ConnectedClients.TryGetValue(NetworkManager.Singleton.LocalClientId,
            //     out var networkedClient))
            // {
            //     _characterNetwork = networkedClient.PlayerObject.GetComponent<CharacterNetwork>();
            //     
            // }
        }

        void Update()
        {
            _character.UpdateInput(Position.Value, RotationAngle.Value, IsFire.Value);
            Debug.Log("Update: " + Position.Value + " " + RotationAngle.Value + " " + IsFire.Value);
        }

        private void FixedUpdate()
        {
            Debug.Log("ID: " + OwnerClientId + " " + NetworkManager.Singleton.LocalClientId);
            if (OwnerClientId.Equals(NetworkManager.Singleton.LocalClientId))
            {
                Move();
                Debug.Log("Move: |" + _inputController + "| " + Position.Value + " "
                          + RotationAngle.Value + " " + IsFire.Value);
                Debug.Log("Move 2: " + _inputController.MovingDirection + " " +
                          _inputController.FindLookAngle(transform.position) + " " + _inputController.IsFire);
            }
        }

        private void Move()
        {
            if (NetworkManager.Singleton.IsServer)
            {
                Position.Value = _inputController.MovingDirection;
                RotationAngle.Value = _inputController.FindLookAngle(transform.position);
                IsFire.Value = _inputController.IsFire;
            }
            else
            {
                SubmitPositionRequestServerRpc();
            }
        }

        [ServerRpc]
        void SubmitPositionRequestServerRpc(ServerRpcParams rpcParams = default)
        {
            Position.Value = _inputController.MovingDirection;
            RotationAngle.Value = _inputController.FindLookAngle(transform.position);
            IsFire.Value = _inputController.IsFire;
        }

        // public void Init(IInputController inputController)
        // {
        //     _inputController = inputController;
        // }
    }
}