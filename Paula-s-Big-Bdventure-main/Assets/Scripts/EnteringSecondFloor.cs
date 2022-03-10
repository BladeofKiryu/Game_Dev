using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnteringSecondFloor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneLoader.Load(SceneLoader.Scene.SecondFloor);
    }
}
