using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaser : MonoBehaviour
{
    private EnemiesUtil _enemiesUtil;

    private Rigidbody2D _Rb;
    private float time;
    
    [SerializeField]private float speed=2;

    [SerializeField] private float chaseDistance = 5;
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
        if (_enemiesUtil.Chase(_Rb,speed,chaseDistance) == false)
        {
            if (time > 0.2)
            {
                time = 0;
                _enemiesUtil.Wander(_Rb,speed);
            }        
        }
        
    }
}
