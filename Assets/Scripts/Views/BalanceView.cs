using Controllers;
using TMPro;
using UnityEngine;

namespace Views
{
    public class BalanceView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _balanceText;

        private void OnEnable()
        {
            BalanceController.UpdateBalanceView += UpdateBalanceView;
        }
        private void OnDisable()
        {
            BalanceController.UpdateBalanceView -= UpdateBalanceView;
        }
        private void UpdateBalanceView(ulong value)
        {

            _balanceText.text = TextConverter.GetSourceText(value);
        }
    }
}
