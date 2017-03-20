using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
	kkkkoyo original sample
*/
public class DataManual : MonoBehaviour
{
    /*パネルをスライド */
    [SerializeField] private PanelSlider panel;
    public void PanelSlideIn()
    {
        panel.SlideIn();
    }
    public void PanelSlideOut()
    {
        panel.SlideOut();
    }

    /*シーンの遷移*/
    public void GoNextScene(bool isAsynchronous, string SceneName)
    {
        if (isAsynchronous)
        {
            StartCoroutine(GoGame(SceneName));
        }
        else
        {
            SceneManager.LoadScene(SceneName);
        }
    }
    private IEnumerator GoGame(string SceneName)
    {
        AsyncOperation async;
        async = SceneManager.LoadSceneAsync(SceneName);
        yield return async;
    }
}
