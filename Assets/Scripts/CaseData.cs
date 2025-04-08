
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class CaseData
{
    public string caseDescription;
    public Sprite characterSprite;
    public Sprite evidence1, evidence2;
    public List<PunishmentOption> options;
}