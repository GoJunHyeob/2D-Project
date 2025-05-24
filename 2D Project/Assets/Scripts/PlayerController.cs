using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour //플레이어 케릭터에 부착해서 사용
{
    [SerializeField]
    private string NextSceneName;
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private KeyCode keyCodeAttack = KeyCode.Space;
    [SerializeField]
    private Animator anim;
    private bool isDead = false;
    private Movement2D movement2D;
    private Weapon weapon;

    private int score;
    public int bestscore = 0;

    private float sizewidth;
    private float sizeheight;
    
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
        anim = GetComponent<Animator>();

        sizeheight = GetComponent<RectTransform>().rect.width * 0.8f;
        sizewidth = GetComponent<RectTransform>().rect.height * 0.8f;
        //최고점수가 0으로 되지 않게 디바이스에 저장된 최고점수를 가져온다
        bestscore = PlayerPrefs.GetInt("BestScore");
    }

   
    void Update()
    {
        //죽었을 경우 이동 공격 못하게
        if (isDead == true) return;

        if (score > bestscore)
            bestscore = score;
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

    public void OnDie()
    {
        //이동방향 초기화
        movement2D.MoveTo(Vector3.zero);
        //사망 애니매이션 실행
        anim.SetTrigger("onDie");
        //적들과 충돌하지 않도록 충돌 박스 삭제
        Destroy(GetComponent<CircleCollider2D>());
        isDead = true;
        
    }

    public void OnDieEvent()
    {
        //디바이스에 획득한 점수 score 저장
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("BestScore", bestscore);
        //플레이어 사망 시 nextSreenName 씬으로 이동
        SceneManager.LoadScene(NextSceneName);
    }
}

