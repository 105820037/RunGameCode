using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RazerOblect2 : pullingobject
{

    private Transform _transform;
    void Awake()
    {
        _transform = transform;
    }

    void Start()
    {

    }
    void OnEnable()
    {
        // TODO:
        // 重置物件資訊
        //===========================================================

        //===========================================================

    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead)
            return;

        Activetime += Time.deltaTime;
        if (Activetime > Lifetime)
        {
            IsDead = true;
            Activetime = 0;
            gameObject.SetActive(false);
        }
        _transform.Translate(-_transform.right * 15 * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // TODO:
        // 碰撞事件
        //===========================================================
        IsDead = true;
        Activetime = 0;
        gameObject.SetActive(false);
        //===========================================================
    }

}

