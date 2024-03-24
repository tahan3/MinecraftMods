using Source.Scripts.Data.Windows;
using Source.Scripts.Handler.Localization;
using Source.Scripts.Handler.Mods;
using Zenject;

namespace Source.Scripts.View.Mods
{
    public class ConcreteModWindowHandler
    {
        private ConcreteModWindow _window;

        private ModsHandler _modsHandler;
        
        public ConcreteModWindowHandler(ConcreteModWindow window)
        {
            _window = window;
        }

        [Inject]
        public void Construct(ModsHandler modsHandler, IWindowsHandler<WindowType> windowsHandler)
        {
            _modsHandler = modsHandler;

            _window.downLoadModButton.onClick.AddListener(() => windowsHandler.OpenWindow(WindowType.DownloadMod));
        }

        public void OnOpen()
        {
            _window.modDescriptionText.text = _modsHandler.CurrentMod.modInfo[LocalizationHandler.CurrentLanguage].modDescription;
            _window.modDescriptionIcon.sprite = _modsHandler.CurrentMod.modDescriptionIcon;
        }
    }
}