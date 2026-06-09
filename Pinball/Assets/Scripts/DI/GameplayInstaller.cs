using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GatesInputHandler>().FromInstance(new GatesInputHandler()).AsSingle();
    }
}