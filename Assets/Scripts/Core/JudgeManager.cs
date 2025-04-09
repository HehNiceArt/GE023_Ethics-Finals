using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JudgeManager : MonoBehaviour
{
    public ReputationManager reputationManager;
    public float dialogueSeconds = 10f;
    public List<CaseData> caseOptions;
    public TextMeshProUGUI descriptionText; // Link this to a UI Text for case description
    public List<Button> optionButtons; // Link your option buttons here
    public List<TextMeshProUGUI> optionTexts; // Link their labels
    public TextMeshProUGUI caseTitle;
    public GameObject CaseDialogue;
    public GameObject choices;

    [Header("Sprites")]
    public Image character;
    public Image evidence1, evidence2;
    public GameObject gavel;
    public float gavelSec;

    GameClear gameClear;

    int currentCaseIndex = 0;

    void Start()
    {
        gavel.SetActive(false);
        LoadCase(currentCaseIndex);
        StartCoroutine(DescriptionDialogue());
        gameClear = GetComponent<GameClear>();
    }
    void LoadCase(int index)
    {
        if (index < 0 || index >= caseOptions.Count) return;

        caseTitle.text = $"Case {index + 1}";
        CaseData currentCase = caseOptions[index];
        descriptionText.text = currentCase.caseDescription;
        character.sprite = currentCase.characterSprite;
        evidence1.sprite = currentCase.evidence1;

        if (currentCase.evidence2 == null) evidence2.gameObject.SetActive(false);
        else
        {
            evidence2.gameObject.SetActive(true);
            evidence2.sprite = currentCase.evidence2;
        }


        for (int i = 0; i < optionButtons.Count; i++)
        {
            if (i < currentCase.options.Count)
            {
                int optionIndex = i; // Capture for lambda
                optionButtons[i].gameObject.SetActive(true);
                optionTexts[i].text = currentCase.options[i].description;
                optionButtons[i].onClick.RemoveAllListeners();
                optionButtons[i].onClick.AddListener(() => ChooseOption(optionIndex));
            }
            else
            {
                optionButtons[i].gameObject.SetActive(false);
            }
        }

    }
    private void Update()
    {
        HideDialogue();
    }
    void HideDialogue()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopCoroutine(DescriptionDialogue());
            CaseDialogue.SetActive(false);
        }
    }
    IEnumerator DescriptionDialogue()
    {
        CaseDialogue.SetActive(true);
        yield return new WaitForSeconds(dialogueSeconds);
        CaseDialogue.SetActive(false);
    }
    public void ChooseOption(int index)
    {
        if (index < 0 || index >= caseOptions.Count) return;

        AudioManage.Instance.PlaySFX("Affirm");
        CaseData currentCase = caseOptions[currentCaseIndex];
        int change = currentCase.options[index].reputationWeight;
        reputationManager.currentReputation += change;

        Debug.Log($"Reputation changed by {change}, new: {reputationManager.currentReputation}");
        choices.SetActive(false);

        StartCoroutine(GavelAnim());

    }

    IEnumerator GavelAnim()
    {
        gavel.SetActive(true);
        yield return new WaitForSeconds(gavelSec);
        gavel.SetActive(false);
        NextCase();
    }

    public void NextCase()
    {
        currentCaseIndex++;
        if (currentCaseIndex < caseOptions.Count)
        {
            StopCoroutine(GavelAnim());
            StopCoroutine(DescriptionDialogue());
            StartCoroutine(DescriptionDialogue());
            LoadCase(currentCaseIndex);
        }
        else
        {
            gameClear.GameOver();
        }
    }
}