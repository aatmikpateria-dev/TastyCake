using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESC pressed");

            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        Debug.Log("Game Paused");
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        Debug.Log("Game Resumed");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    private void OnDisable()
    {
        // SAFETY NET: if this object ever disables, unpause the game
        Time.timeScale = 1f;
    }
}


