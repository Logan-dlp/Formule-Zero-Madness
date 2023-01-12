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
    #region Meths Unity
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    #endregion
}
