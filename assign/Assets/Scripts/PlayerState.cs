using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour
{
    public int PlayerHealth = 10;
    public int enemyTotal;

    public Button Retry;
    public Button MainMenu;
    public TextMeshProUGUI lose;
    public TextMeshProUGUI win;
    public TextMeshProUGUI hp;
    public Image HPbar;

    WaveSpawner waveSpawner;

    private bool isTransitioning = false;

    void Awake()
    {
        waveSpawner = GameObject.Find("GameControl").GetComponent<WaveSpawner>();
    }

    void OnEnable()
    {
        Retry.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(false);
        lose.gameObject.SetActive(false);
        win.gameObject.SetActive(false);
    }

    public void Scene1()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Start()
    {
        StartCoroutine(UpdateHealthTextSmoothly());
    }

    void Update()
    {
        if (PlayerHealth <= 0)
        {
            StartCoroutine(ShowGameOverUI());
        }
        else if (PlayerHealth > 0 && waveSpawner.gameEnd == true)
        {
            StartCoroutine(ShowWinUI());
        }
    }

    IEnumerator UpdateHealthTextSmoothly()
    {
        while (PlayerHealth > 0)
        {
            // Update the health text
            hp.text = "HP: " + PlayerHealth.ToString();

            // Wait for a short duration before updating again
            yield return new WaitForSeconds(0.1f);
        }

        // Additional handling for when the player's health reaches 0
        hp.text = "HP: 0";
    }

    IEnumerator ShowGameOverUI()
    {
        Retry.gameObject.SetActive(true);
        MainMenu.gameObject.SetActive(true);
        lose.gameObject.SetActive(true);
        yield return null; // Add any additional delay or transition effects here
    }

    IEnumerator ShowWinUI()
    {
        Retry.gameObject.SetActive(true);
        MainMenu.gameObject.SetActive(true);
        win.gameObject.SetActive(true);
        yield return null; // Add any additional delay or transition effects here
    }
}
