using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource audio;
    public AudioClip[] audioClips;

    private int currentClip;

    private void Start()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        SetGeneralVolume();
    }

    private void LateUpdate()
    {
        if(!audio.isPlaying)
        {
            audio.clip = audioClips[currentClip];
            currentClip = currentClip == audioClips.Length - 1 ? 0 : currentClip++;
            audio.Play();
        }
    }

    public void SetGeneralVolume()
    {
        float newVolume = PlayerPrefs.GetInt("GeneralVolume",100);
        audio.volume = newVolume / 100;
        print("Loaded Volume and set it to: " + newVolume);
    }

}
