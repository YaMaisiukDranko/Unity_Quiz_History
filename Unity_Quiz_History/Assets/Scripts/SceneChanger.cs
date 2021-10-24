using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void GameSceneChange()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitToLobbyScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
