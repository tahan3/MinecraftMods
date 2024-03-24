using System.Xml;
using TMPro;
using UnityEngine;

namespace Source.Scripts.Localization
{
    public abstract class LocalizationLabel : MonoBehaviour
    {
        public abstract void SetNewLanguage(Language language);
    }
}