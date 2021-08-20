using MLAPI;

namespace Game.CharacterScripts.Network
{
    public class StartServer : NetworkBehaviour
    {
        private void Start()
        {
            NetworkManager.Singleton.StartServer();
        }
    }
}