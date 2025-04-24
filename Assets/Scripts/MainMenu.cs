using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // ¡ESTO ES LO QUE FALTABA!

public class MainMenu : MonoBehaviour
{
    public AudioSource clickSound;
    public string sceneToLoad = "Nivel1";

    public void PlayGame()
    {
        StartCoroutine(PlayAndLoad());
    }

    IEnumerator PlayAndLoad()
    {
        clickSound.Play();
        yield return new WaitForSeconds(clickSound.clip.length);
        SceneManager.LoadScene(sceneToLoad);
    }
}
