using System;
using UnityEngine;

namespace Controllers
{
    public class UpgradeController : MonoBehaviour
    {
        [SerializeField] private BalanceController _balanceController;
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private MinionController _minionController;
        private string _improvementCostClick;
        private string _costNewMinion;

        public static event Action<string, string> UpdateUpgradeClick;
        public static event Action<uint, string> UpdateBuyNewMinion;
        public static event Action UpgradeClickValue;
        public static event Action AddNewMinion;
        public static event Action<string> OnBuy;

        private void Start()
        {
            UpdateUpgradeClick?.Invoke(_playerController.GetNextClickValue(), _improvementCostClick);
            UpdateBuyNewMinion?.Invoke(_minionController.GetMinionsCount(), _costNewMinion);
        }
        public void OnClickUpgradePowerClick()
        {
            if (StringArepheticOperations.StringsComparison(_balanceController.GetBalanceValue(), _improvementCostClick))
            {
                OnBuy?.Invoke(_improvementCostClick);
                _improvementCostClick = StringArepheticOperations.MultiplicationOfStrings(_improvementCostClick, 1.1f);
                UpgradeClickValue?.Invoke();
                UpdateUpgradeClick?.Invoke(_playerController.GetNextClickValue(), _improvementCostClick);
            }
        }
        public void OnClickBuyNewMinion()
        {
            if (StringArepheticOperations.StringsComparison(_balanceController.GetBalanceValue(), _costNewMinion))
            {
                OnBuy?.Invoke(_costNewMinion);
                _costNewMinion = StringArepheticOperations.MultiplicationOfStrings(_costNewMinion, 1.1f);
                AddNewMinion?.Invoke();
                UpdateBuyNewMinion?.Invoke(_minionController.GetMinionsCount(), _costNewMinion);
            }
        }
        public string GetImprovementCostClick() => _improvementCostClick;
        public string GetCostNewMinion() => _costNewMinion;
        public void SetImprovementCostClick(string improvementCostClick)
        {
            _improvementCostClick = improvementCostClick;
        }
        public void SetCostNewMinion(string costNewMinion)
        {
            _costNewMinion = costNewMinion;
        }
    }
}