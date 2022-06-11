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
            BalanceController.UpdateBananasPerSecondView += UpdateBananasPerSecondView;
        }
        private void OnDisable()
        {
            BalanceController.UpdateBananasPerSecondView -= UpdateBananasPerSecondView;
        }
        private void UpdateBananasPerSecondView(ulong value)
        {
            _bananasPerSecondsText.text = TextConverter.GetSourceText(value) + "/s";;
        }
    }
}