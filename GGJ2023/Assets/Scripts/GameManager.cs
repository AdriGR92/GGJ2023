using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("Platforms")]
    public Transform pA;
    public Transform pD;
    [SerializeField] private List<GameObject> platformsAppears = new List<GameObject>();
    [SerializeField] private List<GameObject> platformsDisappears = new List<GameObject>();
    [SerializeField] private int numPlatformsAppears;
    [SerializeField] private int numPlarformsDisappears;
    public bool isActivePlatforms = false;

    [Header("Pause Panel")]
    public bool isPause;
    public GameObject pausePanel;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        pA = GameObject.Find("PlatformsAppears").transform;
        pD = GameObject.Find("PlatformsDisappears").transform;
        numPlatformsAppears = pA.childCount;
        numPlarformsDisappears = pD.transform.childCount;
        foreach(Transform platform in pA)
        {
            platformsAppears.Add(platform.gameObject);
        }

        foreach (Transform platform in pD)
        {
            platformsDisappears.Add(platform.gameObject);
            platform.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Pause(!isPause);
        }
    }

    public void ManagePlatforms(bool isActive)
    {
        isActivePlatforms = isActive;
        if (isActive)
        {
            foreach(GameObject platform in platformsAppears)
            {
                platform.SetActive(false);
            }

            foreach(GameObject platform in platformsDisappears)
            {
                platform.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject platform in platformsAppears)
            {
                platform.SetActive(true);
            }

            foreach (GameObject platform in platformsDisappears)
            {
                platform.SetActive(false);
            }
        }
    }

    private void Pause(bool pause)
    {
        if (pause)
        {
            isPause = true;
            pausePanel.SetActive(true);
        }
        else
        {
            isPause = false;
            pausePanel.SetActive(false);
        }
    }
}
