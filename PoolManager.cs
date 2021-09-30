using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour {
    static PoolManager ins;
    Dictionary<string, List<pullingobject>> PoolingObjects;

    static public PoolManager GetInstance () {
        return ins;
    }

    void Awake () {
        ins = this;
        PoolingObjects = new Dictionary<string, List<pullingobject>>();
    }

    pullingobject CreateNewObject (GameObject _go, string _tag) {
        GameObject go = GameObject.Instantiate(_go);
        pullingobject poolingObj = go.GetComponent<pullingobject>();
        if (poolingObj == null) {
            poolingObj = go.AddComponent<pullingobject>();
            poolingObj.Lifetime = 5;
            poolingObj.name = _tag;
        }
        return poolingObj;
    }

    public pullingobject GetObject (GameObject GO) {
        string tag = GO.name.Replace("(Clone)", "");

        if (PoolingObjects.ContainsKey(tag)) {
            pullingobject freeObject = PoolingObjects[tag].Find(e => e.IsDead == true);
            if (freeObject != null) {
                freeObject.gameObject.SetActive(true);
                freeObject.IsDead = false;
                freeObject.Activetime = 0;
                return freeObject;
            }
            else {
                pullingobject poolingObj = CreateNewObject(GO, tag);
                poolingObj.IsDead = false;
                PoolingObjects[tag].Add(poolingObj);
                return poolingObj;
            }
        }
        else {
            List<pullingobject> POs = new List<pullingobject>();
            pullingobject poolingObj = CreateNewObject(GO, tag);
            poolingObj.IsDead = false;
            POs.Add(poolingObj);
            PoolingObjects.Add(tag, POs);
            return poolingObj;
        }
    }

    public void PreLoadObject (GameObject GO, int Amount, bool inactive = true) {
        string tag = GO.name.Replace("(Clone)", "");

        if (PoolingObjects.ContainsKey(tag)) {
            for (int x = 0; x < Amount; ++x) {
                pullingobject poolingObj = CreateNewObject(GO, tag);
                poolingObj.IsDead = true;
                if (inactive)
                    poolingObj.gameObject.SetActive(false);
                else
                    poolingObj.gameObject.transform.localPosition = new Vector3(100, 100, 100);
                PoolingObjects[tag].Add(poolingObj);
            }
        }
        else {
            List<pullingobject> POs = new List<pullingobject>();
            for (int x = 0; x < Amount; ++x) {
                pullingobject poolingObj = CreateNewObject(GO, tag);
                poolingObj.IsDead = true;
                if (inactive)
                    poolingObj.gameObject.SetActive(false);
                else
                    poolingObj.gameObject.transform.localPosition = new Vector3(100, 100, 100);
                POs.Add(poolingObj);
            }
            PoolingObjects.Add(tag, POs);
        }
    }

    public void Purge (bool force) {
        foreach (KeyValuePair<string, List<pullingobject>> list in PoolingObjects) {
            if (list.Value != null && list.Value.Count > 0 && list.Value[0] != null) {
                continue;
            }

            list.Value.RemoveAll(e => e == null);

            List<pullingobject> removeList = new List<pullingobject>();
            foreach (pullingobject po in list.Value) {
                if (force) {
                    removeList.Add(po);
                    Destroy(po.gameObject);
                }
                else {
                    if (po.IsDead) {
                        removeList.Add(po);
                        Destroy(po.gameObject);
                    }
                }
            }

            for (int x = 0; x < removeList.Count; ++x) {
                list.Value.Remove(removeList[x]);
            }
        }
    }

    public int GetAllCount() {
        int count = 0;
        foreach (KeyValuePair<string, List<pullingobject>> list in PoolingObjects) {
            if (list.Value == null) {
                continue;
            }
            foreach (pullingobject po in list.Value) {
                if (po != null) {
                    count++;
                }
            }
        }
        return count;
    }

    public int GetActiveCount() {
        int count = 0;
        foreach (KeyValuePair<string, List<pullingobject>> list in PoolingObjects) {
            if (list.Value == null) {
                continue;
            }
            foreach (pullingobject po in list.Value) {
                if (po != null && po.IsDead == false) {
                    count++;
                }
            }
        }
        return count;
    }

}
