using UnityEngine;
using UnityEngine.UI;

public class PlayerHpViewer : MonoBehaviour //플레이어 체력 정보를 Slider UI에 업데이트
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
        //Slider UI에 현재 체력 정보를 업데이트
        sliderHp.value = playerHp.CurrentHp / playerHp.MaxHp; 
    }

}
