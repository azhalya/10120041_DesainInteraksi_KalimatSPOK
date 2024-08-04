using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ChangeSceneWithDelay(string sceneName)
    {
        StartCoroutine(SceneDelay(sceneName));
    }

    private IEnumerator SceneDelay(string sceneName)
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
