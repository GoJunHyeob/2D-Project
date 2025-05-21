using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //�߻�ü�� �ε��� ������Ʈ�� �±װ� "Enemy"�̸�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            //�ε��� ������Ʈ ���ó��(��)
           collision.GetComponent<Enemy>().OnDie();
            //�� ������Ʈ ����(�߻�ü)
            Destroy(gameObject);
        }
    }
}
