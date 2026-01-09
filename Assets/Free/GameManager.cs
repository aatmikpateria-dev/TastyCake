using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Cakes")]
    public int cakesCollected = 0;
    private int totalCakes;

    [Header("Trap Triggers")]
    public int staticTrapTrigger = 2;
    public int movingTrapTrigger = 3;
    public int extraTrapTrigger = 5;

    [Header("Traps")]
    public GameObject[] staticTraps;
    public GameObject[] movingTraps;
    public GameObject[] extraTraps;

    [Header("UI")]
    public GameObject winPanel;
    public GameObject deathPanel;

    [Header("Audio")]
    public AudioClip startAudio;
    public AudioClip firstCakeAudio;
    public AudioClip endAudio;

    private AudioSource audioSource;
    private bool gameOver = false;

    private bool staticOn, movingOn, extraOn;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        DisableTraps(staticTraps);
        DisableTraps(movingTraps);
        DisableTraps(extraTraps);

        totalCakes = FindObjectsOfType<Cake>().Length;

        if (startAudio != null)
            audioSource.PlayOneShot(startAudio);
    }

    void DisableTraps(GameObject[] traps)
    {
        foreach (GameObject t in traps)
            if (t != null) t.SetActive(false);
    }

    void EnableTraps(GameObject[] traps)
    {
        foreach (GameObject t in traps)
            if (t != null) t.SetActive(true);
    }

    public void AddCake()
    {
        if (gameOver) return;

        cakesCollected++;

        if (cakesCollected == 1 && firstCakeAudio != null)
            audioSource.PlayOneShot(firstCakeAudio);

        if (cakesCollected >= staticTrapTrigger && !staticOn)
        {
            staticOn = true;
            EnableTraps(staticTraps);
        }

        if (cakesCollected >= movingTrapTrigger && !movingOn)
        {
            movingOn = true;
            EnableTraps(movingTraps);
        }

        if (cakesCollected >= extraTrapTrigger && !extraOn)
        {
            extraOn = true;
            EnableTraps(extraTraps);
        }

        if (cakesCollected >= totalCakes)
        {
            PermanentDeath();
        }
    }

    void PermanentDeath()
    {
        if (gameOver) return;
        gameOver = true;

        if (endAudio != null)
            audioSource.PlayOneShot(endAudio);

        if (deathPanel != null)
            deathPanel.SetActive(true);

        Time.timeScale = 0f;

        PlayerMovement pm = FindObjectOfType<PlayerMovement>();
        if (pm != null)
            pm.DiePermanently();
    }


    public void WinGame()
    {
        if (gameOver) return;
        gameOver = true;

        if (endAudio != null)
            audioSource.PlayOneShot(endAudio);

        if (winPanel != null)
            winPanel.SetActive(true);

        Time.timeScale = 0f;
    }
}
