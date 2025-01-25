using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleAudioManager : MonoBehaviour
{
   static SingleAudioManager instance;
   AudioSource audioSource;

   void Awake()
   {
       if(instance != null)
       {
           Destroy(gameObject);
           return;
       }
       
       instance = this;
       DontDestroyOnLoad(gameObject);
       audioSource = GetComponent<AudioSource>();
       
       SceneManager.sceneLoaded += OnSceneLoaded;
   }

   void OnSceneLoaded(Scene scene, LoadSceneMode mode)
   {
       int sceneIndex = scene.buildIndex;
       audioSource.volume = sceneIndex == 0 ? 0.8f : 0.3f;
   }

   void OnDestroy()
   {
       SceneManager.sceneLoaded -= OnSceneLoaded;
   }
}