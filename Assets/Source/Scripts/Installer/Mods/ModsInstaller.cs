using System.Collections.Generic;
using Source.Scripts.Data.Mods;
using Source.Scripts.Handler.Mods;
using UnityEngine;
using Zenject;

namespace Source.Scripts.Installer.Mods
{
    public class ModsInstaller : MonoInstaller
    {
        [SerializeField] private List<ModConfig> allMods;
        
        public override void InstallBindings()
        {
            Container.Bind<ModsHandler>().FromNew().AsSingle().WithArguments(allMods);
        }
    }
}