using UnityEngine;
using Zenject;

namespace Source.Scripts.View.Mods
{
    public class AllModsWindow : InjectWindow
    {
        public Transform modsContainer;
        public ModUIItem modItemPrefab;
        
        public override void Construct(DiContainer container)
        {
            var windowHandler = new AllModsWindowHandler(this);
            container.Inject(windowHandler);
        }
    }
}