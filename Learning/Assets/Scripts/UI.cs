using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public static UI instance;
    private bool isGameOver = false;
    private AudioSource uiAudio;

    [SerializeField] private GameObject gameOverUI;
    [Space]
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI killCountText;

    private int killCount;

    private void Awake()
    {
        instance = this;
        Time.timeScale = 1.0f;
        uiAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isGameOver == false)
        {
            timerText.text = Time.timeSinceLevelLoad.ToString("F2") + "s";
        }
    }

    public void EnableGameOverUI()
    {
        isGameOver = true;
        Time.timeScale = 0.5f;
        gameOverUI.SetActive(true);
        uiAudio.mute = true;
    }

    public void RestartLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    public void AddKillCount()
    {
        killCount++;
        killCountText.text = killCount.ToString();
    }

}
