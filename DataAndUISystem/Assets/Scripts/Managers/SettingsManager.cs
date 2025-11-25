namespace Managers
{
    using UnityEngine;
    using UnityEngine.Audio;
    
    public class SettingsManager : MonoBehaviour
    {
        #region Variables
        
        private const string MasterVolumeKey = "MasterVolume";
        private const string QualityLevelKey = "QualityLevel";

        [Header("Audio")]
        [SerializeField] private AudioMixer audioMixer;
        
        public static SettingsManager Instance{get; private set;}
        
        #endregion
        
        #region Unity Methods

        private void Awake()
        {
            if(Instance && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            LoadSettings();
        }
        
        #endregion
        
        #region My Methods
        
        public float GetMasterVolume() => PlayerPrefs.GetFloat(MasterVolumeKey , 0f);
        public int GetQualityLevel() => PlayerPrefs.GetInt(QualityLevelKey , 0);

        private void LoadSettings()
        {
            int defaultQuality = QualitySettings.names.Length > 2 ? 2 : 0;
            int quality = PlayerPrefs.GetInt(QualityLevelKey , defaultQuality);
            float volume = PlayerPrefs.GetFloat(MasterVolumeKey , 0f);
            
            SetQualityLevel(quality);
            SetMasterVolume(volume);
        }

        public void SetMasterVolume(float volume)
        {
            if(audioMixer) { audioMixer.SetFloat(MasterVolumeKey , volume); }

            PlayerPrefs.SetFloat(MasterVolumeKey , volume);
            PlayerPrefs.Save();
        }

        public void SetQualityLevel(int index)
        {
            QualitySettings.SetQualityLevel(index);
            PlayerPrefs.SetInt(QualityLevelKey , index);
            PlayerPrefs.Save();
        }
        
        #endregion
    }
}