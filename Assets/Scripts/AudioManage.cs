using UnityEngine;

public class AudioManage : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        audioSource.Play();
    }
}
