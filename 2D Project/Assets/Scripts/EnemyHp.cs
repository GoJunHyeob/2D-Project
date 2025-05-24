using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [SerializeField]
    private float maxHp = 4; //최대 체력
    private float currentHp; //현재 체력
    private Enemy enemy;
    private SpriteRenderer[] spriteRenderers;

    public float MaxHp => maxHp;
    public float CurrentHp => currentHp;

    private void Awake()
    {
        currentHp = maxHp; //현재 체력을 최대 체력과 같게 설정
        enemy = GetComponent<Enemy>();
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        //현재 체력을 damage만큼 감소
        currentHp -= damage;

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        //체력이 0이하 = 플레이어 캐릭터 사망
        if (currentHp <= 0)
        {
            //적 캐릭터 사망
            enemy.OnDie();
        }
    }
   private IEnumerator HitColorAnimation()
   {
       //적의 색상을 빨간색으로
       for(int i = 0; i < spriteRenderers.Length; i++)
            spriteRenderers[i].color = Color.red;
       //0.05초 동안 대기;
        yield return new WaitForSeconds(0.05f);
        //적의 색상을 원래 색상인 하얀색으로
        for (int i = 0; i < spriteRenderers.Length; i++)
            spriteRenderers[i].color = Color.white;
   }
}
    

