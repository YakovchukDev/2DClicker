using System;
using Entities;
using Views;
using UnityEngine;

namespace Controllers
{
    public class BalanceController : MonoBehaviour
    {
        [SerializeField] private Minion _minions;
        [SerializeField]private ulong _balanceCount;
        private ulong _lastBalanceCount;
        private float _incomePerSecondTimeCounter;
        private int _boost;
        private int _durationBoost;
        private float _durationBoostCounter;
        public static event Action<ulong> UpdateBalanceView;
        public static event Action<ulong> UpdateBananasPerSecondView;

        private void OnEnable()
        {
            HorseView.OnHorseClicked += AddValueToBalance;
            UpgradeController.OnBuy += RemoveValueToBalance;
            MinionController.AddValueToBalance += AddValueToBalance;
            GoldenMinion.OnStartBoost += SetBoostValue;
        }
        private void OnDisable()
        {
            HorseView.OnHorseClicked -= AddValueToBalance;
            UpgradeController.OnBuy -= RemoveValueToBalance;
            MinionController.AddValueToBalance -= AddValueToBalance;
            GoldenMinion.OnStartBoost -= SetBoostValue;
        }
        private void Start()
        {
            _boost = 1;
            _lastBalanceCount = _balanceCount;
            UpdateBalanceView?.Invoke(_balanceCount);
        }

        private void FixedUpdate()
        {
            _incomePerSecondTimeCounter += Time.deltaTime;
            if (_incomePerSecondTimeCounter >= 1f)
            {
                _incomePerSecondTimeCounter -= 1f;
                UpdateBananasPerSecondView?.Invoke(_balanceCount - _lastBalanceCount);
                _lastBalanceCount = _balanceCount;
            }

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

        public ulong GetBalanceValue() => _balanceCount;
        public void SetBalanceValue(ulong balanceCount)
        {
            _balanceCount = balanceCount;
            _lastBalanceCount = balanceCount;
        }

        public void SetBoostValue(int boost, int duration)
        {
            _boost = boost;
            _durationBoost = duration;
        }
        private void AddValueToBalance(ulong value)
        {
            _balanceCount += value * (ulong)_boost;
            UpdateBalanceView?.Invoke(_balanceCount);
        }
        private void RemoveValueToBalance(ulong value)
        {
            _balanceCount -= value;
            _lastBalanceCount -= value;
            UpdateBalanceView?.Invoke(_balanceCount);
        }
    }
}