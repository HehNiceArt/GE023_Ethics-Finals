using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameClear : MonoBehaviour
{
    [SerializeField] ReputationManager reputationManager;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] TextMeshProUGUI rep;
    [SerializeField] Button quit;
    [SerializeField] Button start;
    private void Start()
    {
        gameOverUI.SetActive(false);
    }
    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    private void Update()
    {
        CalcRep();
    }

    void CalcRep()
    {
        int currentRep = reputationManager.currentReputation;
        if (currentRep > 0) rep.text = $"Reputation: Bad!";
        if (currentRep > 20) rep.text = $"Reputation: Fairly Bad!";
        if (currentRep > 40) rep.text = $"Reputation: Normal!";
        if (currentRep > 60) rep.text = $"Reputation: Fairly Good!";
        if (currentRep > 80) rep.text = $"Reputation: Good!";
    }
    public void QuitGame() => Application.Quit();

    public void StartMenu()
    {
        SceneManager.LoadScene(0);
    }
}
