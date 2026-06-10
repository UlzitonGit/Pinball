using UnityEngine;

public class Bonus : MonoBehaviour, IPunching
{
    [SerializeField] private BonusSO _bonusSO;
    private ScoreStorage scoreStorage;
    private BonusPool bonusPool;
    
    public void SetBonus(ScoreStorage _scoreStorage, BonusPool _bonusPool)
    {
        scoreStorage = _scoreStorage;
        bonusPool = _bonusPool;
    }
    public void Punch(Rigidbody rigidbody)
    {
        scoreStorage.AddScore(_bonusSO.Score);
        gameObject.SetActive(false);
        bonusPool.ReturnToPool(this);
    }
}
