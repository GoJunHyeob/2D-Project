using UnityEngine;

public class ParticleAutoDestroyer : MonoBehaviour //��ƼŬ ������Ʈ�� ���� ��ƼŬ�� ����� �Ϸ�Ǹ� ������Ʈ ����
{
    public void OnDieEvent()
    {
          Destroy(gameObject);
    }
}
