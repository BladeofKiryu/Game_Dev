using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G1 : MonoBehaviour
{
    [SerializeField] private Animator myAnimationController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myAnimationController.SetBool("playTrigger 1", true);
        }
    }
}