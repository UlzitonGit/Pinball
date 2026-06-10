using System;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    private SceneController sceneController;
    public override void InstallBindings()
    {
        ScoreStorage storage = new ScoreStorage();
        sceneController = new SceneController();
        
        Container.Bind<GatesInputHandler>().FromInstance(new GatesInputHandler()).AsSingle();
        Container.Bind<ScoreStorage>().FromInstance(storage).AsSingle();
        Container.Bind<BallsCurrencyController>().FromInstance(new BallsCurrencyController()).AsSingle();
        Container.Bind<SceneController>().FromInstance(sceneController).AsSingle();
    }

    private void OnDisable()
    {
        sceneController.Disable();
    }
}