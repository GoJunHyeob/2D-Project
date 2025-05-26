using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private bool isPlayerbullet;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�÷��̾ �߻��� �̻����̰�
        //�߻�ü�� �ε��� ������Ʈ�� �±װ� "Enemy"�̸�
        if (isPlayerbullet)
        {

            if (collision.CompareTag("Enemy"))
            {
                //�ε��� ������Ʈ ������ �ֱ�
                collision.GetComponent<EnemyHp>().TakeDamage(damage);
                //�� ������Ʈ ����(�߻�ü)
                Destroy(gameObject);
            }
        }
        //�÷��̾ �߻��� �̻����̾ƴϰ�
        //�߻�ü�� �ε��� ������Ʈ�� �±װ� "Player"�̸�
        else
        {
            if (collision.CompareTag("Player"))
            {
                //�ε��� ������Ʈ ������ �ֱ�
                collision.GetComponent<PlayerHp>().TakeDamage(damage);
                //�� ������Ʈ ����(�߻�ü)
                Destroy(gameObject);
            }
        }
    }
}
