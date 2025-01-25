using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timer = 8f;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private Transform emptyObject; 

    void Start()
    {
        if (emptyObject != null && timeText != null)
        {
            timeText.rectTransform.position = emptyObject.position;
        }
    }

    void Update()
    {
        timer -= Time.deltaTime;

        int seconds = Mathf.FloorToInt(timer % 60);
        timeText.text = string.Format("{0:0}", seconds);

        if (emptyObject != null && timeText != null)
        {
            timeText.rectTransform.position = emptyObject.position;
        }
    }
}
