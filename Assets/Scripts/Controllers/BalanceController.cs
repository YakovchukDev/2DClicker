using System;
using Entities;
using Views;
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
            HorseView.OnHorseClicked += AddValueToBalance;
            UpgradeController.OnBuy += RemoveValueToBalance;
            UpgradeController.OnGetBalanceValue += GetBalanceValue;
            Minion.AddValueToBalance += AddValueToBalance;
            UpgradeController.AddNewMinion += RecalculationEverySecondsIncome;
        }
        private void OnDisable()
        {
            HorseView.OnHorseClicked -= AddValueToBalance;
            UpgradeController.OnBuy -= RemoveValueToBalance;
            UpgradeController.OnGetBalanceValue -= GetBalanceValue;
            Minion.AddValueToBalance -= AddValueToBalance;
            UpgradeController.AddNewMinion -= RecalculationEverySecondsIncome;
        }
        private void Start()
        {
            UpdateBalanceView?.Invoke(_balanceCount);
            UpdateBananasPerSecondView?.Invoke((ulong)(Math.Round((decimal)(_minions.GetValue() *
                                                                            ((OnGetMinionsCount?.Invoke())) /
                                                                            _minions.GetIntervalInSeconds()))));
        }
        public ulong GetBalanceValue() => _balanceCount;
        public void SetBalanceValue(ulong balanceCount)
        {
            _balanceCount = balanceCount;
        }
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