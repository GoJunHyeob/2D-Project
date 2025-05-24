using UnityEngine;

public class ParticleAutoDestroyer : MonoBehaviour //파티클 오브젝트에 부착 파티클의 재생이 완료되면 오브젝트 삭제
{
    public void OnDieEvent()
    {
          Destroy(gameObject);
    }
}
