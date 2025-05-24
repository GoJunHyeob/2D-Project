using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private StageData stageData; //�� ������ ���� �������� ũ�� ����
    [SerializeField]
    private GameObject enemyPrefab; //  �����ؼ� ������ �� ĳ���� ������
    [SerializeField]
    private GameObject enemyHpSliderPrefab; //�� ü���� ��Ÿ���� Slider UI������
    [SerializeField]
    private Transform canvasTransform; //UI�� ǥ���ϴ� Canvas ������Ʈ�� Transform
    [SerializeField]
    private float spawnTime; // ���� �ֱ�

    private void Awake()
    {
        StartCoroutine("SpawnEnemy");
      
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            //x ��ġ�� ���������� ũ�� ���� ������ ������ ���� ����
            float positionX = Random.Range(stageData.LimitMin.x + 0.5f, stageData.LimitMax.x - 0.5f);
            //�� ���� ��ġ
            Vector3 position = new Vector3(positionX, stageData.LimitMax.y, 0.0f);
            //�� ĳ���� ����
            GameObject enemyClone = Instantiate(enemyPrefab, position, Quaternion.identity);
            //�� ü���� ��Ÿ���� Slider UI ���� �� ����
            SpawnEnemyHpSlider(enemyClone);
            //spawnTime��ŭ ���
            yield return new WaitForSeconds(spawnTime);
        }
    }

    private void SpawnEnemyHpSlider(GameObject enemy)
    {
        //�� ü���� ��Ÿ���� Slider UI����
        GameObject sliderClone = Instantiate(enemyHpSliderPrefab);
        //Slider.UI ������Ʈ�� parent�� �ڽ����� ����
        sliderClone.transform.SetParent(canvasTransform);
        //���� �������� �ٲ� ũ�⸦ �ٽ�(1,1,1)�� ����
        sliderClone.transform.localScale = Vector3.one;
        //Slider UI�� �Ѿƴٴ� ����� ������ ������ ����
       sliderClone.GetComponent<SliderPositionAutoSetter>().Setup(enemy.transform);
        //Slider UI�� �ڽ��� ü�� ������ ǥ���ϵ��� ����
        sliderClone.GetComponent<EnemyHpViewer>().SetUp(enemy.GetComponent<EnemyHp>());
    }
}
