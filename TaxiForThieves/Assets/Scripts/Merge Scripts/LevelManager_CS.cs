using Cinemachine;
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

    public Transform cameraStartPosition;
    public CinemachineVirtualCamera cam;

    int playerLife;
    int activeDropOffId;


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
        playerLife = 3;
        GameUI_CS.instance.UpdateLives(playerLife);
    }

    void Update()
    {
        if(Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (Input.GetKey(KeyCode.P))
        {
            PlayerController.instance.ResetPosition();
            cam.ForceCameraPosition(cameraStartPosition.position, Quaternion.Euler(new Vector3(cameraStartPosition.rotation.eulerAngles.x, 0, 0)));
        }
        if (Input.GetKey(KeyCode.O))
        {
            //ResetPlayerLost();
        }
    }

    public void SpawnACrim()
    {
        int rand = Random.Range(0, (spawns.Length - 1));
        Instantiate(crim, spawns[rand]);
    }

    public GameObject GetRandomDropOff()
    {
        activeDropOffId = Random.Range(0, (dropOffPoints.Length - 1));
        return dropOffPoints[activeDropOffId];
    }

    public void ResetPlayerLost()
    {
        playerLife--;
        PlayerController.instance.ResetPosition();
        cam.ForceCameraPosition(cameraStartPosition.position, Quaternion.Euler(new Vector3(cameraStartPosition.rotation.eulerAngles.x, 0, 0)));
        GameUI_CS.instance.ShowErrorMsg();
        GameUI_CS.instance.UpdateLives(playerLife);
        dropOffPoints[activeDropOffId].SendMessage("Deactivate");
        SpawnACrim();
    }

}