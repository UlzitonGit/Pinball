using System;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private ParticleSystem particleSystem;
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Obstacles"))
        {
            particleSystem.Play();
        }
        if (other.gameObject.CompareTag("Punching"))
        {
            other.gameObject.GetComponent<IPunching>().Punch(rigidbody);
            particleSystem.Play();
        }
    }
    
}
