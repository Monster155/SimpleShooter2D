using MLAPI;
using UnityEngine;

namespace Game.CharacterScripts.Network
{
    public class StartClient : NetworkBehaviour
    {
        private void Start()
        {
            NetworkManager.Singleton.StartClient();
        }
    }
}