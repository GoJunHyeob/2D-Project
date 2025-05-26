using System.Collections;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    [SerializeField]
    private float maxHp = 10; //최대 체력
    private float currentHp; //현재 체력
    private SpriteRenderer spriteRenderer;
    private PlayerController playerController;

    public float MaxHp => maxHp; // maxHp 변수에 접근할 수 있는 프로퍼티(Get만 가능)
    public float CurrentHp  // currentHp 변수에 접근할 수 있는 프로퍼티(Get만 가능)
    {
        set => currentHp = Mathf.Clamp(value, 0, maxHp);
        get => currentHp;
    }

    private void Awake()
    {
        currentHp = maxHp;
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerController = GetComponent<PlayerController>();
    }

    public void TakeDamage(float damage)
    {
        //현재 체력을 damage만큼 감소
        currentHp -= damage;

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        //체력이 0이하 = 플레이어 캐릭터 사망
        if(currentHp <= 0)
        {
            playerController.OnDie();
        }
    }
    
    private  IEnumerator HitColorAnimation()
    {
        //플레이어의 색상을 빨간색으로
        spriteRenderer.color = Color.red;
        //0.1초 동안 대기
        yield return new WaitForSeconds(0.1f);
        //플레이어의 색상을 원래 색상인 하얀색으로
        //원래 색상이 하얀색이 아닐 경우 원래 색상 변수 선언
        spriteRenderer.color = Color.white;
    }
}
