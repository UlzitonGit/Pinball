using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BallsSpawner : MonoBehaviour
{
    [SerializeField] private Button spawnButton;
    [SerializeField] private GameObject ballPrefab;
    private BallsCurrencyController ballsCurency;
    
    [Inject]
    private void Construct(BallsCurrencyController _ballsCurrency)
    {
        ballsCurency = _ballsCurrency;
        spawnButton.onClick.AddListener(SpawnNewBall);
    }

    public void SpawnNewBall()
    {
        if(!ballsCurency.CanSpawnNewBall.Value) return;
        
        Instantiate(ballPrefab, transform.position, Quaternion.identity);
        ballsCurency.SpawnNewBall();
    }
}
