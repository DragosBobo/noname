using UnityEngine;
using UnityEngine.SceneManagement;


public class EndMenu : MonoBehaviour
{
    [SerializeField] GameObject endMenu;
   
   public void Home()
   {
        SceneManager.LoadScene(0);
    }

   public void Restart()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }

   public void Quit()
   {
     Application.Quit();
   }


}
