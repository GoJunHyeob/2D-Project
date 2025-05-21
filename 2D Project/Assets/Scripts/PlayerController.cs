using UnityEngine;

public class PlayerController : MonoBehaviour //�÷��̾� �ɸ��Ϳ� �����ؼ� ���
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
        //score���� ������ ���� �ʵ���
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
}
