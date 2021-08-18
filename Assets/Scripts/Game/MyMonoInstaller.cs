using UnityEngine;
using Zenject;

namespace Game
{
    public class MyMonoInstaller : MonoInstaller
    {
        [SerializeField] private Camera _mainCamera;

        public override void InstallBindings()
        {
            Container.Bind<IInputController>().WithId("Keyboard").To<KeyboardController>().AsTransient();
            Container.Bind<Camera>().FromInstance(_mainCamera);
        }
    }
}