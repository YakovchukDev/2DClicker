using System;
using UnityEngine;

namespace Controllers
{
    public class PlayerController : MonoBehaviour
    {
        private string _currentModifier;
        private float _difference = 1.1f;
        public static event Action<string> OnSetCurrentModifier;

        private void OnEnable()
        {
            UpgradeController.UpgradeClickValue += UpgradeClickModifier;
        }
        private void OnDisable()
        {
            UpgradeController.UpgradeClickValue -= UpgradeClickModifier;
        }
        public string GetModifier() => _currentModifier;
        public string GetNextClickValue()
        {
            return StringArepheticOperations.MultiplicationOfStrings(_currentModifier, _difference);
        }
        public void SetModifier(string modifier)
        {
            _currentModifier = modifier;
            OnSetCurrentModifier?.Invoke(_currentModifier);
        }
        private void UpgradeClickModifier()
        {
            _currentModifier = StringArepheticOperations.MultiplicationOfStrings(_currentModifier, _difference);
            
            OnSetCurrentModifier?.Invoke(_currentModifier);
        }
    }
}
