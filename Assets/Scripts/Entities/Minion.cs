using System;
using UnityEngine;

namespace Entities
{
    public class Minion : MonoBehaviour
    {
        [SerializeField] private AddBananasAnimation _addBananasAnimation;
        [SerializeField] private int _modifierValue;
        [SerializeField] private int _intervalInSeconds;
        private float _time;
        public static event Action<ulong> AddValueToBalance;

        private void Start()
        {
            _time = 0;
        }
        private void FixedUpdate()
        {
            _time += Time.deltaTime;
            if (_time >= _intervalInSeconds)
            {
                AddValueToBalance?.Invoke((ulong)_modifierValue);
                _time -= _intervalInSeconds;
                _addBananasAnimation.Play((ulong)_modifierValue);
            }
        }

        public int GetIntervalInSeconds() => _intervalInSeconds;
        public int GetValue() => _modifierValue;
    }
}