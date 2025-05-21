using UnityEngine;
using TMPro;


public class PlayerScoreViewer : MonoBehaviour // �÷��̾��� ���� ������ Text UI�� ������Ʈ

{
    [SerializeField]
    private PlayerController PlayerController;
    private TextMeshProUGUI textScore;

    private void Awake()
    {
        textScore = GetComponent<TextMeshProUGUI>();
    } 

    private void Update()
    {
        //text UI�� ���� ���� ������ ������Ʈ
        textScore.text = "Score " + PlayerController.Score;
    }
}
