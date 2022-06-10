using Controllers;
using TMPro;
using UnityEngine;

namespace Views
{
    public class BuyNewMinionsView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _minionsCountText;
        [SerializeField] private TMP_Text _costNewMinionText;

        private void OnEnable()
        {
            UpgradeController.UpdateBuyNewMinion += UpdateBuyNewMinion;
        }

        private void OnDisable()
        {
            UpgradeController.UpdateBuyNewMinion -= UpdateBuyNewMinion;
        }

        private void UpdateBuyNewMinion(ulong minionCount, ulong costNewMinion)
        {
            _minionsCountText.text = TextConverter.GetSourceText(minionCount);
            _costNewMinionText.text = TextConverter.GetSourceText(costNewMinion);
        }
    }
}