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
            BalanceController.OnUpdateBalanceView += OnUpdateBalanceView;
        }
        private void OnDisable()
        {
            BalanceController.OnUpdateBalanceView -= OnUpdateBalanceView;
        }
        private void OnUpdateBalanceView(string value)
        {
            _balanceText.text = StringArepheticOperations.GetSourceText(value);
        }
    }
}
