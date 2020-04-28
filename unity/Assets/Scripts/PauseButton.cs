using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{

  public GameObject pauseScreen;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

  /*  function OnMouseOver()
    {
    if(Input.GetMouseDown(0){
       // Whatever you want it to do.
    }
 } */

 public void pauseGame()
 {
     pauseScreen.gameObject.SetActive(true);
}
}
