using System;
using UnityEngine;
using Zenject;

namespace Game
{
    public class MyMonoInstaller : MonoInstaller
    {
        [SerializeField] private Camera _mainCamera;

        public override void InstallBindings()
        {
            _mainCamera = _mainCamera == null ? Camera.main : _mainCamera;
            // Container.Bind<IInputController>().WithId("Keyboard").To<KeyboardController>().AsSingle();
            Container.Bind<IInputController>().To<KeyboardController>().AsSingle();
            Container.Bind<Camera>().FromInstance(_mainCamera);
        }
    }
}