using UnityEngine;
using Zenject;

public class DeathZone : MonoBehaviour, IPunching
{
    private BallsCurrencyController ballsCurrency;
    private ScoreStorage scoreStorage;
    
    [Inject]
    private void Construct(BallsCurrencyController _balls, ScoreStorage _scoreStorage)
    {
        ballsCurrency = _balls;
        scoreStorage = _scoreStorage;
    }
    
    public void Punch(Rigidbody rigidbody)
    {
        rigidbody.isKinematic = true;
        scoreStorage.ClearCombo();
        ballsCurrency.DestroyBall();
    }
}
