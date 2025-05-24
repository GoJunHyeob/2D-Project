using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class ResultScoreViewer : MonoBehaviour
{
    private TextMeshProUGUI textResultScore;
    [SerializeField]
    private bool isScore;
    private int score;
    private void Awake()
    {
        textResultScore = GetComponent<TextMeshProUGUI>();
        //�ְ������� ǥ���ϴ°��� �ƴϸ� �� ���� ������ ǥ���ϴ� ���� ��
        if (isScore)
        {
            //stage���� ������ ������ �ҷ��ͼ� score������ ����
            score = PlayerPrefs.GetInt("Score");
        }
        else
        {
            score = PlayerPrefs.GetInt("BestScore");
        }

        textResultScore.text += score;
    }

}
