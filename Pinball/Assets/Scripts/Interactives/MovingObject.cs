using System.Collections;
using UnityEngine;
using Zenject;

public class MovingObject : MonoBehaviour, IPunching
{
    [SerializeField] private MovingObjectData data;
    private ScoreStorage scoreStorage;
    private bool canEarnScore = true;
    [Inject]
    private void Construct(ScoreStorage _scoreStorage)
    {
        scoreStorage = _scoreStorage;
    }
    public void Punch(Rigidbody rigidbody)
    {
        if(canEarnScore)
            scoreStorage.AddScore(data.Scores);
    }

    IEnumerable Reloading()
    {
        canEarnScore = false;
        yield return new WaitForSeconds(data.Scores);
        canEarnScore = true;
    }
}
