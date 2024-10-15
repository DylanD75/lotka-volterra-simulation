using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static float h = 200;
    public static float l = 50;
    public static float h0;
    public static float l0;
    public static float a = 0.05f;
    public static float b = 0.001f;
    public static float c = 0.03f;
    public static float d = 0.0002f;
    public static float interval = 0.25f;
    public static float dt = 1;
    private float t = 1;
    private float h1;
    //public GameObject wolf;
    public GameObject dylan;
    public GameObject chase;
    public GameObject giulio;
    //private GameObject bunny;
    public GameObject gc;
    public Text lText;
    public Text tText;
    public Text hText;

    void Start()
    {
        for (var i = 0; i < l; i++)
        {
            GameObject wolf = ObjectPool.SharedInstance.GetPooledObject();
            if (wolf != null)
            {
                wolf.transform.position = new Vector3(Random.Range(-26f, 26f), 0.5f, Random.Range(-26f, 26f));
                wolf.transform.rotation = Quaternion.identity;
                wolf.SetActive(true);
                wolf.transform.GetChild(0).gameObject.transform.localPosition = new Vector3(0, 0.5f, 0);
            }
        }

        for (var i = 0; i < h; i++)
        {
            GameObject bunny = gc.GetComponent<BunnyObjectPool>().GetHPooledObject();
            if (bunny != null)
            {
                bunny.transform.position = new Vector3(Random.Range(-26f, 26f), 1.17f, Random.Range(-26f, 26f));
                bunny.transform.rotation = Quaternion.identity;
                bunny.SetActive(true);
                bunny.transform.GetChild(0).gameObject.transform.localPosition = new Vector3(0, 0.667f, 0);
            }
        }

        l0 = ObjectPool.SharedInstance.AmountOfPooledObject();
        h0 = gc.GetComponent<BunnyObjectPool>().AmountOfHPooledObject();

        /*for (var i = 0; i < h; i++)
        {
            var random = Random.Range(1, 4);
            //GameObject bunny;
            if(random == 1)
            {
                bunny = dylan;
            } else if(random == 2)
            {
                bunny = chase;
            } else if (random == 3)
            {
                bunny = giulio;
            }
            Instantiate(bunny, new Vector3(Random.Range(-28f, 28f), 0.5f, Random.Range(-28f, 28f)), Quaternion.identity);
        }*/

        StartCoroutine(ChangePopulations());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChangePopulations()
    {
        yield return new WaitForSeconds(interval);
        h1 = h;
        h = h + dt*((a * h) - (b * h * l));
        l = l + dt*((d * h1 * l) - (c * l));
        //Debug.Log("h " + h + " t = " + t);
        //Debug.Log("l " + l + " t = " + t);
        Debug.Log("h = " + h + " h0 = " + h0 + " t = " + (t - 1));
        Debug.Log("l = " + l + " l0 = " + l0 + " t = " + (t - 1));
        t = t + dt;

        if(gc.GetComponent<ObjectPool>().ChangeWolfPopulation() == 1)
        {
            if (ObjectPool.Ldifference > 0)
            {
                for (var i = 0; i < ObjectPool.Ldifference; i++)
                {
                    GameObject wolf = ObjectPool.SharedInstance.GetPooledObject();
                    if (wolf != null)
                    {
                        wolf.transform.position = new Vector3(Random.Range(-28f, 28f), 0.5f, Random.Range(-28f, 28f));
                        wolf.transform.rotation = Quaternion.identity;
                        wolf.SetActive(true);
                        wolf.transform.GetChild(0).gameObject.transform.localPosition = new Vector3(0, 0.5f, 0);
                    }
                    //Debug.Log("added");
                }
            }
            l0 = ObjectPool.SharedInstance.AmountOfPooledObject();
        }

        if (gc.GetComponent<BunnyObjectPool>().ChangeBunnyPopulation() == 1)
        {
            if (BunnyObjectPool.Hdifference > 0)
            {
                for (var i = 0; i < BunnyObjectPool.Hdifference; i++)
                {
                    GameObject bunny = gc.GetComponent<BunnyObjectPool>().GetHPooledObject();
                    if (bunny != null)
                    {
                        bunny.transform.position = new Vector3(Random.Range(-28f, 28f), 0.5f, Random.Range(-28f, 28f));
                        bunny.transform.rotation = Quaternion.identity;
                        bunny.SetActive(true);
                        bunny.transform.GetChild(0).gameObject.transform.localPosition = new Vector3(0, 0.667f, 0);
                    }
                    //Debug.Log("added");
                }
            }
            h0 = gc.GetComponent<BunnyObjectPool>().AmountOfHPooledObject();
        }

        lText.text = "Predators: " + ObjectPool.SharedInstance.AmountOfPooledObject() + " Lynx";
        hText.text = "Prey: " + gc.GetComponent<BunnyObjectPool>().AmountOfHPooledObject() + " Hares";
        tText.text = "Time: " + Mathf.Round((t - 1) * 100) * 0.01f  + " months";

        StartCoroutine(ChangePopulations());
    }

    public void MainMenuScene()
    {
        Debug.Log("switch worked");
        SceneManager.LoadScene("Main Menu");
    }
}
