using System;
using Controllers;
using Elements;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Views
{
    public class HorseView : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private AddBananasAnimation _addBananasAnimation;
        private string _currentModifier;
        private Boost _boost;
        public static event Action<string> OnHorseClicked;

        private void OnEnable()
        {
            PlayerController.OnSetCurrentModifier += SetCurrentModifier;
        }
        private void OnDisable()
        {
            PlayerController.OnSetCurrentModifier += SetCurrentModifier;
        }
        private void Start()
        {
            _boost = GetComponent<Boost>();
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            string boostModifier = StringArepheticOperations.MultiplicationOfStrings(_currentModifier, _boost.GetBoostValue());
            OnHorseClicked?.Invoke(boostModifier);
            _addBananasAnimation.Play(boostModifier);
        }
        private void SetCurrentModifier(string currentModifier)
        {
            _currentModifier = currentModifier;
        }
    }
}