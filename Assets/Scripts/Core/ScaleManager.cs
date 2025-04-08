using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleManager : MonoBehaviour
{
    public ReputationManager reputationManager;
    public Image current;
    public List<Sprite> anim;
    private void Start()
    {
        current = GetComponent<Image>();
    }
    private void Update()
    {
        CheckScale();
    }
    public void CheckScale()
    {
        int currentRep = reputationManager.currentReputation;
        Debug.Log(currentRep);

        if (currentRep > 0) current.sprite = anim[4]; //bad
        if (currentRep > 20) current.sprite = anim[3]; //mid bad
        if (currentRep > 40) current.sprite = anim[2]; //mid
        if (currentRep > 60) current.sprite = anim[1]; //mid good
        if (currentRep > 80) current.sprite = anim[0]; // good
    }
}
