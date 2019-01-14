using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public PauseAndResume pauseReset;
    public void changeTheScene(int changeTheScene)
    {
        pauseReset.paused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(changeTheScene);
    }

}
