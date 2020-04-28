using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    private bool m_isLoading = false;
    [SerializeField] private float m_minLoadTime = 3.0f;

   private void Awake()
   {
       DontDestroyOnLoad(this.gameObject);
   }

   private void Start()
   {
       Hide();
   }

   public void Show()
   {
       this.gameObject.SetActive(true);
   }

   public void Load(string scene)
   {
       if(m_isLoading) return;
       Show();
       StartCoroutine(LoadScene(scene));
   }

   private IEnumerator LoadScene(string scene)
   {
       float startTime = Time.realtimeSinceStartup;
       m_isLoading = true;
       AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);
       while(asyncLoad.isDone == false)
       {
           yield return null;
       }
       float loadTime = Time.realtimeSinceStartup - startTime;
       if(loadTime < m_minLoadTime)
       {
           yield return new WaitForSeconds(m_minLoadTime-loadTime);
       }
       m_isLoading = false;
       Hide();
       GameObject.Destroy(this.gameObject);
   }

   public void Hide()
   {
      this.gameObject.SetActive(false);
   }
}
