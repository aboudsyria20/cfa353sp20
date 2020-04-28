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

   [SerializeField] private string m_sceneToLoadOnAwake;

   private void Awake()
   {
       DontDestroyOnLoad(this.gameObject);

       if(!string.IsNullOrEmpty(m_sceneToLoadOnAwake))
       {
           Load(m_sceneToLoadOnAwake);
       }
   }

   public void Show()
   {
       m_timeElapsed = 0.0f;
       m_hiding = false;
   }

   public void Load(string scene)
   {
       Show();
       StartCoroutine(LoadScene(scene));
   }

   private IEnumerator LoadScene(string scene)
   {
       yield return new WaitForSeconds(0.35f); //artificial delay for fade

       AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);
       while(asyncLoad.isDone == false)
       {
           yield return null;
       }
       Hide();
   }

   public void Hide()
   {
       m_hideRequested = true;
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
