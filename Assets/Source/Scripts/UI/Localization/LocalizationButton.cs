using AYellowpaper.SerializedCollections;
using DG.Tweening;
using Source.Scripts.Handler.Localization;
using Source.Scripts.Localization;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Source.Scripts.UI.Localization
{
    public class LocalizationButton : MonoBehaviour
    {
        [Header("Buttons")]
        public Button mainButton;
        public SerializedDictionary<Language, Button> langButtons;

        [Header("Icons")]
        public Image mainButtonIcon;
        
        [Header("Sprites")]
        public SerializedDictionary<Language, Sprite> langSprites;

        [Header("Containers")] 
        public RectTransform buttonsContainer;

        [Header("Buttons Movement Duration")]
        public float buttonsMovementDuration = 0.5f;
        
        private bool _isOpen;
        private float _cachedRectPosX;

        private LocalizationHandler _localizationHandler;
        
        [Inject]
        public void Construct(LocalizationHandler localizationHandler)
        {
            _localizationHandler = localizationHandler;
            
            mainButton.onClick.AddListener(OnMainButtonClick);
            _cachedRectPosX = buttonsContainer.anchoredPosition.x;
            
            foreach (var item in langButtons)
            {
                item.Value.onClick.AddListener(() => SelectLanguage(item.Key));
            }
        }

        private void Start()
        {
            mainButtonIcon.sprite = langSprites[LocalizationHandler.CurrentLanguage];
        }

        private void SelectLanguage(Language language)
        {
            mainButtonIcon.sprite = langSprites[language];

            _localizationHandler.SetNewLanguage(language);
            
            OnMainButtonClick();
        }

        private void OnMainButtonClick()
        {
            _isOpen = !_isOpen;

            if (_isOpen)
            {
                buttonsContainer.DOAnchorPosX(0f, buttonsMovementDuration);
            }
            else
            {
                buttonsContainer.DOAnchorPosX(_cachedRectPosX, buttonsMovementDuration);
            }
        }
    }
}