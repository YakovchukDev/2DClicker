using System;
using Ads;
using Entities;
using Views;
using UnityEngine;

namespace Controllers
{
    public class BalanceController : MonoBehaviour
    {
        [SerializeField] private Minion _minions;
        private string _balanceCount;
        private string _nextStage;
        private string _lastBalanceCount;
        private float _incomePerSecondTimeCounter;
        public static event Action<string> OnUpdateBalanceView;
        public static event Action<string> OnUpdateBananasPerSecondView;

        private void OnEnable()
        {
            HorseView.OnHorseClicked += AddValueToBalance;
            UpgradeController.OnBuy += RemoveValueToBalance;
            MinionController.OnAddValueToBalance += AddValueToBalance;
        }
        private void OnDisable()
        {
            HorseView.OnHorseClicked -= AddValueToBalance;
            UpgradeController.OnBuy -= RemoveValueToBalance;
            MinionController.OnAddValueToBalance -= AddValueToBalance;
        }
        private void Start()
        {
            InterstitialAd.This.LoadAd();
            _lastBalanceCount = _balanceCount;
            OnUpdateBalanceView?.Invoke(_balanceCount);
        }
        private void FixedUpdate()
        {
            _incomePerSecondTimeCounter += Time.deltaTime;
            if (_incomePerSecondTimeCounter >= 1f)
            {
                _incomePerSecondTimeCounter -= 1f;
                OnUpdateBananasPerSecondView?.Invoke(StringArepheticOperations.SubtractStrings(_balanceCount, _lastBalanceCount));
                _lastBalanceCount = _balanceCount;
            }
        }
        public string GetBalanceValue() => _balanceCount;
        public string GetNextstage() => _nextStage;
        public void SetBalanceValue(string balanceCount)
        {
            _balanceCount = balanceCount;
            _lastBalanceCount = balanceCount;
            OnUpdateBalanceView?.Invoke(_balanceCount);
        }
        public void SetNextStage(string nextStage)
        {
            _nextStage = nextStage;
        }
        private void AddValueToBalance(string value)
        {
            _balanceCount = StringArepheticOperations.SumStrings(_balanceCount, value);
            OnUpdateBalanceView?.Invoke(_balanceCount);
            if (StringArepheticOperations.StringsComparison(_balanceCount, _nextStage))
            {
                InterstitialAd.This.ShowAd();
                _nextStage = StringArepheticOperations.MultiplicationOfStrings(_nextStage, 10);
            }
        }
        private void RemoveValueToBalance(string value)
        {
            _balanceCount = StringArepheticOperations.SubtractStrings(_balanceCount, value);
            _lastBalanceCount = StringArepheticOperations.SubtractStrings(_lastBalanceCount, value);
            OnUpdateBalanceView?.Invoke(_balanceCount);
        }
    }
}