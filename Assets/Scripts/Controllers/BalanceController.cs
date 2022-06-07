using System;
using Entities;
using UnityEngine;

namespace Controllers
{
    public class BalanceController : MonoBehaviour
    {
        [SerializeField] private Minion _minions;
        private ulong _balanceCount;
        public delegate ushort GetMinionsCount();
        public static event GetMinionsCount OnGetMinionsCount;
        public static event Action<ulong> UpdateBalanceView;
        public static event Action<ulong> UpdateBananasPerSecondView;

        private void OnEnable()
        {
            Horse.OnHorseClicked += AddValueToBalance;
            UpgradeController.OnBuy += RemoveValueToBalance;
            UpgradeController.OnGetBalanceValue += OnGetBalanceValue;
            Minion.AddValueToBalance += AddValueToBalance;
            UpgradeController.AddNewMinion += RecalculationEverySecondsIncome;
        }
        private void OnDisable()
        {
            Horse.OnHorseClicked -= AddValueToBalance;
            UpgradeController.OnBuy -= RemoveValueToBalance;
            UpgradeController.OnGetBalanceValue -= OnGetBalanceValue;
            Minion.AddValueToBalance -= AddValueToBalance;
            UpgradeController.AddNewMinion -= RecalculationEverySecondsIncome;
        }
        private void Start()
        {
            _balanceCount = 0;
            UpdateBalanceView?.Invoke(_balanceCount);
            UpdateBananasPerSecondView?.Invoke((ulong)(Math.Round((decimal)(_minions.GetValue() *
                                                                            ((OnGetMinionsCount?.Invoke())) /
                                                                            _minions.GetIntervalInSeconds()))));
        }
        private ulong OnGetBalanceValue() => _balanceCount;

        private void AddValueToBalance(ulong value)
        {
            _balanceCount += value;
            UpdateBalanceView?.Invoke(_balanceCount);
        }
        private void RemoveValueToBalance(ulong value)
        {
            _balanceCount -= value;
            UpdateBalanceView?.Invoke(_balanceCount);
        }
        private void RecalculationEverySecondsIncome()
        {
            UpdateBananasPerSecondView?.Invoke((ulong)(Math.Round((decimal)(_minions.GetValue() *
                                                                            ((OnGetMinionsCount?.Invoke())) /
                                                                            _minions.GetIntervalInSeconds()))));
        }
    }
}