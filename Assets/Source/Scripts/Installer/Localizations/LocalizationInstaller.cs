using Source.Scripts.Handler.Localization;
using Zenject;

namespace Source.Scripts.Installer.Localizations
{
    public class LocalizationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<LocalizationHandler>().FromNew().AsSingle();
        }
    }
}