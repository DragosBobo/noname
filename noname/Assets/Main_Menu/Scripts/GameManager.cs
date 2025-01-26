using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public int beersDrunk;
    public int beersDelivered;
    public float survivedTime;

    private bool isPlaying;

   private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (isPlaying)
        survivedTime += Time.deltaTime;
    }

    public void BeersDrunk()
    {
        beersDrunk++;
    }

    public void BeersDelivered()
    {
        beersDelivered++;
    }

    public void StartPlaying()
    {
        survivedTime = 0;
        beersDelivered=0;
        beersDrunk=0;
        isPlaying = true;
    }

    public void StopPlaying()
    {
        isPlaying = false;
    }

}
