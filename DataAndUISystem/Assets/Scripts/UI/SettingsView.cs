namespace UI
{
    using Managers;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UIElements;

    public class SettingsView : MonoBehaviour
    {
        #region Variables
        
        private DropdownField _qualityDropdown;
        private Slider _volumeSlider;
        
        [Header("UI Document Reference")]
        [SerializeField] private UIDocument uiDocument;
        
        #endregion
        
        #region Unity Methods

        private void OnEnable()
        {
            VisualElement root = uiDocument.rootVisualElement;
            
            _volumeSlider = root.Q<Slider>("MasterVolumeSlider");
            _qualityDropdown = root.Q<DropdownField>("QualityDropdown");
            
            InitializeUI();
            RegisterCallbacks();
        }
        
        #endregion
        
        #region My Methods

        private void InitializeUI()
        {
            if(!SettingsManager.Instance) return;
            
            if(_volumeSlider != null)
            {
                _volumeSlider.value = SettingsManager.Instance.GetMasterVolume();
            }
            
            if(_qualityDropdown != null)
            {
                _qualityDropdown.choices = new List<string>(QualitySettings.names);

                int currentIndex = SettingsManager.Instance.GetQualityLevel();
                
                if(currentIndex >= 0 && currentIndex < _qualityDropdown.choices.Count) { _qualityDropdown.value = _qualityDropdown.choices[currentIndex]; }
            }
        }

        private void RegisterCallbacks()
        {
            if(_volumeSlider != null) { _volumeSlider.RegisterValueChangedCallback(evt => { SettingsManager.Instance.SetMasterVolume(evt.newValue); }); }
            
            if(_qualityDropdown != null)
            {
                _qualityDropdown.RegisterValueChangedCallback(evt =>
              {
                  int index = _qualityDropdown.choices.IndexOf(evt.newValue);
                  if(index >= 0) { SettingsManager.Instance.SetQualityLevel(index); }
              });
            }
        }
        
        #endregion
    }
}