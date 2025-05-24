using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 1; //적 공격력
    [SerializeField]
    private int scorePoint = 10; //적 처치시 획득 점수
    [SerializeField]
    private GameObject explosionPrefab; //폭발 효과
    private PlayerController playerController; //플레이어의 점수 정보에 접근하기 위해

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //적에게 부딪힌 오브젝트의 태그가 "Player"이면
        if(collision.CompareTag("Player"))
        {
            //적 공격력만큼 플레이어 체력 감소
            collision.GetComponent<PlayerHp>().TakeDamage(damage);
            //적 사망
            OnDie();
        }
    }

    public void OnDie()
    {
        //폭발 이펙트 생성
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        //플레이어의 점수를 scorePoint만큼 증가시킨다
        playerController.Score += scorePoint;
        //만약 플레이어의 점수가 최고점수보다 높아질 경우 최고점수를 갱신
        if (playerController.Score > playerController.bestscore)
            playerController.bestscore = playerController.Score;
        //적 오브젝트 삭제
        Destroy(gameObject);
    }
}
