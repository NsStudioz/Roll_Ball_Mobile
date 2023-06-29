using UnityEngine;

public class UrlOpener : MonoBehaviour
{

    [SerializeField] string Url;

    public void OpenPrivacyPage()
    {
        Application.OpenURL(Url);
    }
}
