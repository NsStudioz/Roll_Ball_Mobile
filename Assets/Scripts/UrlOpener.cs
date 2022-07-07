using UnityEngine;

public class UrlOpener : MonoBehaviour
{

    public string Url;

    public void OpenPrivacyPage()
    {
        Application.OpenURL(Url);
    }
}
