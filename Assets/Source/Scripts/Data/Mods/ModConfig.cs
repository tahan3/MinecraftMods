using AYellowpaper.SerializedCollections;
using Source.Scripts.Localization;
using UnityEngine;

namespace Source.Scripts.Data.Mods
{
    [CreateAssetMenu(fileName = "ModConfig", menuName = "ModConfig", order = 0)]
    public class ModConfig : ScriptableObject
    {
        [Header("Sprites")]
        public Sprite modIcon;
        public Sprite modDescriptionIcon;

        [Header("Info")] 
        public SerializedDictionary<Language, ModeInfo> modInfo;

        //Other info/configs etc...
    }
}