using Controllers;
using TMPro;
using UnityEngine;

namespace Views
{
    public class BanansPerSecondsView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _bananasPerSecondsText;

        private void OnEnable()
        {
            BalanceController.OnUpdateBananasPerSecondView += OnUpdateBananasPerSecondView;
        }
        private void OnDisable()
        {
            BalanceController.OnUpdateBananasPerSecondView -= OnUpdateBananasPerSecondView;
        }
        private void OnUpdateBananasPerSecondView(string value)
        {
            _bananasPerSecondsText.text = StringArepheticOperations.GetSourceText(value) + "/s";
        }
    }
}