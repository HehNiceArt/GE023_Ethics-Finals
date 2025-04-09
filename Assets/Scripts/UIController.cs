using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject gearIcon;
    bool isActive = false;

    public void GearButton()
    {
        isActive = !isActive;

        gearIcon.SetActive(isActive);
    }
}
