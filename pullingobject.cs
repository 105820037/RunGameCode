using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pullingobject : MonoBehaviour {

    public float Lifetime;
    public float Activetime;
    public bool IsDead;

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
    }

}
