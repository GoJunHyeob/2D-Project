using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{
    public void SceneLoader(string sceneName)
    {
        //�Ͻ����� �� �����Ҷ� timescale�� 1�� �ٽ� �ٲپ��ش�
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
