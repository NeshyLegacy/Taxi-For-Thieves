using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager_CS : MonoBehaviour
{
    public static LevelManager_CS instance = null;

    public GameObject crim;
    public bool playerhasCrim;

    public GameObject[] dropOffPoints;
    public Transform[] spawns;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }

    void Start()
    {
        SpawnACrim();
    }

    void Update()
    {
        if(Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    public void SpawnACrim()
    {
        int rand = Random.Range(0, (spawns.Length - 1));
        Instantiate(crim, spawns[rand]);
    }

    public GameObject GetRandomDropOff()
    {
        int rand = Random.Range(0, (dropOffPoints.Length - 1));
        return dropOffPoints[rand];
    }
}
