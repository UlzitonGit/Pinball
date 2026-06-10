using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/SO/MovingDataSO")]
public class MovingObjectData : ScriptableObject
{
    [SerializeField] public int Scores;
    [SerializeField] public float hitCd;
}
