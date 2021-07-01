using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField]
    Scene game;

    public void startGame()
    {
        SceneManager.LoadScene("SurvivalGame");
    }
}
