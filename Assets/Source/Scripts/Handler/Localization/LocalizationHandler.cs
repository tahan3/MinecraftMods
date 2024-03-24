using System;
using Source.Scripts.Localization;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Source.Scripts.Handler.Localization
{
    public class LocalizationHandler
    {
        public static Language CurrentLanguage { get; private set; }

        private const string LocalizationKey = "Language";

        public event Action<Language> OnLocalizationChanged;
        
        public LocalizationHandler()
        {
            CurrentLanguage = (Language)PlayerPrefs.GetInt(LocalizationKey);
        }

        public void SetNewLanguage(Language language)
        {
            foreach (var localizationLabel in Object.FindObjectsOfType<LocalizationLabel>())
            {
                localizationLabel.SetNewLanguage(language);
            }

            OnLocalizationChanged?.Invoke(language);
            
            CurrentLanguage = language;
            Save();
        }

        private void Save()
        {
            PlayerPrefs.SetInt(LocalizationKey, (int)CurrentLanguage);
        }
    }
}