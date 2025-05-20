using UnityEngine;
using UnityEngine.EventSystems;

public class PositionScroller : MonoBehaviour
{
    [SerializeField]
    private Transform target; //���� ���ӿ����� �ΰ��� ����� ���ΰ� ������ Ÿ��
    [SerializeField]
    private float scrollRange = 11.4f;
    [SerializeField]
    private float moveSpeed = 3.0f;
    [SerializeField]
    private Vector3 moveDirection = Vector3.down;

    public void Update()
    {
        //����� moveDirection�������� moveSpeed �ӵ��� �̵�
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        //����� ������ ������ ����� ��ġ �缳��
        if(transform.position.y <= -scrollRange)
        {
            transform.position = target.position + Vector3.up*scrollRange;
        }
    }
}
