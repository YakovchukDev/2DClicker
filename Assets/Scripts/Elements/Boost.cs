using UnityEngine;
using Entities;

namespace Elements
{
    public class Boost : MonoBehaviour
    {
        private int _boost;
        private int _durationBoost;
        private float _durationBoostCounter;

        public void Start()
        {
            _boost = 1;
            GoldenMinion.OnStartBoost += SetBoostValue;
        }
        private void OnApplicationQuit()
        {
            GoldenMinion.OnStartBoost -= SetBoostValue;
        }
        private void FixedUpdate()
        {
            if (_boost > 1)
            {
                _durationBoostCounter += Time.deltaTime;
                if (_durationBoostCounter >= _durationBoost)
                {
                    _boost = 1;
                    _durationBoost = 0;
                    _durationBoostCounter = 0;
                }
            }
        }
        public int GetBoostValue() => _boost;
        private void SetBoostValue(int boost, int duration)
        {
            _boost = boost;
            _durationBoost = duration;
        }
    }
}
