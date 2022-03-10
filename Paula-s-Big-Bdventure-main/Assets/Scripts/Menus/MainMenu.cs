
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

   public void StartGame()
   {
      SceneManager.LoadScene("Cemetery");
      Debug.Log("Start Game");
   }
   public void StartMenu()
   {
      SceneManager.LoadScene("MainMenu");
      Debug.Log("Main Menu");
   }

   public void QuitGame()
   {
      Application.Quit();
      Debug.Log("Quit Game");

      //UnityEditor.EditorApplication.isPlaying = false;
   }

   //public void Continue()
   //{

   //}
}
