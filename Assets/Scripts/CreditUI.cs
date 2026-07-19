using UnityEngine;

public class CreditUI : MonoBehaviour
{
    public GameObject creditPanel;
    public GameObject backgroundOverlay;

    public AudioSource audioSource;
    public AudioClip clickSound;

    public void ShowCredit()
    {
        audioSource.PlayOneShot(clickSound);

        creditPanel.SetActive(true);
        backgroundOverlay.SetActive(true);
    }

    public void HideCredit()
    {
        creditPanel.SetActive(false);
        backgroundOverlay.SetActive(false);
    }
}