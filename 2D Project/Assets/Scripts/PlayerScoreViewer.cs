using UnityEngine;
using TMPro;


public class PlayerScoreViewer : MonoBehaviour // �÷��̾��� ���� ������ Text UI�� ������Ʈ

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
            //text UI�� ���� ���� ������ ������Ʈ
            textScore.text = "Score " + PlayerController.Score;
        }

    }
}
