using System;
using Controllers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Entities
{
    public class Horse : MonoBehaviour, IPointerClickHandler
    {
        public static event Action<ulong> OnHorseClicked;
        [SerializeField] private ulong _modificator = 10;

        private void OnEnable()
        {
            UpgradeController.UpgradeClickValue += UpgradeClickValue;
            UpgradeController.OnGetNextClickValue += OnGetNextClickValue;
        }
        private void OnDisable()
        {
            UpgradeController.UpgradeClickValue -= UpgradeClickValue;
            UpgradeController.OnGetNextClickValue += OnGetNextClickValue;
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            OnHorseClicked?.Invoke(_modificator);
        }
        private void UpgradeClickValue()
        {
            _modificator = (ulong)Math.Round(_modificator * 1.1f);
        }
        private ulong OnGetNextClickValue()
        {
            return (ulong)Math.Round(_modificator * 1.1f);
        }
    }
}