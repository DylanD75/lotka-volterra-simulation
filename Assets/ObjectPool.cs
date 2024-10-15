using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    public static int Ldifference;

    public int amount;

    void Awake()
    {
        SharedInstance = this;

        amountToPool = Mathf.RoundToInt(400);

        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    public GameObject GetActive()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    public int AmountOfPooledObject()
    {
        amount = 0;

        for (int i = 0; i < amountToPool; i++)
        {
            if (pooledObjects[i].activeInHierarchy)
            {
                amount++;
            }
        }
        return amount;
    }

    public int ChangeWolfPopulation()
    {
        if (GameController.l0 > GameController.l)
        {
            Ldifference = Mathf.RoundToInt(GameController.l0 - GameController.l);

            if (Ldifference > 0)
            {
                for (var i = 0; i < Ldifference; i++)
                {
                    GetActive().SetActive(false);
                    //Debug.Log("removed");
                }
            }
            GameController.l0 = AmountOfPooledObject();

        } else if (GameController.l0 < GameController.l)
        {
            Ldifference = Mathf.RoundToInt(GameController.l - GameController.l0);

            return 1;
            
        }

        return -1;
    }
}
