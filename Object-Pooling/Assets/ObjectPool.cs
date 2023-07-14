using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
	public static ObjectPool Instance { get; private set; }

    [SerializeField] GameObject objectToPool;
    [SerializeField] int amountToPool = 20;

    List<GameObject> pooledGameObjectsList = new List<GameObject>();

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;                                                                                                                                                            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject instantiatedGameObject = Instantiate(objectToPool);
            instantiatedGameObject.SetActive(false);
            pooledGameObjectsList.Add(instantiatedGameObject);
        }
    }

    public GameObject GetPooledGamedObject()
    {
        for (int i = 0; i < pooledGameObjectsList.Count; i++)
        {
            if (!pooledGameObjectsList[i].activeInHierarchy)
            {
                return pooledGameObjectsList[i];
            }
        }

        return null;
    }
}
