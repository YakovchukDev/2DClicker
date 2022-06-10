using System;
using UnityEngine;

namespace Controllers
{
    public class UpgradeController : MonoBehaviour
    {
        [SerializeField] private BalanceController _balanceController;
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private MinionController _minionController;
        private ulong _improvementCostClick;
        private ulong _costNewMinion;

        public static event Action<ulong, ulong> UpdateUpgradeClick;
        public static event Action<ulong, ulong> UpdateBuyNewMinion;
        public static event Action UpgradeClickValue;
        public static event Action AddNewMinion;
        public static event Action<ulong> OnBuy;

        private void Start()
        {
            UpdateUpgradeClick?.Invoke(_playerController.GetNextClickValue(), _improvementCostClick);
            UpdateBuyNewMinion?.Invoke(_minionController.GetMinionsCount(), _costNewMinion);
        }
        public void OnClickUpgradePowerClick()
        {
            if (_balanceController.GetBalanceValue() >= _improvementCostClick)
            {
                OnBuy?.Invoke(_improvementCostClick);
                _improvementCostClick = (ulong)Math.Round(_improvementCostClick * 1.1f);
                UpgradeClickValue?.Invoke();
                UpdateUpgradeClick?.Invoke(_playerController.GetNextClickValue(), _improvementCostClick);
            }
        }
        public void OnClickBuyNewMinion()
        {
            if (_balanceController.GetBalanceValue() >= _costNewMinion)
            {
                OnBuy?.Invoke(_costNewMinion);
                _costNewMinion = (ulong)Math.Round(_costNewMinion * 1.1f);
                AddNewMinion?.Invoke();
                UpdateBuyNewMinion?.Invoke(_minionController.GetMinionsCount(), _costNewMinion);
            }
        }

        public ulong GetImprovementCostClick() => _improvementCostClick;
        public ulong GetCostNewMinion() => _costNewMinion;
        public void SetImprovementCostClick(ulong improvementCostClick)
        {
            _improvementCostClick = improvementCostClick;
        }
        public void SetCostNewMinion(ulong costNewMinion)
        {
            _costNewMinion = costNewMinion;
        }
    }
}