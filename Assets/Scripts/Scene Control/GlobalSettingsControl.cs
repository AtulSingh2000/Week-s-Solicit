using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GlobalSettingsControl : MonoBehaviour
{
    [Header("Setting Variables")]
    public bool musicBool = true;
    public bool sfxBool = true;
    public bool portalBool = true;
    public int qualityLevelIndex;
    public float volumeVal;
    public int highScoreCount;
    public int totalCoinCount;
   

    public static GlobalSettingsControl instance;

    [Header("Scene Object Reference")]
    public Slider volumeSlider;
    public static int size;
    public Toggle[] toggleArray = new Toggle[size];//Music, SFX, Portal.
    public Dropdown graphicsVal;
    
    [Header("Global Object Reference")]
    public AudioMixer audioMixer;

    [Header("Reset Data")]
    public bool resetData;

    private float previousVol;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1;//flush all pause states and reset to normal time scale
        IsFirstTime();
        LoadState();
        //Debug.Log("Loaded HS: " + highScoreCount);
        //Debug.Log("loaded tcoins: " + totalCoinCount);
        //Debug.Log("loaded tgems: " + totalGemCount);
        if (musicBool && sfxBool)
        {
            if(GetComponent<AudioSource>())
                GetComponent<AudioSource>().Play();
        }
    }
    private void Update()
    {
        if (resetData)
            ResetData();

        if(graphicsVal)
            graphicsVal.value = qualityLevelIndex;

        if(volumeSlider)
        {
            if (toggleArray[0])
                toggleArray[0].isOn = musicBool;

            if (toggleArray[1])
                toggleArray[1].isOn = sfxBool;

            if (toggleArray[2])
                toggleArray[2].isOn = portalBool;
        }
        if (volumeSlider)
            volumeSlider.value = volumeVal;
    }
    public void cashUpdate()
    {
        if(gameObject.GetComponent<MyInventoryControl>())
        {
            SaveState();
        }
    }
    public void TotalCoinsUpdate()
    {
        if (gameObject.GetComponent<FPSSceneControl>())
        {
            totalCoinCount = gameObject.GetComponent<FPSSceneControl>().totalCoins;
            SaveState();
            //Debug.Log("coins: " + coinCount);
        }
    }
   
    public void HighScoreUpdate()
    {
        if(gameObject.GetComponent<FPSSceneControl>())
        {
            highScoreCount = gameObject.GetComponent<FPSSceneControl>().highScore;
            SaveState();
            //Debug.Log("HS: " + highScoreCount);
        }
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        qualityLevelIndex = qualityIndex;
        SaveState();
    }
    public void SetMusic(bool argVal)
    {
        musicBool = argVal;
        if(musicBool)
        {
            GetComponent<AudioSource>().Play();
        }
        else if(!musicBool)
        {
            GetComponent<AudioSource>().Stop();
        }
        SaveState();
    }
    public void SetSFX(bool argVal)
    {
        sfxBool = argVal;
        if(!sfxBool)
        {
            audioMixer.GetFloat("Volume", out previousVol);
            audioMixer.SetFloat("Volume", -80);
            GetComponent<AudioSource>().Stop();
        }
        else if(sfxBool)
        {
            audioMixer.SetFloat("Volume", previousVol);
            GetComponent<AudioSource>().Play();
        }
        SaveState();
    }
    public void SetPortal(bool argVal)
    {
        portalBool = argVal;
        SaveState();
    }
    public void SetVolume(float argvolume)
    {
        audioMixer.SetFloat("Volume", argvolume);
        volumeVal = argvolume;
        SaveState();
    }
    public void SaveState()
    {
        SaveSystem.SaveState(this);
    }
    public void LoadState()
    {
        StateData data = SaveSystem.LoadState();

        sfxBool = data.sfx;
        musicBool = data.music;
        portalBool = data.portal;
        qualityLevelIndex = data.qualityLevel;
        volumeVal = data.volume;
        highScoreCount = data.highScore;
      
        totalCoinCount = data.totalCoins;
    }
    public void IsFirstTime()
    {
        string path1 = Application.persistentDataPath + "/this.Sett";
        
        if (!File.Exists(path1))
        {
            Debug.Log("First Time Launch");
            SaveState();
        }
        else
            Debug.Log("Not First Time");
    }
    public void ResetData()
    {
        sfxBool = false;
        musicBool = false;
        portalBool = false;
        qualityLevelIndex = 0;
        volumeVal = 0;
        highScoreCount = 0;
      
        totalCoinCount = 0;
        SaveState();
    }

}
