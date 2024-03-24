using TMPro;
using UnityEngine.UI;
using Zenject;

namespace Source.Scripts.View.BG
{
    public class BGWindow : InjectWindow
    {
        public Button backButton;
        public TextMeshProUGUI headerText;
        
        public override void Construct(DiContainer container)
        {
            var handler = new BGWindowHandler(this);
            container.Inject(handler);
        }
    }
}