using DG.Tweening;
using Source.Scripts.View;
using UnityEngine;

namespace Source.Scripts.UI.Animations
{
    public class RightSwipeWindowsAnimator : IWindowsAnimator
    {
        private readonly float _duration;

        public RightSwipeWindowsAnimator(float duration)
        {
            _duration = duration;
        }

        public void Animate(AWindow currentWindow, AWindow newWindow)
        {
            var currentRect = currentWindow.GetComponent<RectTransform>();
            var newRect = newWindow.GetComponent<RectTransform>();
            
            newRect.anchoredPosition = new Vector2(-newRect.rect.width, newRect.anchoredPosition.y);
            newWindow.Open();

            currentRect.DOAnchorPosX(currentRect.anchoredPosition.x + currentRect.rect.width, _duration).onComplete +=
                currentWindow.Close;
            newRect.DOAnchorPosX(0f, _duration);
        }
    }
}