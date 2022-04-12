using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PauseMenuScript : MonoBehaviour
{
   private bool canPause = true; // instead of a float time, we're using a boolean
   private bool isPaused = false; // let us know when the game is paused
   public GameObject pauseMenuUI;
   public GameObject optionsMenuUI;
   public GameObject[] objectsToPause;
   private void Awake()
   {
      if (pauseMenuUI)
      {
         pauseMenuUI.SetActive(false);
      }
      if (optionsMenuUI)
      {
         optionsMenuUI.SetActive(false);
      }
   }
   void Update()
   {
      Debug.Log($"Can Pause {canPause}");
      Keyboard keyboard = Keyboard.current;
      if (keyboard.backspaceKey.ReadValue() > 0f && canPause)
      {
         StartCoroutine(PauseTimer());
         GamePause();
      }
   }
   void GamePause()
   {
      isPaused = !isPaused;
      if (isPaused)
      {
         PauseGame();
      }
      else
      {
         ResumeGame();
      }
      foreach (GameObject obj in objectsToPause)
      {
         SetGameObjectState(obj, !isPaused);
      }
      if (PlayerData.current != null)
      {
         PlayerData.current.AudioVolume = SceneLoader.instance.AudioVolume.value;
         PlayerData.current.EFXVolume = SceneLoader.instance.EFXVolume.value;
         PlayerData.current.CameraSensitivity = SceneLoader.instance.CameraSensitivity.value;
      }
   }
   void ResumeGame()
   {
      SetGameObjectState(pauseMenuUI, false);
      SetGameObjectState(optionsMenuUI, false);
      Time.timeScale = 1f;
   }

   void PauseGame()
   {
      SetGameObjectState(pauseMenuUI, true);
      SetGameObjectState(optionsMenuUI, false);
      Time.timeScale = 0f;
   }

   public void GoToMainMenu()
   {
      ResumeGame();
      SceneLoader.instance.Load(SceneLoader.Scene.MainMenu);
      Debug.Log("Go To Main Menu");
   }

   public void OpenOptionsMenu()
   {
      if (isPaused)
      {
         SetGameObjectState(pauseMenuUI, false);
         SetGameObjectState(optionsMenuUI, true);
      }
   }
   public void CloseOptionsMenu()
   {
      PauseGame();
   }
   void SetGameObjectState(GameObject obj, bool state)
   {
      if (obj)
      {
         obj.SetActive(state);
      }
   }

   IEnumerator PauseTimer()
   {
      canPause = false;
      //yield on a new YieldInstruction that waits for 5 seconds.
      yield return new WaitForSeconds(2);
      canPause = true;
   }
}
