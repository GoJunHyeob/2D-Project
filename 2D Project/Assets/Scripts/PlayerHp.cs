using System.Collections;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    [SerializeField]
    private float maxHp = 10; //�ִ� ü��
    private float currentHp; //���� ü��
    private SpriteRenderer spriteRenderer;

    public float MaxHp => maxHp; // maxHp ������ ������ �� �ִ� ������Ƽ(Get�� ����)
    public float CurrentHp => currentHp; // currentHp ������ ������ �� �ִ� ������Ƽ(Get�� ����)

    private void Awake()
    {
        currentHp = maxHp;
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    public void TakeDamage(float damage)
    {
        //���� ü���� damage��ŭ ����
        currentHp -= damage;

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        //ü���� 0���� = �÷��̾� ĳ���� ���
        if(currentHp <= 0)
        {
            Debug.Log("Player Hp : 0 ...Die");
        }
    }
    
    private  IEnumerator HitColorAnimation()
    {
        //�÷��̾��� ������ ����������
        spriteRenderer.color = Color.red;
        //0.1�� ���� ���
        yield return new WaitForSeconds(0.1f);
        //�÷��̾��� ������ ���� ������ �Ͼ������
        //���� ������ �Ͼ���� �ƴ� ��� ���� ���� ���� ����
        spriteRenderer.color = Color.white;
    }
}
