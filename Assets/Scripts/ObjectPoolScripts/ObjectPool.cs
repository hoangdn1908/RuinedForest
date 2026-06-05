using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefabs;
    [SerializeField] private int poolSize = 5;
    private Queue<GameObject> pool = new Queue<GameObject>();
    private HashSet<GameObject> pooledObjects = new HashSet<GameObject>();

    private void Awake()
    {
        CreatePool();
    }

    private void CreatePool() 
    {
        for (int i = 0; i < poolSize; i++) 
        {
            CreateObject(); 
        }
    }

    private void CreateObject() 
    {
        GameObject obj = Instantiate(prefabs, transform);
        obj.SetActive(false);
        pool.Enqueue(obj);
        pooledObjects.Add(obj);
    }

    public GameObject GetFromPool() 
    {
        if (pool.Count == 0) 
        {
            CreateObject();
        }
        GameObject obj = pool.Dequeue();
        pooledObjects.Remove(obj);
        obj.transform.SetParent(null, true);
        obj.SetActive(true);
        return obj;
    }

    public void ReturnToPool(GameObject obj) 
    {
        if (obj == null) return;
        if (pooledObjects.Contains(obj)) return;
        obj.transform.SetParent(transform, true);
        obj.SetActive(false);
        pool.Enqueue(obj);
        pooledObjects.Add(obj);
    }
}
