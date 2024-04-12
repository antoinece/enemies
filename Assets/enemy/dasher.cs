using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dasher : MonoBehaviour
{
    private EnemiesUtil _enemiesUtil;
    private Rigidbody2D _Rb;
    
    [SerializeField]private float speed=2;
    [SerializeField] private float shootDistance = 2;

    private bool rush = false;

    private float time;
    private float timeR;
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
        timeR += Time.deltaTime;
        if (time > 2)
        {
            if (_enemiesUtil.StayAtDistance(_Rb, speed, shootDistance))
            {
                if (timeR>1)
                {
                    timeR = 0;
                    if (Random.Range(1, 3) == 2)
                    {
                        time = 0;
                        _enemiesUtil.Rush(_Rb, speed);
                    }
                }
            }
        }
    }
}