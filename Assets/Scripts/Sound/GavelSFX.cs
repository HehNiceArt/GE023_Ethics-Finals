using UnityEngine;

public class GavelSFX : MonoBehaviour
{
    public void PlayGavelSFX()
    {
        AudioManage.Instance.PlaySFX("Gavel");
    }
}
