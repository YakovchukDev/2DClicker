using System;
using Elements;
using Entities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Controllers
{
    public class MinionController : MonoBehaviour
    {
        [SerializeField] private Minion _minion;
        private float _timeCounter;
        private uint _minionsCount;
        private int _timeIntervalBoost;
        private int _durationExpectations;
        private bool _isActiveExpectations;
        private float _timeIntervalBostCounter;
        private Boost _boost;
        public static event Action<bool> OnAddNewMinion;
        public static event Action<uint> OnSetMinions;
        public static event Action<string> OnAddValueToBalance;
        public static event Action OnShowGoldenMinion;
        public static event Action OnHideGoldenMinion;

        private void OnEnable()
        {
            UpgradeController.AddNewMinion += AddNewMinion;
            GoldenMinion.OnGoldenMinionClick += ResetTimer;
        }
        private void OnDisable()
        {
            UpgradeController.AddNewMinion -= AddNewMinion;
            GoldenMinion.OnGoldenMinionClick -= ResetTimer;
        }
        private void Start()
        {
            _boost = GetComponent<Boost>();
            _durationExpectations = 5;
            _timeIntervalBoost = GetNewTimeIntervalBoost();
        }
        private void FixedUpdate()
        {
            _timeCounter += Time.deltaTime;
            //використовую оновлення кожну секунду, а не по часу в префабі, щоб згладити данні доходу за кожну секунду
            if (_timeCounter >= 1)
            {
                if (_minionsCount > 0)
                {
                    OnAddValueToBalance?.Invoke(StringArepheticOperations.MultiplicationOfStrings(_minion.GetValue(), 
                        _minionsCount / (float)_minion.GetIntervalInSeconds() * _boost.GetBoostValue()));
                }
                _timeCounter -= 1;
            }
            //логіка golden minion
            _timeIntervalBostCounter += Time.deltaTime;
            if (_timeIntervalBostCounter >= _timeIntervalBoost && !_isActiveExpectations)
            {
                _isActiveExpectations = true;
                _timeIntervalBostCounter -= _timeIntervalBoost;
                OnShowGoldenMinion?.Invoke();
            }
            else if (_timeIntervalBostCounter >= _durationExpectations && _isActiveExpectations)
            {
                _isActiveExpectations = false;
                _timeIntervalBostCounter -= _durationExpectations;
                _timeIntervalBoost = GetNewTimeIntervalBoost();
                OnHideGoldenMinion?.Invoke();
            }
        }
        public uint GetMinionsCount() => _minionsCount;
        public void SetMinionsCount(uint minionsCount)
        {
            _minionsCount = minionsCount;
            OnSetMinions?.Invoke(_minionsCount);
        }
        private void AddNewMinion()
        {
            _minionsCount++;
            OnAddNewMinion?.Invoke(false);
        }
        private int GetNewTimeIntervalBoost()
        {
            return Random.Range(30, 120);
        }
        private void ResetTimer()
        {
            _isActiveExpectations = false;
            _timeIntervalBostCounter = 0;
            _timeIntervalBoost = GetNewTimeIntervalBoost();
            OnHideGoldenMinion?.Invoke();
        }
    }
}