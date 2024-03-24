using System.Collections.Generic;
using Source.Scripts.Data.Windows;
using Source.Scripts.Handler.Localization;
using Source.Scripts.Handler.Mods;
using Source.Scripts.Localization;
using UnityEngine;
using Zenject;

namespace Source.Scripts.View.Mods
{
    public class AllModsWindowHandler
    {
        private readonly AllModsWindow _allModsWindow;

        private List<ModUIItem> _items;
        private ModsHandler _modsHandler;
        
        public AllModsWindowHandler(AllModsWindow allModsWindow)
        {
            _items = new List<ModUIItem>();
            _allModsWindow = allModsWindow;
        }

        [Inject]
        public void Construct(ModsHandler modsHandler, IWindowsHandler<WindowType> windowsHandler, LocalizationHandler localizationHandler)
        {
            _modsHandler = modsHandler;
            
            for (var i = 0; i < modsHandler.AllMods.Count; i++)
            {
                ModUIItem modItem = Object.Instantiate(_allModsWindow.modItemPrefab, _allModsWindow.modsContainer);
                
                modItem.modIcon.sprite = modsHandler.AllMods[i].modIcon;
                modItem.modName.text = modsHandler.AllMods[i].modInfo[LocalizationHandler.CurrentLanguage].modName;

                var i1 = i;
                
                modItem.modSelectButton.onClick.AddListener(() =>
                {
                    modsHandler.SelectMod(modsHandler.AllMods[i1]);
                    windowsHandler.OpenWindow(WindowType.ConcreteMod);
                });

                _items.Add(modItem);
            }

            localizationHandler.OnLocalizationChanged += OnChangeLanguage;
        }

        private void OnChangeLanguage(Language language)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                _items[i].modName.text = _modsHandler.AllMods[i].modInfo[language].modName;
            }
        }
    }
}