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
        private float _time;
        public delegate ushort GetMinionsCount();
        public static event GetMinionsCount OnGetMinionsCount;
        public static event Action<ulong> UpdateBalanceView;
        public static event Action<ulong> UpdateBananasPerSecondView;

        private void OnEnable()
        {
            HorseView.OnHorseClicked += AddValueToBalance;
            UpgradeController.OnBuy += RemoveValueToBalance;
            UpgradeController.OnGetBalanceValue += GetBalanceValue;
            Minion.AddValueToBalance += AddValueToBalance;
        }
        private void OnDisable()
        {
            HorseView.OnHorseClicked -= AddValueToBalance;
            UpgradeController.OnBuy -= RemoveValueToBalance;
            UpgradeController.OnGetBalanceValue -= GetBalanceValue;
            Minion.AddValueToBalance -= AddValueToBalance;
        }
        private void Start()
        {
            _lastBalanceCount = _balanceCount;
            UpdateBalanceView?.Invoke(_balanceCount);
            UpdateBananasPerSecondView?.Invoke((ulong)(Math.Round((decimal)(_minions.GetValue() *
                                                                            ((OnGetMinionsCount?.Invoke())) /
                                                                            _minions.GetIntervalInSeconds()))));
        }

        private void FixedUpdate()
        {
            _time += Time.deltaTime;
            if (_time >= 1f)
            {
                _time -= 1f;
                RecalculationEverySecondsIncome(_balanceCount - _lastBalanceCount);
                _lastBalanceCount = _balanceCount;
            }
        }

        public ulong GetBalanceValue() => _balanceCount;
        public void SetBalanceValue(ulong balanceCount)
        {
            _balanceCount = balanceCount;
            _lastBalanceCount = balanceCount;
        }
        private void AddValueToBalance(ulong value)
        {
            _balanceCount += value;
            UpdateBalanceView?.Invoke(_balanceCount);
        }
        private void RemoveValueToBalance(ulong value)
        {
            _balanceCount -= value;
            _lastBalanceCount -= value;
            UpdateBalanceView?.Invoke(_balanceCount);
        }
        private void RecalculationEverySecondsIncome(ulong bananasPerSecondValue)
        {
            UpdateBananasPerSecondView?.Invoke(bananasPerSecondValue);
        }
    }
}