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
        //최고점수를 표기하는건지 아니면 그 판의 점수를 표기하는 건지 비교
        if (isScore)
        {
            //stage에서 저장한 점수를 불러와서 score변수에 저장
            score = PlayerPrefs.GetInt("Score");
        }
        else
        {
            score = PlayerPrefs.GetInt("BestScore");
        }

        textResultScore.text += score;
    }

}
