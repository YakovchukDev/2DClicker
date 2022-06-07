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
            _minionsCountText.text = minionCount.ToString();
            _costNewMinionText.text = costNewMinion.ToString();
        }
    }
}