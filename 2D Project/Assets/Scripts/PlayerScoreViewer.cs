using UnityEngine;
using TMPro;


public class PlayerScoreViewer : MonoBehaviour // 플레이어의 점수 정보를 Text UI에 업데이트

{
    [SerializeField]
    private PlayerController PlayerController;
    private TextMeshProUGUI textScore;
    [SerializeField]
    private bool isPauseUI;
    private void Awake()
    {
        textScore = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        textScore.text = PlayerController.Score.ToString();
    }

    private void Update()
    {
        if (!isPauseUI)
        {
            //text UI에 현재 점수 정보를 업데이트
            textScore.text = "Score " + PlayerController.Score;
        }

    }
}
