using UnityEngine;

public class OpenLinkOnClick : MonoBehaviour
{
    public void OpenLink(string s)
    {
        if (!string.IsNullOrEmpty(s))
        {
            Application.OpenURL(s);
        }
        else
        {
            Debug.LogWarning("No URL specified for this button.");
        }
    }
}