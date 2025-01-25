using UnityEngine;

public class SingleAudioManager : MonoBehaviour
{
   static SingleAudioManager instance;

   void Awake()
   {
    if(instance != null)
    {
        Destroy(gameObject);
    }
    else
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
   }
}
