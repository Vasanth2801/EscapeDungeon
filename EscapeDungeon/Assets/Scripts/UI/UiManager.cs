using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    
    public GameObject resumePanel;
    bool isPaused = false;




    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        resumePanel.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    void Pause()
    {
        resumePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }


}
