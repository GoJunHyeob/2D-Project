
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Movement2D : MonoBehaviour // �̵� ������ ��� ������Ʈ���� ����
{
    [SerializeField]
    private float moveSpeed = 0.0f;
    [SerializeField]
    private Vector3 moveDirection = Vector3.zero;
 

    public float MoveSpeed
    {
        set => moveSpeed = value;
        get => moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    public void MoveTo(Vector3 direction) //�ܺο��� ȣ���� �̵� ������ ����
    {
        moveDirection = direction;
    }

    //speed ������ ������Ʈ�� �Ծ����� 
    public void SpeedAdujust()
    {
        StartCoroutine("SpeedAdjustment");
    }

    private IEnumerator SpeedAdjustment()
    {
       MoveSpeed += 3;

       yield return new WaitForSeconds(2.0f);

       MoveSpeed -= 3;
    }
}
