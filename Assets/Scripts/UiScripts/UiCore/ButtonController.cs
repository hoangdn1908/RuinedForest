using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void StartGame() 
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadScene(string scene) 
    {
        SceneManager.LoadScene(scene);
    }

    public void ResumeGame() 
    {
        GameManager.Instance.EnterPlayingState();
    }

    public void ExitGame() 
    {
        Application.Quit();
    }

    public void GoToMainMenu() 
    {
    
    }
}
