using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/SO/JumperDataSO")]
public class JumperSO : ScriptableObject
{
    [SerializeField] public int Scores;
    [SerializeField] public float hitCd;
    [SerializeField] public float jumperForce;
}
