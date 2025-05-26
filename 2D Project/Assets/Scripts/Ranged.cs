using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class Ranged : Enemy
{
    [SerializeField]
    private StageData stageData;
    private Movement2D move;
    private Weapon weapon;

    protected override void Awake()
    {
        base.Awake();
        move = GetComponent<Movement2D>();
        weapon = GetComponent<Weapon>();
    }

    private void Start()
    {
        weapon.StartFiring();
        move.MoveTo(new Vector3(1.8f, -1, 0));
    }

    public void Update()
    {
        if (transform.position.x >= stageData.LimitMax.x - 0.6f)
            move.MoveTo(new Vector3(-1.8f, -1, 0));
        else if(transform.position.x <= stageData.LimitMin.x + 0.6f)
            move.MoveTo(new Vector3(1.8f, -1, 0));
        
    }
}
