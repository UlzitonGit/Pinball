using UnityEngine;

public class BallsCurrencyController
{
    private int _ballsCount = 3;
    private bool _canSpawnNewBall;
    public ObservableValue<int> Balls { get; set; }
    public ObservableValue<bool> CanSpawnNewBall { get; set; }

    public BallsCurrencyController()
    {
        Balls = new ObservableValue<int>(0);
        CanSpawnNewBall = new ObservableValue<bool>(false);

        Balls.Value = _ballsCount;
        CanSpawnNewBall.Value = _canSpawnNewBall;
    }

    public void DestroyBall()
    {
        _canSpawnNewBall = true;
        CanSpawnNewBall.Value = _canSpawnNewBall;
    }

    public void SpawnNewBall()
    {
        _canSpawnNewBall = false;
        CanSpawnNewBall.Value = false;
        _ballsCount -= 1;
        Balls.Value = _ballsCount;
    }
}
