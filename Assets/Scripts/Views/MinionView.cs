using System.Collections.Generic;
using Controllers;
using Entities;
using UnityEngine;

namespace Views
{
    public class MinionView : MonoBehaviour
    {
        [SerializeField] private List<Side> _sides;
        [SerializeField] private Minion _minion;
        [SerializeField] private Vector2Int _minionGridSize;

        private void OnEnable()
        {
            MinionController.OnAddNewMinion += AddNewMinion;
            MinionController.OnSetMinions += SetMinions;
        }
        private void OnDisable()
        {
            MinionController.OnAddNewMinion -= AddNewMinion;
            MinionController.OnSetMinions -= SetMinions;
        }
        private void SetMinions(uint minionsCount)
        {
            //економія ресурсів
            uint minionInstantiatedCount = 0;
            foreach (var side in _sides)
            {
                minionInstantiatedCount += (uint)side.GetMinionInstantiateCount();
            }
            for (int i = 0; i < minionsCount - minionInstantiatedCount; i++)
            {
                if (i <= (_minionGridSize.x * _minionGridSize.y * _sides.Count))
                {
                    AddNewMinion(true);
                }
                else
                {
                    break;
                }
            }
        }
        private void AddNewMinion(bool isRandomTime)
        {
            List<Side> availableSide = new List<Side>();
            foreach (Side side in _sides)
            {
                int minionsInSideCount;
                if (side.GetComponentsInChildren<Minion>() == null)
                {
                    minionsInSideCount = 0;
                }
                else
                {
                    minionsInSideCount = side.GetComponentsInChildren<Minion>().Length;
                }
                if ( minionsInSideCount < _minionGridSize.x * _minionGridSize.y)
                {
                    availableSide.Add(side);
                }
            }
            if (availableSide.Count > 0)
            {
                Side currentSide = availableSide[Random.Range(0, availableSide.Count)];
                Minion minion = Instantiate(_minion, currentSide.GetComponent<RectTransform>());
                minion.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2
                (
                    currentSide.GetComponent<RectTransform>().rect.width / _minionGridSize.x * (currentSide.GetMinionInstantiateCount() % _minionGridSize.x) -
                        currentSide.GetComponent<RectTransform>().rect.width / 2,
                    currentSide.GetComponent<RectTransform>().rect.height / _minionGridSize.y * (_minionGridSize.y - currentSide.GetMinionInstantiateCount() / _minionGridSize.x) -
                        currentSide.GetComponent<RectTransform>().rect.height / 2
                );
                if (isRandomTime)
                {
                    _minion.SetRandomTime();
                }
                currentSide.AddMinion();
            }
        }
    }
}