using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonNav : MonoBehaviour {

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void HowToPlayButton()
    {
        SceneManager.LoadScene(2);
    }

    public void GoBackButton()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
