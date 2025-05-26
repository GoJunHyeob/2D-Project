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
    [SerializeField]
    private GameObject[] itemPrefabs; //���� �׿��� �� ȹ�� ������ ������
    
    private PlayerController playerController; //�÷��̾��� ���� ������ �����ϱ� ����

    protected virtual void Awake()
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
        //���� Ȯ���� ������ ����
        SpawnItem();
        //�� ������Ʈ ����
        Destroy(gameObject);
    }

    public void SpawnItem()
    {
        //�Ŀ���(5%), ü��ȸ��(5%), ���ǵ��(10%)
        float spawnItem = Random.value;
        if(spawnItem <= 0.05f)
        {
            Instantiate(itemPrefabs[0], transform.position, Quaternion.identity);
        }
        else if (spawnItem > 0.05f &&  spawnItem <= 0.15f)
        {
            Instantiate(itemPrefabs[2], transform.position, Quaternion.identity);
        }
        if (spawnItem > 0.015f && spawnItem <= 0.02f)
        {
            Instantiate(itemPrefabs[1], transform.position, Quaternion.identity);
        }
    }
}
