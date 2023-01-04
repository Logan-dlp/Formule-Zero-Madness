using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    #region Meths
    public void LoadScene(string _nameScene)
    {
        SceneManager.LoadScene(_nameScene);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    #endregion
}
