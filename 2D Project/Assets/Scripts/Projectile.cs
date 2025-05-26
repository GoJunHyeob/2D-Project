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
        //플레이어가 발사한 미사일이고
        //발사체에 부딪힌 오브젝트의 태그가 "Enemy"이면
        if (isPlayerbullet)
        {

            if (collision.CompareTag("Enemy"))
            {
                //부딪힌 오브젝트 데미지 주기
                collision.GetComponent<EnemyHp>().TakeDamage(damage);
                //내 오브젝트 삭제(발사체)
                Destroy(gameObject);
            }
        }
        //플레이어가 발사한 미사일이아니고
        //발사체에 부딪힌 오브젝트의 태그가 "Player"이면
        else
        {
            if (collision.CompareTag("Player"))
            {
                //부딪힌 오브젝트 데미지 주기
                collision.GetComponent<PlayerHp>().TakeDamage(damage);
                //내 오브젝트 삭제(발사체)
                Destroy(gameObject);
            }
        }
    }
}
