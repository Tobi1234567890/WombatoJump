using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartScene(string sceneToStartName)
    {
        SceneManager.LoadScene(sceneToStartName);
    }

    public void ExitGame()
    {
        Application.Quit(0);
    }
}
