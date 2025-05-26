using System.Collections;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    [SerializeField]
    private float maxHp = 10; //�ִ� ü��
    private float currentHp; //���� ü��
    private SpriteRenderer spriteRenderer;
    private PlayerController playerController;

    public float MaxHp => maxHp; // maxHp ������ ������ �� �ִ� ������Ƽ(Get�� ����)
    public float CurrentHp  // currentHp ������ ������ �� �ִ� ������Ƽ(Get�� ����)
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
        //���� ü���� damage��ŭ ����
        currentHp -= damage;

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        //ü���� 0���� = �÷��̾� ĳ���� ���
        if(currentHp <= 0)
        {
            playerController.OnDie();
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
