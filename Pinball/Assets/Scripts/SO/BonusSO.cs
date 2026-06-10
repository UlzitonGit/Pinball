using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/SO/BonusSO")]
public class BonusSO : ScriptableObject
{
    [SerializeField] public int Score;
}
