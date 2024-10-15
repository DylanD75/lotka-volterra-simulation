using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    public static int Hdifference;

    public int amount;

    void Awake()
    {
        //SharedInstance = this;

        amountToPool = Mathf.RoundToInt(800);

        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public GameObject GetHPooledObject()
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

    public GameObject GetHActive()
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

    public int AmountOfHPooledObject()
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

    public int ChangeBunnyPopulation()
    {
        if (GameController.h0 > GameController.h)
        {
            Hdifference = Mathf.RoundToInt(GameController.h0 - GameController.h);
            //Debug.Log(Hdifference);

            if (Hdifference > 0)
            {
                for (var i = 0; i < Hdifference; i++)
                {
                    //removeBunnies();

                        GetHActive().SetActive(false);
                }
                //hCounter = 0;
                //Debug.Log(hCounter);
                /*for (var i = 0; i < AmountOfHPooledObject(); i++)
                {
                    if (pooledObjects[i].activeInHierarchy && hCounter <= Hdifference)
                    {
                        pooledObjects[i].SetActive(false);
                        hCounter++;
                        Debug.Log("worked");
                    }
                }*/

            }
            GameController.h0 = AmountOfHPooledObject();

        }
        else if (GameController.h0 < GameController.h)
        {
            Hdifference = Mathf.RoundToInt(GameController.h - GameController.h0);

            return 1;

        }

        return -1;
    }


    /*void removeBunnies()
    {
        hCounter = 0;
        hCounter = Random.Range(0, Mathf.FloorToInt(GameController.h));
        Debug.Log(hCounter);
        if (pooledObjects[hCounter].activeInHierarchy)
        {
            pooledObjects[hCounter].SetActive(false);
        } else
        {
            removeBunnies();
        }
    }*/

    private int hCounter;

    /*public int ChangeBunnyPopulation()
    {
        if (GameController.h0 > GameController.h)
        {
            Hdifference = Mathf.RoundToInt(GameController.h0 - GameController.h);

            if (Hdifference > 0)
            {
                for (var i = 0; i < Hdifference; i++)
                {
                    pooledObjects[Random.Range(0, Mathf.RoundToInt(GameController.h0))].SetActive(false);
                }
                Debug.Log("removed");
            }
            GameController.h0 = AmountOfHPooledObject();

        }
        else if (GameController.h0 < GameController.h)
        {
            Hdifference = Mathf.RoundToInt(GameController.h - GameController.h0);

            return 1;

        }

        return -1;
    }*/
}
