using Source.Scripts.Data.Windows;
using Source.Scripts.UI.Localization;
using UnityEngine.UI;
using Zenject;

namespace Source.Scripts.View.MainMenu
{
    public class MainMenuWindow : InjectWindow
    {
        public Button modsButton;
        public Button instructionButton;
        public Button policyButton;
        public LocalizationButton localizationButton;
        
        public override void Construct(DiContainer container)
        {
            var handler = new MainMenuWindowHandler(this);
            container.Inject(handler);
        }
    }
}