using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement2D : MonoBehaviour // 이동 가능한 모든 오브젝트에게 부착
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

    public void MoveTo(Vector3 direction) //외부에서 호출해 이동 방향을 결정
    {
        moveDirection = direction;
    }
}
