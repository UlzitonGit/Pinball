using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/SO/GatesDataSO")]
public class GatesDataSO : ScriptableObject
{
    [SerializeField] public float hitStrength = 80000f;
    [SerializeField] public float dampening = 250f;

}
