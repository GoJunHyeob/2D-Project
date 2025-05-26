using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{
    public void SceneLoader(string sceneName)
    {
        //일시정지 후 시작할때 timescale을 1로 다시 바꾸어준다
        if(Time.timeScale == 0)
            Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

    public void Finisher()
    {
        Application.Quit();
    }

    public void ManualUiOpen(GameObject UI)
    {
        UI.SetActive(true);
    }

    public void ManualUiOff()
    {
        gameObject.SetActive(false);
    }
}
