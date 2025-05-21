using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //발사체에 부딪힌 오브젝트의 태그가 "Enemy"이면
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            //부딪힌 오브젝트 사망처리(적)
           collision.GetComponent<Enemy>().OnDie();
            //내 오브젝트 삭제(발사체)
            Destroy(gameObject);
        }
    }
}
