using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartButton : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickSound;

    public void OnClickGameStart()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        audioSource.PlayOneShot(clickSound);

        yield return new WaitForSeconds(0.2f);

        SceneManager.LoadScene("Scene2");
    }
}