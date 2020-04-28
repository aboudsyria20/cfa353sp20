using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    [SerializeField] private float m_minLoadTime = 3.0f;
   private bool m_hideRequested;
   private bool m_hiding;

   private float m_timeElapsed;

   private void Awake()
   {
       DontDestroyOnLoad(this.gameObject);
       Hide();

   }

   public void Show()
   {
       this.gameObject.SetActive(true);
   }

   public void Load(string scene)
   {
       Show();
       StartCoroutine(LoadScene(scene));
   }

   private IEnumerator LoadScene(string scene)
   {
       AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);
       while(asyncLoad.isDone == false)
       {
           yield return null;
       }
       Hide();
   }

   public void Hide()
   {
      this.gameObject.SetActive(false);
   }


    // Update is called once per frame
    void Update()
    {
      m_timeElapsed += Time.deltaTime;

              if(m_hideRequested && m_timeElapsed >= m_minLoadTime && !m_hiding)
              {
                  m_hiding = true;
              }

              float finalValue = m_hiding?0:1;
    }
}
