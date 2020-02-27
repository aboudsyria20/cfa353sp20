using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

 public class PauseMenu : MonoBehaviour
 {


 public static bool isGamePaused = false;
 public GameObject PauseMenuUI;

   void Update()
   {
      if(Input.GetKeyDown(KeyCode.Escape)){
        if(isGamePaused)
            {
          Resume();
        }else{
          Pause();
       }
     }
   }

     public void Quit()
     {
         Application.Quit();
         //  Debug.Log("The Game has Quit");
     }
     public void StartButton()
     {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
     }

     public void MainMenu()
     {
         SceneManager.LoadScene(0);
     }

     public void Restart()
     {
        // GM.resetDict();
         SceneManager.LoadScene("SampleScene 1");

     }
    
 public void Pause(){
   PauseMenuUI.SetActive(true);
   Time.timeScale = 0f;
   isGamePaused = false;
 }
 public void Resume(){
PauseMenuUI.SetActive(false);
   Time.timeScale = 1f;
   isGamePaused = true;
 }
 }
