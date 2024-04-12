using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    private EnemiesUtil _enemiesUtil;

    private Rigidbody2D _Rb;
    private float time;
    private int nbSpawn = 0;
    private int maxSpawn = 3;
    
    [SerializeField]private float speed=1;
    [SerializeField] private GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        _enemiesUtil = FindFirstObjectByType<EnemiesUtil>();
        _Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time>2)
        {
            _enemiesUtil.Flee(_Rb,speed);
            if (time > 5)
            {
                time = 0;
                nbSpawn++;
                _enemiesUtil.Spawn(enemy,_Rb);
            }
        }

        if (nbSpawn > maxSpawn)
        {
            Destroy(this);
        }
    }
}
