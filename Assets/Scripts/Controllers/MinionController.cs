using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class MinionController : MonoBehaviour
    {
        [SerializeField] private List<RectTransform> _sides;
        [SerializeField] private RectTransform _minion;
        private ushort _minionsCount = 0;

        private void OnEnable()
        {
            BalanceController.OnGetMinionsCount += GetMinionCount;
            UpgradeController.OnGetMinionCount += GetMinionCount;
            UpgradeController.AddNewMinion += AddNewMinion;
        }
        private void OnDisable()
        {
            BalanceController.OnGetMinionsCount -= GetMinionCount;
            UpgradeController.OnGetMinionCount -= GetMinionCount;
            UpgradeController.AddNewMinion -= AddNewMinion;
        }
        private ushort GetMinionCount() => _minionsCount;
        private void AddNewMinion()
        {
            _minionsCount++;
            RectTransform currentSide = _sides[Random.Range(0, _sides.Count)];
            Instantiate(_minion, currentSide);
            _minion.position = new Vector2
            (
                Random.Range
                (
                    (currentSide.rect.width * -1) / 2,
                    currentSide.rect.width / 2
                ),
                Random.Range
                (
                    (currentSide.rect.height * -1) / 2,
                    currentSide.rect.height / 2
                )
            );
        }

    }
}
