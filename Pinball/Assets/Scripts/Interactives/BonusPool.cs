using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BonusPool : MonoBehaviour
{
    [SerializeField] private GameObject _bonusPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float SpawnRate;
    [SerializeField] private int ballsCount;
    
    private List<Bonus> bonusActivePool = new List<Bonus>();
    
    private ScoreStorage scoreStorage;

    [Inject]
    private void Construct(ScoreStorage _scoreStorage)
    {
       scoreStorage = _scoreStorage;

       for (int i = 0; i < ballsCount; i++)
       {
           bonusActivePool.Add(Instantiate(_bonusPrefab, transform.position, Quaternion.identity).GetComponent<Bonus>());
       }

       foreach (var bonus in bonusActivePool)
       {
           bonus.SetBonus(scoreStorage, this);
       }
       StartCoroutine(SpawningCountdown());
    }

    public void SpawnBonus()
    {
        if (bonusActivePool.Count > 0)
        {
            bonusActivePool[0].gameObject.SetActive(true);
            bonusActivePool[0].transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;
            bonusActivePool.RemoveAt(0);
        }
    }
    
    public void ReturnToPool(Bonus _go)
    {
        bonusActivePool.Add(_go);
    }

    IEnumerator SpawningCountdown()
    {
        yield return new WaitForSeconds(SpawnRate);
        SpawnBonus();
        StartCoroutine(SpawningCountdown());
    }
}
