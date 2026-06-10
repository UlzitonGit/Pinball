using System.Collections;
using UnityEngine;
using Zenject;

public class Jumper : MonoBehaviour, IPunching
{
    [SerializeField] private JumperSO data;
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
        Vector3 direction = (rigidbody.transform.position - transform.position).normalized;
        rigidbody.AddForce(direction * data.jumperForce, ForceMode.Impulse);
        Debug.Log(data.jumperForce);
    }

    IEnumerable Reloading()
    {
        canEarnScore = false;
        yield return new WaitForSeconds(data.Scores);
        canEarnScore = true;
    }
}
