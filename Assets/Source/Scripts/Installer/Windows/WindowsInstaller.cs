using Source.Scripts.Data;
using Source.Scripts.Data.Windows;
using Source.Scripts.UI;
using Source.Scripts.UI.Animations;
using Source.Scripts.View;
using UnityEngine;
using Zenject;

namespace Source.Scripts.Installer
{
    public class WindowsInstaller : MonoInstaller
    {
        [SerializeField] private KeyValueStorage<WindowType, AWindow> windowsData;
        [SerializeField] private KeyValueStorage<WindowType, AWindow> backWindowsData;
        [SerializeField] private WindowType defaultWindow;
        [SerializeField] private RectTransform parent;
        
        public override void InstallBindings()
        {
            var windowsHandler =
                new WindowsHandler(new RightSwipeWindowsAnimator(0.5f), new LeftSwipeWindowsAnimator(0.5f));
            Container.Bind<IWindowsHandler<WindowType>>().To<WindowsHandler>().FromInstance(windowsHandler);

            windowsHandler.InitBGWindows(backWindowsData, Container, parent);
            windowsHandler.InitWindows(windowsData, Container, parent);
            
            windowsHandler.OpenWindow(defaultWindow);
        }
    }
}