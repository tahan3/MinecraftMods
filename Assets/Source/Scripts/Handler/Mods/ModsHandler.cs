using System.Collections.Generic;
using Source.Scripts.Data.Mods;

namespace Source.Scripts.Handler.Mods
{
    public class ModsHandler
    {
        public List<ModConfig> AllMods { get; private set; }
        public ModConfig CurrentMod { get; private set; }
        
        public ModsHandler(List<ModConfig> allMods)
        {
            AllMods = allMods;
        }

        public void SelectMod(ModConfig mod)
        {
            CurrentMod = mod;
        }
    }
}