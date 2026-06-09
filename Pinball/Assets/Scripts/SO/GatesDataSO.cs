using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/SO/GatesDataSO")]
public class GatesDataSO : ScriptableObject
{
    [SerializeField] public float StretchPower;
    [SerializeField] public float HitForce;
    [SerializeField] public float TargetRotation;
    [SerializeField] public float BasicRotation;
    [SerializeField] public float angularDrag = 2f;

}
