using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour //�÷��̾� �ɸ��Ϳ� �����ؼ� ���
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
        //score���� ������ ���� �ʵ���
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
        //�ְ������� 0���� ���� �ʰ� ����̽��� ����� �ְ������� �����´�
        bestscore = PlayerPrefs.GetInt("BestScore");
    }

   
    void Update()
    {
        //�׾��� ��� �̵� ���� ���ϰ�
        if (isDead == true) return;

        if (score > bestscore)
            bestscore = score;
        //���� Ű�� ���� �̵� ���� ����
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement2D.MoveTo(new Vector3(x, y, 0));

        //���� Ű�� Down/Up���� ���� ����/����
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
        //�÷��̾� ĳ���Ͱ� ȭ�� ���� �ٱ����� ������ ���ϵ��� ��
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x + sizewidth/2, stageData.LimitMax.x - sizewidth/2),
                                         Mathf.Clamp(transform.position.y, stageData.LimitMin.y + sizeheight/2, stageData.LimitMax.y - sizeheight/2));
    }

    public void OnDie()
    {
        //�̵����� �ʱ�ȭ
        movement2D.MoveTo(Vector3.zero);
        //��� �ִϸ��̼� ����
        anim.SetTrigger("onDie");
        //����� �浹���� �ʵ��� �浹 �ڽ� ����
        Destroy(GetComponent<CircleCollider2D>());
        isDead = true;
        
    }

    public void OnDieEvent()
    {
        //����̽��� ȹ���� ���� score ����
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("BestScore", bestscore);
        //�÷��̾� ��� �� nextSreenName ������ �̵�
        SceneManager.LoadScene(NextSceneName);
    }
}

