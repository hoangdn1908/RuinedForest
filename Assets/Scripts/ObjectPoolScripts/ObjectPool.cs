using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefabs;
    [SerializeField] private int poolSize = 5;
    private Queue<GameObject> pool = new Queue<GameObject>();

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
    }

    public GameObject GetFromPool() 
    {
        if (pool.Count == 0) 
        {
            CreateObject();
        }
        GameObject obj = pool.Dequeue();
        obj.SetActive (true);
        return obj;
    }

    public void ReturnToPool(GameObject obj) 
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}
