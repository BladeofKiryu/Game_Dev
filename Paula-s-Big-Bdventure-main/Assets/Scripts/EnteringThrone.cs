using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnteringThrone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneLoader.Load(SceneLoader.Scene.Throne);
    }
}
