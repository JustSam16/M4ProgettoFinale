using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    public int poolSize = 10;
    private Queue<GameObject> poolQueue = new Queue<GameObject>();

    void Awake()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            poolQueue.Enqueue(obj);
        }
    }

    public GameObject GetObject()
    {
        if (poolQueue.Count > 0)
        {
            GameObject obj = poolQueue.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            GameObject obj = Instantiate(prefab);
            return obj;
        }
    }

   
    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        poolQueue.Enqueue(obj);
    }
}
