using System;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Punching"))
        {
            other.gameObject.GetComponent<IPunching>().Punch(rigidbody);
        }
    }
    
}
