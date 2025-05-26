using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab; // ������ �� �����Ǵ� �߻�ü ������
    [SerializeField]
    private float attackRate;//���� �ӵ�
    [SerializeField]
    private int maxAttackLevel = 3;//���� �ִ� ����
    private int attackLevel = 1; //���� ����

    public int AttackLevel
    {
        set => attackLevel = Mathf.Clamp(value, 1, maxAttackLevel);
        get => attackLevel;
    }

    public void StartFiring()
    { 
        StartCoroutine("TryAttack");
    }

    public void StopFiring()
    {
        StopCoroutine("TryAttack");
    }

    private IEnumerator TryAttack()
    {
        while (true)
        {
            //�߻�ü ������Ʈ ����
            AttackByLevel();

            // attackRate �ð���ŭ ���
            yield return new WaitForSeconds(attackRate);
        }
    }

   private void AttackByLevel()
    {
        GameObject cloneProjectile = null;

        switch(attackLevel)
        {
            case 1: //Level 01 : ������ ���� �߻�ü 1�� ����
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                break;
            case 2: //Level 02 : ������ �ΰ� �������� �߻�ü 2�� ����
                Instantiate(projectilePrefab, transform.position + Vector3.left * 0.2f, Quaternion.identity);
                Instantiate(projectilePrefab, transform.position + Vector3.right * 0.2f, Quaternion.identity);
                break;
            case 3: //Level 03 : �������� �߻�ü 1��, �밢�� �������� �߻�ü 2�� �߻�
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                // ���� �밢�� �������� 
                cloneProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                cloneProjectile.GetComponent<Movement2D>().MoveTo(new Vector3(-0.2f, 1, 0));
                // ������ �밢�� �������� 
                cloneProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                cloneProjectile.GetComponent<Movement2D>().MoveTo(new Vector3(0.2f, 1, 0));
                break;
        }
    }
}
