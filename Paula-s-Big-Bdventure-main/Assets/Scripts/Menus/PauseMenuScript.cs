using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PauseMenuScript : MonoBehaviour
{
   public static bool isPaused = false;
   public GameObject pauseMenuUI;
   public GameObject[] objectsToPause;
   void Update()
   {
      Keyboard keyboard = Keyboard.current;
      if (keyboard.backspaceKey.ReadValue() > 0f)
      {
         if (isPaused)
         {
            ResumeGame();
         }
         else
         {
            PauseGame();
         }
         foreach(GameObject obj in objectsToPause)
         {
            obj.SetActive(!isPaused);
         }
      }
   }

   void ResumeGame()
   {
      pauseMenuUI.SetActive(false);
      isPaused = false;
      Time.timeScale = 1f;
   }

   void PauseGame()
   {
      pauseMenuUI.SetActive(true);
      isPaused = true;
      Time.timeScale = 0f;
   }
}
