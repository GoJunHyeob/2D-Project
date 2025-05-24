using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 1; //�� ���ݷ�
    [SerializeField]
    private int scorePoint = 10; //�� óġ�� ȹ�� ����
    [SerializeField]
    private GameObject explosionPrefab; //���� ȿ��
    private PlayerController playerController; //�÷��̾��� ���� ������ �����ϱ� ����

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //������ �ε��� ������Ʈ�� �±װ� "Player"�̸�
        if(collision.CompareTag("Player"))
        {
            //�� ���ݷ¸�ŭ �÷��̾� ü�� ����
            collision.GetComponent<PlayerHp>().TakeDamage(damage);
            //�� ���
            OnDie();
        }
    }

    public void OnDie()
    {
        //���� ����Ʈ ����
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        //�÷��̾��� ������ scorePoint��ŭ ������Ų��
        playerController.Score += scorePoint;
        //���� �÷��̾��� ������ �ְ��������� ������ ��� �ְ������� ����
        if (playerController.Score > playerController.bestscore)
            playerController.bestscore = playerController.Score;
        //�� ������Ʈ ����
        Destroy(gameObject);
    }
}
