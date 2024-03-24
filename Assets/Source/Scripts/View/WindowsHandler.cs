using System;
using System.Collections.Generic;
using Source.Scripts.Data;
using Source.Scripts.Data.Windows;
using Source.Scripts.UI;
using Source.Scripts.UI.Animations;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Source.Scripts.View
{
    public class WindowsHandler : IWindowsHandler<WindowType>
    {
        private Dictionary<WindowType, AWindow> _windows = new();
        private Stack<WindowType> _prevWindowsKeys = new();

        private WindowType _currentWindowType;

        private readonly IWindowsAnimator _nextAnimator;
        private readonly IWindowsAnimator _backAnimator;

        public WindowsHandler(IWindowsAnimator nextAnimator, IWindowsAnimator backAnimator)
        {
            _nextAnimator = nextAnimator;
            _backAnimator = backAnimator;
        }

        public event Action<WindowType> OnWindowChanged;

        public void InitWindows(KeyValueStorage<WindowType, AWindow> data, DiContainer container, Transform parent = null)
        {
            foreach (var keyValuePair in data._items)
            {
                AWindow window = Object.Instantiate(keyValuePair.Value, parent);
                window.Close();
                _windows.Add(keyValuePair.Key, window);
                container.Inject(window);
            }
        }

        public void InitBGWindows(KeyValueStorage<WindowType, AWindow> data, DiContainer container, Transform parent = null)
        {
            foreach (var keyValuePair in data._items)
            {
                AWindow window = Object.Instantiate(keyValuePair.Value, parent);
                container.Inject(window);
            }
        }
        
        public void OpenWindow(WindowType key)
        {
            if (!_windows.ContainsKey(key)) return;
            
            if (_currentWindowType != key)
            {
                _prevWindowsKeys.Push(_currentWindowType);
                _nextAnimator.Animate(_windows[_currentWindowType], _windows[key]);
            }
            else
            {
                CloseAll();

                _windows[key].Open();
            }

            _currentWindowType = key;

            OnWindowChanged?.Invoke(key);
        }

        public void OpenPreviousWindow()
        {
            if (_prevWindowsKeys.TryPop(out var key))
            {
                _backAnimator.Animate(_windows[_currentWindowType], _windows[key]);
                
                _currentWindowType = key;

                OnWindowChanged?.Invoke(_currentWindowType);
            }
        }

        private void CloseAll()
        {
            foreach (var window in _windows.Values)
            {
                window.Close();
            }
        }
    }
}