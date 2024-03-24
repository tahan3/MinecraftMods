using System;
using Source.Scripts.Data.Windows;
using Source.Scripts.Handler.Localization;
using Source.Scripts.Handler.Mods;
using Source.Scripts.Localization;
using Zenject;

namespace Source.Scripts.View.BG
{
    public class BGWindowHandler : IDisposable
    {
        private readonly BGWindow _window;

        private IWindowsHandler<WindowType> _windowsHandler;
        private ModsHandler _modsHandler;
        
        public BGWindowHandler(BGWindow window)
        {
            _window = window;
        }
        
        [Inject]
        public void Construct(IWindowsHandler<WindowType> windowsHandler, ModsHandler modsHandler)
        {
            _modsHandler = modsHandler;
            _windowsHandler = windowsHandler;
            _windowsHandler.OnWindowChanged += ChangeHeaderText;

            _window.backButton.onClick.AddListener(_windowsHandler.OpenPreviousWindow);
        }

        private void ChangeHeaderText(WindowType windowType)
        {
            _window.headerText.text = TranslateWindowType(windowType);
        }

        private string TranslateWindowType(WindowType windowType)
        {
            switch (windowType)
            {
                case WindowType.AllMods:
                    return LocalizationHandler.CurrentLanguage == Language.Ru ? "Моды" : "Mods";
                case WindowType.Policy:
                    return LocalizationHandler.CurrentLanguage == Language.Ru ? "Политика" : "Policy";
                case WindowType.ConcreteMod:
                case WindowType.DownloadMod:
                    return _modsHandler.CurrentMod.modInfo[LocalizationHandler.CurrentLanguage].modName;
                default:
                    return "Header";
            }
        }

        public void Dispose()
        {
            _windowsHandler.OnWindowChanged -= ChangeHeaderText;
        }
    }
}