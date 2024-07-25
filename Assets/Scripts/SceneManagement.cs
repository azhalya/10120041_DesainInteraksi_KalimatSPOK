using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        // Test
        SceneManager.LoadScene(sceneName);
    }
}
