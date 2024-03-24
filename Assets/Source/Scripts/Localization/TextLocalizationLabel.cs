using AYellowpaper.SerializedCollections;
using Source.Scripts.Handler.Localization;
using TMPro;
using UnityEngine;

namespace Source.Scripts.Localization
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TextLocalizationLabel : LocalizationLabel
    {
        [SerializeField] private SerializedDictionary<Language, string> textByLanguage;
        
        private TextMeshProUGUI _textLabel;
        
        private void Start()
        {
            _textLabel = GetComponent<TextMeshProUGUI>();
            SetNewLanguage(LocalizationHandler.CurrentLanguage);
        }
        
        public override void SetNewLanguage(Language language)
        {
            _textLabel.text = textByLanguage[language];
        }
    }
}