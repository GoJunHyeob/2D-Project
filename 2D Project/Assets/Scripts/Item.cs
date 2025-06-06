using System.Collections;
using UnityEngine;

public enum ItemType { PowerUp = 0, Hp, Speed}
public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemType itemType;
    private Movement2D movement2D;

    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();

        float x = Random.Range(-1.0f, 1.0f);
        float y = Random.Range(-1.0f, 1.0f);

        movement2D.MoveTo(new Vector3(x, y, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //아이템 획득 시 효과
            Use(collision.gameObject);
            //아이템 오브젝트 삭제
            Destroy(gameObject);
        }
    }

    public void Use(GameObject player)
    {
        switch (itemType)
        {
            case ItemType.PowerUp:
                player.GetComponent<Weapon>().AttackLevel++;
                break;
            case ItemType.Hp:
                player.GetComponent<PlayerHp>().CurrentHp += 2;
                break;
            case ItemType.Speed:
                player.GetComponent<Movement2D>().SpeedAdujust();
                break;
        }
    }

}
