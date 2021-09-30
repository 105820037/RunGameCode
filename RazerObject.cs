using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RazerObject : pullingobject
{
    
    private Transform _transform;
    private bool up = false;
    private bool left = false;
    private bool time = false;
    

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
        {
            return;
        }
        Activetime += Time.deltaTime;
        if (Activetime > Lifetime)
        {
            if (up)
            {
                _transform.Rotate(0, 0, -90);
                up = false;
            }
            if (left)
            {
                _transform.Rotate(0, 0, -180);
                left = false;
            }
            IsDead = true;
            Activetime = 0;
            gameObject.SetActive(false);
            time = false;
        }
        if (!time)
        {
            _transform.Translate(Vector2.right * 15 * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // TODO:
        // 碰撞事件
        //===========================================================
        if (collision.gameObject.tag == "MirrorUp")
        {

            up = true;
            _transform.Rotate(0, 0, 90);
            _transform.position = new Vector3(_transform.position.x+1, _transform.position.y, _transform.position.z);
            _transform.Translate(Vector2.up * 15 * Time.deltaTime);
        }
        else if (collision.gameObject.tag == "reversetime")
        {
            if (!time)
            {
                _transform.Translate(Vector2.left * 15 * Time.deltaTime);
                _transform.Rotate(0, 0, 180);
                time = true;
                left = true;
                _transform.position = new Vector3(_transform.position.x+1, _transform.position.y, _transform.position.z);
                StartCoroutine(TIMERECODE());
            }
        }
        else
        {
            if (up)
            {
                _transform.Rotate(0, 0, -90);
                up = false;
            }
            if (left)
            {
                _transform.Rotate(0, 0, -180);
                left = false;
            }
            IsDead = true;
            Activetime = 0;
            gameObject.SetActive(false);
            time = false;
        }
        IEnumerator TIMERECODE()
        {
            yield return new WaitForSeconds(1);
            time = false;
        }
        //===========================================================
    }

}
