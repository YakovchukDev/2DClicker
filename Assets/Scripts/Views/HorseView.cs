using System;
using Controllers;
using Entities;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Views
{
    public class HorseView : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private AddBananasAnimation _addBananasAnimation;
        private ulong _currentModifier;
        public static event Action<ulong> OnHorseClicked;

        private void OnEnable()
        {
            PlayerController.OnSetCurrentModifier += SetCurrentModifier;
        }
        private void OnDisable()
        {
            PlayerController.OnSetCurrentModifier += SetCurrentModifier;
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            OnHorseClicked?.Invoke(_currentModifier);
            _addBananasAnimation.Play(_currentModifier);
        }
        private void SetCurrentModifier(ulong currentModifier)
        {
            _currentModifier = currentModifier;
        }
    }
}