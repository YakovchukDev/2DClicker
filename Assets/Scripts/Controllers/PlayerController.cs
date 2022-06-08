using System;
using Views;
using UnityEngine;

namespace Controllers
{
    public class PlayerController : MonoBehaviour
    {
        public static event Action<ulong> OnSetCurrentModifier;
        private ulong _currentModifier;
        private float _difference = 1.1f;

        private void OnEnable()
        {
            UpgradeController.UpgradeClickValue += UpgradeClickModifier;
            UpgradeController.OnGetNextClickValue += GetNextClickValue;
        }
        private void OnDisable()
        {
            UpgradeController.UpgradeClickValue -= UpgradeClickModifier;
            UpgradeController.OnGetNextClickValue -= GetNextClickValue;
        }

        public ulong GetModifier() => _currentModifier;
        public void SetModifier(ulong modifier)
        {
            _currentModifier = modifier;
            OnSetCurrentModifier?.Invoke(_currentModifier);
        }
        private void UpgradeClickModifier()
        {
            _currentModifier = (ulong)Math.Round(_currentModifier * _difference);
            OnSetCurrentModifier?.Invoke(_currentModifier);
        }
        private ulong GetNextClickValue()
        {
            return (ulong)Math.Round(_currentModifier * _difference);
        }
    }
}
