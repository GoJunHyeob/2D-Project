using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement2D : MonoBehaviour // �̵� ������ ��� ������Ʈ���� ����
{
    [SerializeField]
    private float moveSpeed = 0.0f;
    [SerializeField]
    private Vector3 moveDirection = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    public void MoveTo(Vector3 direction) //�ܺο��� ȣ���� �̵� ������ ����
    {
        moveDirection = direction;
    }
}
