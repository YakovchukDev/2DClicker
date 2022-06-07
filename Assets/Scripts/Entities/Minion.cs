using System;
using UnityEngine;

namespace Entities
{
    public class Minion : MonoBehaviour
    {
        public static event Action<ulong> AddValueToBalance;
        [SerializeField] private int _value;
        [SerializeField] private int _intervalInSeconds;
        private float _time;

        private void Start()
        {
            _time = 0;
        }
        private void FixedUpdate()
        {
            _time += Time.deltaTime;
            if (_time >= _intervalInSeconds)
            {
                AddValueToBalance?.Invoke((ulong)_value);
                _time -= _intervalInSeconds;
            }
        }

        public int GetIntervalInSeconds() => _intervalInSeconds;
        public int GetValue() => _value;
    }
}