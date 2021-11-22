using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerHitSound, sawBladeSound, doorSound, footstepsSound, menuClickSound;
    private static AudioSource _audioSource;

    void Start()
    {
        
        playerHitSound = Resources.Load<AudioClip>("death");
        sawBladeSound = Resources.Load<AudioClip>("sword-unsheathe");
        doorSound = Resources.Load<AudioClip>("door");
        footstepsSound = Resources.Load<AudioClip>("steps_stone");
        menuClickSound = Resources.Load<AudioClip>("click");

        _audioSource = GetComponent<AudioSource>();
        
    }
    
    public static void PlaySound(string sound)
    {
        switch (sound)
        {
            case "playerHit":
                _audioSource.PlayOneShot(playerHitSound);
                break;
            case "sawBlade":
                _audioSource.volume = 0.06f;
                _audioSource.PlayOneShot(sawBladeSound);
                break;
            case "door":
                _audioSource.PlayOneShot(doorSound);
                break;
            case "footsteps":
                _audioSource.PlayOneShot(footstepsSound);
                break;
            case "menuClick":
                _audioSource.volume = 1.0f;
                _audioSource.PlayOneShot(menuClickSound);
                break;
        }
    }
     
}