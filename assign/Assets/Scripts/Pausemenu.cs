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
    public void Pause()
    {
        Pausemenu.SetActive(true);
        Time.timeScale = 0;
        PausepanelIntro();
    }

    public async void Resume()
    {
       await PausepanelOutro();
        Pausemenu.SetActive(false);
        Time.timeScale = 1;

    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;

    }

    public void Restart()
    { 
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1;

    }

    public void Quit()
    {
        Application.Quit();
    }
    void PausepanelIntro()
    {
        canvasGroup.DOFade(2, tweenDuration).SetUpdate(true);
        PausepanelRect.DOAnchorPosY(middlePosY, tweenDuration).SetUpdate(true);
    }

    async Task PausepanelOutro()
    {
        canvasGroup.DOFade(0, tweenDuration).SetUpdate(true);

        await PausepanelRect.DOAnchorPosY(topPosY, tweenDuration).SetUpdate(true).AsyncWaitForCompletion();

    }
}