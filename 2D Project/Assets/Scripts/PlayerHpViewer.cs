using UnityEngine;
using UnityEngine.UI;

public class PlayerHpViewer : MonoBehaviour //�÷��̾� ü�� ������ Slider UI�� ������Ʈ
{
    [SerializeField]
    private PlayerHp playerHp;
    private Slider sliderHp;

    private void Awake()
    {
        sliderHp = GetComponent<Slider>();
    }

    private void Update()
    {
        //Slider UI�� ���� ü�� ������ ������Ʈ
        sliderHp.value = playerHp.CurrentHp / playerHp.MaxHp; 
    }

}
