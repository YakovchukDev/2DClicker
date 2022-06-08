using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Controllers
{
    public class MinionController : MonoBehaviour
    {
        [SerializeField] private List<RectTransform> _sides;
        [SerializeField] private RectTransform _minion;
        private ushort _minionsCount;

        private void OnEnable()
        {
            BalanceController.OnGetMinionsCount += GetMinionsCount;
            UpgradeController.OnGetMinionCount += GetMinionsCount;
            UpgradeController.AddNewMinion += AddNewMinion;
        }
        private void OnDisable()
        {
            BalanceController.OnGetMinionsCount -= GetMinionsCount;
            UpgradeController.OnGetMinionCount -= GetMinionsCount;
            UpgradeController.AddNewMinion -= AddNewMinion;
        }

        private void Start()
        {
            for (int i = 0; i < _minionsCount; i++)
            {
                AddNewMinion();
                _minionsCount--;
            }
        }

        public ushort GetMinionsCount() => _minionsCount;
        public void SetMinionsCount(ushort minionsCount)
        {
            _minionsCount = minionsCount;
        }
        private void AddNewMinion()
        {
            _minionsCount++;
            RectTransform currentSide = _sides[Random.Range(0, _sides.Count)];
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
            Debug.Log(_minion.position);
            Instantiate(_minion, currentSide);
        }

    }
}
