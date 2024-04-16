using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectLogic : MonoBehaviour
{
    public void SetScene(int Scene)
    {
        SceneManager.LoadScene(Scene);
    }
}
