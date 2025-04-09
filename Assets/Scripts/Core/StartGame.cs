using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] GameObject setting;
    bool isActive = false;
    public void GameStart()
    {
        SceneManager.LoadScene(1);
    }
    public void Setting()
    {
        isActive = !isActive;
        setting.SetActive(isActive);
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            setting.SetActive(false);
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
