using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ResetTimeScale();
    }

    public void Load(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
        ResetTimeScale();
    }

    private void ResetTimeScale() => Time.timeScale = 1;
}