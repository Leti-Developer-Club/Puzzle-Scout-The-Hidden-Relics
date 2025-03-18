using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Audio_manager : MonoBehaviour
{
    [Header ("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header ("Audio Clip")]
    public AudioClip background;
    public AudioClip keypress;
    public AudioClip CompleteLevel;
    public AudioClip GameOver;
    public AudioClip BackgroundSFX;

     public static Audio_manager Instance;  // Singleton pattern for global access

    [Header("Audio Mixer")]
    public AudioMixer audioMixer;  // Assign your Audio Mixer in the inspector

    [Header("UI Elements")]
    public Slider volumeSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    private const string MASTER_VOLUME = "MasterVolume";
    private const string MUSIC_VOLUME = "MusicVolume";
    private const string SFX_VOLUME = "SFXVolume";

    private void Awake()
    {
        // Ensure there is only one instance of AudioManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
            // Keep across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();

       SFXSource.clip = BackgroundSFX;
       SFXSource.loop = true;
       SFXSource.Play();

       if (Audio_manager.Instance != null)
        {
            volumeSlider.onValueChanged.AddListener(Audio_manager.Instance.SetMasterVolume);
            musicSlider.onValueChanged.AddListener(Audio_manager.Instance.SetMusicVolume);
            sfxSlider.onValueChanged.AddListener(Audio_manager.Instance.SetSFXVolume);

            // Load saved settings
            Audio_manager.Instance.LoadAudioSettings();
        }

        // Load saved volume settings
        LoadAudioSettings();
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat(MASTER_VOLUME, Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        float dbVolume = (volume > 0) ? Mathf.Log10(volume) * 20 : -80f; // -80dB = mute
        audioMixer.SetFloat(MUSIC_VOLUME, dbVolume);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        float dbVolume = (volume > 0) ? Mathf.Log10(volume) * 20 : -80f;
        audioMixer.SetFloat(SFX_VOLUME, dbVolume);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

     public void LoadAudioSettings()
    {
        // Load master volume
        float volume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        audioMixer.SetFloat(MASTER_VOLUME, Mathf.Log10(volume) * 20);
        if (volumeSlider) volumeSlider.value = volume;

        // Load music volume
        float musicVol = PlayerPrefs.GetFloat("MusicVolume", 1f);
        audioMixer.SetFloat(MUSIC_VOLUME, (musicVol > 0) ? Mathf.Log10(musicVol) * 20 : -80f);
        if (musicSlider) musicSlider.value = musicVol;

        // Load SFX volume
        float sfxVol = PlayerPrefs.GetFloat("SFXVolume", 1f);
        audioMixer.SetFloat(SFX_VOLUME, (sfxVol > 0) ? Mathf.Log10(sfxVol) * 20 : -80f);
        if (sfxSlider) sfxSlider.value = sfxVol;
    }
    
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
    
}
