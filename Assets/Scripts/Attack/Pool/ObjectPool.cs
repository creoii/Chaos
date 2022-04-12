using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    public List<GameObject> pool;
    public int startCount;

    void Start()
    {
        pool = new List<GameObject>();
        for (int i = 0; i < startCount; i++)
        {
            GameObject p = Instantiate(prefab);
            p.SetActive(false);
            pool.Add(p);
        }
    }

    public GameObject GetObject()
    {
        for (int i = 0; i < pool.Count; ++i)
        {
            if (!pool[i].activeInHierarchy)
            {
                return pool[i];
            }
        }

        GameObject p = Instantiate(prefab);
        p.SetActive(true);
        pool.Add(p);
        return p;
    }
}
