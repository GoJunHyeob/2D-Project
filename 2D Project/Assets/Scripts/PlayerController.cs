using UnityEngine;

public class PlayerController : MonoBehaviour //플레이어 케릭터에 부착해서 사용
{
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private KeyCode keyCodeAttack = KeyCode.Space; 
    private Movement2D movement2D;
    private Weapon weapon;
    private float sizewidth;
    private float sizeheight;

    private int score;
    public int Score
    {
        //score값이 음수가 되지 않도록
        set => score = Mathf.Max(0, value);
        get => score;
    }

    void Awake()
    {
        movement2D = GetComponent<Movement2D>();
        weapon = GetComponent<Weapon>();
        sizeheight = GetComponent<RectTransform>().rect.width * 0.8f;
        sizewidth = GetComponent<RectTransform>().rect.height * 0.8f;
      
    }

   
    void Update()
    {
        //방향 키를 눌러 이동 방향 설정
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement2D.MoveTo(new Vector3(x, y, 0));

        //공격 키를 Down/Up으로 공격 시작/종료
        if(Input.GetKeyDown(keyCodeAttack))
        {
            weapon.StartFiring();
        }
        else if(Input.GetKeyUp(keyCodeAttack))
        {
            weapon.StopFiring();
        }

    }

    private void LateUpdate()
    {
        //플레이어 캐릭터가 화면 범위 바깥으로 나가지 못하도록 함
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x + sizewidth/2, stageData.LimitMax.x - sizewidth/2),
                                         Mathf.Clamp(transform.position.y, stageData.LimitMin.y + sizeheight/2, stageData.LimitMax.y - sizeheight/2));
    }
}
