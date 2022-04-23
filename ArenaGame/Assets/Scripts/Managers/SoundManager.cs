using UnityEngine;

public class SoundManager : MonoBehaviour
{
   // public static AudioClip tapSound;
    static AudioSource audioSource;
    void Start()
    {

      //  tapSound = Resources.Load<AudioClip>("Sounds/tap");
        
        audioSource = GetComponent<AudioSource>();
    }
    public static void PlaySound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    }
}
