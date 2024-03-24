using TMPro;
using UnityEngine.UI;
using Zenject;

namespace Source.Scripts.View.Mods
{
    public class ConcreteModWindow : InjectWindow
    {
        public Image modDescriptionIcon;
        public TextMeshProUGUI modDescriptionText;
        public Button downLoadModButton;

        private ConcreteModWindowHandler _windowHandler;
        
        public override void Construct(DiContainer container)
        {
            _windowHandler = new ConcreteModWindowHandler(this);
            container.Inject(_windowHandler);
        }

        public override void Open()
        {
            _windowHandler.OnOpen();
            base.Open();
        }
    }
}