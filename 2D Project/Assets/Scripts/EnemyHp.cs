using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [SerializeField]
    private float maxHp = 4; //�ִ� ü��
    private float currentHp; //���� ü��
    private Enemy enemy;
    private SpriteRenderer[] spriteRenderers;

    public float MaxHp => maxHp;
    public float CurrentHp => currentHp;

    private void Awake()
    {
        currentHp = maxHp; //���� ü���� �ִ� ü�°� ���� ����
        enemy = GetComponent<Enemy>();
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        //���� ü���� damage��ŭ ����
        currentHp -= damage;

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        //ü���� 0���� = �÷��̾� ĳ���� ���
        if (currentHp <= 0)
        {
            //�� ĳ���� ���
            enemy.OnDie();
        }
    }
   private IEnumerator HitColorAnimation()
   {
       //���� ������ ����������
       for(int i = 0; i < spriteRenderers.Length; i++)
            spriteRenderers[i].color = Color.red;
       //0.05�� ���� ���;
        yield return new WaitForSeconds(0.05f);
        //���� ������ ���� ������ �Ͼ������
        for (int i = 0; i < spriteRenderers.Length; i++)
            spriteRenderers[i].color = Color.white;
   }
}
    

