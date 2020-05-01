using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnimToGameplay : MonoBehaviour
{

  [SerializeField] private LoadingScreen ls;

  private float animTime = 0;
    // Start is called before the first frame update
    void Start()
    {
      StartCoroutine(GoToGameplay());
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.anyKey)
      {
        ls.Load("SampleScene 1");
      }
    }

    IEnumerator GoToGameplay()
    {
        yield return new WaitForSeconds(21f);

          ls.Load("SampleScene 1");
          //SceneManager.LoadScene(2);
    }
}
