using System;
using UnityEngine;

namespace Controllers
{
    public class UpgradeController : MonoBehaviour
    {
        public delegate ulong GetValue();
        public delegate ushort GetUshortValue();

        public static event Action<ulong, ulong> UpdateUpgradeClick;
        public static event Action<ulong, ulong> UpdateBuyNewMinion;
        public static event Action UpgradeClickValue;
        public static event Action AddNewMinion;
        public static event GetValue OnGetNextClickValue;
        public static event GetValue OnGetBalanceValue;
        public static event GetUshortValue OnGetMinionCount;
        public static event Action<ulong> OnBuy;
        [SerializeField] private ulong _improvementCostClick;
        [SerializeField] private ulong _costNewMinion;

        private void Start()
        {
            UpdateUpgradeClick?.Invoke((ulong)OnGetNextClickValue?.Invoke(), _improvementCostClick);
            UpdateBuyNewMinion?.Invoke((ulong)OnGetMinionCount?.Invoke(), _costNewMinion);
        }
        public void OnClickUpgradePowerClick()
        {
            if ((ulong)OnGetBalanceValue?.Invoke() >= _improvementCostClick)
            {
                OnBuy?.Invoke(_improvementCostClick);
                _improvementCostClick = (ulong)Math.Round(_improvementCostClick * 1.1f);
                UpgradeClickValue?.Invoke();
                UpdateUpgradeClick?.Invoke((ulong)OnGetNextClickValue?.Invoke(), _improvementCostClick);
            }
        }
        public void OnClickBuyNewMinion()
        {
            if ((ulong)OnGetBalanceValue?.Invoke() >= _costNewMinion)
            {
                OnBuy?.Invoke(_costNewMinion);
                _costNewMinion = (ulong)Math.Round(_costNewMinion * 1.1f);
                AddNewMinion?.Invoke();
                UpdateBuyNewMinion?.Invoke((ulong)OnGetMinionCount?.Invoke(), _costNewMinion);
            }
        }
    }
}