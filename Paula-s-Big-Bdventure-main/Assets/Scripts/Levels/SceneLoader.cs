using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
   public enum Scene
   {
      MainMenu,
      Cemetery,
      FirstFloor,
      CouncilRoom,
      SecondFloor,
      ThirdFloor,
      Throne,
   }

   public static void Load(Scene scene)
   {
      SceneManager.LoadScene(scene.ToString());
   }
}
