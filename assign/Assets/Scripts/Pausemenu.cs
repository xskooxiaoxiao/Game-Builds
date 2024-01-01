using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Threading.Tasks;

public class Mainmenu : MonoBehaviour
{
    [SerializeField] GameObject Pausemenu;
    [SerializeField] RectTransform PausepanelRect;
    [SerializeField] float topPosY, middlePosY;
    [SerializeField] float tweenDuration;
    [SerializeField] CanvasGroup canvasGroup; // BlackPanel canvasgroup

    private bool isAnimating = false;

    public void Pause()
    {
        if (!isAnimating)
        {
            Pausemenu.SetActive(true);
            Time.timeScale = 0;
            PausepanelIntro();
        }
    }

    public async void Resume()
    {
        if (!isAnimating)
        {
            await PausepanelOutro();
            Pausemenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void Restart()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    void PausepanelIntro()
    {
        isAnimating = true;
        canvasGroup.DOFade(2, tweenDuration).SetUpdate(true);
        PausepanelRect.DOAnchorPosY(middlePosY, tweenDuration)
            .SetUpdate(true)
            .OnComplete(() => isAnimating = false);
    }

    async Task PausepanelOutro()
    {
        isAnimating = true;
        canvasGroup.DOFade(0, tweenDuration).SetUpdate(true);

        await PausepanelRect.DOAnchorPosY(topPosY, tweenDuration)
            .SetUpdate(true)
            .AsyncWaitForCompletion();

        isAnimating = false;
    }
}
