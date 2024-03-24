using Source.Scripts.View;

namespace Source.Scripts.UI.Animations
{
    public interface IWindowsAnimator
    {
        public void Animate(AWindow currentWindow, AWindow newWindow);
    }
}