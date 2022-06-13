using Controllers;
using TMPro;
using UnityEngine;

namespace Views
{
    public class UpgradeClickView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _powerClickText;
        [SerializeField] private TMP_Text _improvementCostClickText;

        private void OnEnable()
        {
            UpgradeController.UpdateUpgradeClick += UpdateUpgradeClick;
        }
        private void OnDisable()
        {
            UpgradeController.UpdateUpgradeClick -= UpdateUpgradeClick;
        }
        private void UpdateUpgradeClick(string powerClick, string improvementCostClick)
        {
            _powerClickText.text = StringArepheticOperations.GetSourceText(powerClick);
            _improvementCostClickText.text = StringArepheticOperations.GetSourceText(improvementCostClick);
        }
    }
}
