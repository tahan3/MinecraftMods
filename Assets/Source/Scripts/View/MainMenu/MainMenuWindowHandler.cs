using Source.Scripts.Data.Windows;
using UnityEngine;
using Zenject;

namespace Source.Scripts.View.MainMenu
{
    public class MainMenuWindowHandler
    {
        private readonly MainMenuWindow _mainMenuWindow;
        
        private IWindowsHandler<WindowType> _windowsHandler;

        public MainMenuWindowHandler(MainMenuWindow mainMenuWindow)
        {
            _mainMenuWindow = mainMenuWindow;
        }

        [Inject]
        private void Construct(IWindowsHandler<WindowType> windowsHandler, DiContainer container)
        {
            _windowsHandler = windowsHandler;
            
            _mainMenuWindow.modsButton.onClick.AddListener(OpenAllModsWindow);
            _mainMenuWindow.instructionButton.onClick.AddListener(OpenInstructionWindow);
            _mainMenuWindow.policyButton.onClick.AddListener(OpenPolicyWindow);

            container.Inject(_mainMenuWindow.localizationButton);
        }

        private void OpenAllModsWindow()
        {
            _windowsHandler.OpenWindow(WindowType.AllMods);
        }

        private void OpenInstructionWindow()
        {
            _windowsHandler.OpenWindow(WindowType.Instruction);
        }

        private void OpenPolicyWindow()
        {
            _windowsHandler.OpenWindow(WindowType.Policy);
        }
    }
}