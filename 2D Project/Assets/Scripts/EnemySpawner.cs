using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private StageData stageData; //적 생성을 위한 스테이지 크기 정보
    [SerializeField]
    private GameObject[] enemyPrefab; //  복제해서 생성할 적 캐릭터 프리펩
    [SerializeField]
    private GameObject enemyHpSliderPrefab; //적 체력을 나타내는 Slider UI프리펩
    [SerializeField]
    private Transform canvasTransform; //UI를 표현하는 Canvas 오브젝트의 Transform
    [SerializeField]
    private float spawnTime; // 생성 주기
    [SerializeField]
    private float rangedProbality; //원거리 적 생성확률
    private int id = 0;  //적 프리펩 아이디 설정

    private void Awake()
    {
        StartCoroutine("SpawnEnemy");
      
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            //x 위치는 스테이지의 크기 범위 내에서 임의의 값을 선택
            float positionX = Random.Range(stageData.LimitMin.x + 0.5f, stageData.LimitMax.x - 0.5f);
            //적 생성 위치
            Vector3 position = new Vector3(positionX, stageData.LimitMax.y, 0.0f);
            //프리펩 아이디 0으로 초기화
            id = 0; 
            //20% 확률로 프리펩 아이디를 바꾸어 다른 적 생성
            if (Random.value >= 1-rangedProbality)
                id = 1;
            //적 캐릭터 생성
            GameObject enemyClone = Instantiate(enemyPrefab[id], position, Quaternion.identity);
            //적 체력을 나타내는 Slider UI 생성 및 설정
            SpawnEnemyHpSlider(enemyClone);
            //spawnTime만큼 대기
            yield return new WaitForSeconds(spawnTime);
        }
    }

    private void SpawnEnemyHpSlider(GameObject enemy)
    {
        //적 체력을 나타내는 Slider UI생성
        GameObject sliderClone = Instantiate(enemyHpSliderPrefab);
        //Slider.UI 오브젝트를 parent의 자식으로 설정
        sliderClone.transform.SetParent(canvasTransform);
        //계층 설정으로 바뀐 크기를 다시(1,1,1)로 설정
        sliderClone.transform.localScale = Vector3.one;
        //Slider UI가 쫓아다닐 대상을 생성된 적으로 설정
       sliderClone.GetComponent<SliderPositionAutoSetter>().Setup(enemy.transform);
        //Slider UI에 자신의 체력 정보를 표시하도록 설정
        sliderClone.GetComponent<EnemyHpViewer>().SetUp(enemy.GetComponent<EnemyHp>());
    }
}
