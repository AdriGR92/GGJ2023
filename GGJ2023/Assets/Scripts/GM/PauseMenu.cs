using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace firstpart
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] GameObject pauseMenu;

        void Update()
        {
            if (VirtualInputManager.Instance.PauseActive == true)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
            if (VirtualInputManager.Instance.PauseActive == false)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }

}

