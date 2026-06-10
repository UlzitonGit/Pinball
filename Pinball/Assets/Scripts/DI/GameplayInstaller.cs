using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        ScoreStorage storage = new ScoreStorage();
        
        Container.Bind<GatesInputHandler>().FromInstance(new GatesInputHandler()).AsSingle();
        Container.Bind<ScoreStorage>().FromInstance(storage).AsSingle();
    }
}