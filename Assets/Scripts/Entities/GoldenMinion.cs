using System;
using Controllers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using Random = UnityEngine.Random;

namespace Entities
{
    public class GoldenMinion : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private RectTransform _mainCanvas;
        [SerializeField] private Sprite _goldenMinionSpriteRight;
        [SerializeField] private Sprite _goldenMinionSpriteLeft;
        [SerializeField][Min(1)] private int _boost;
        [SerializeField][Min(0)] private int _durationBoost;
        private RectTransform _goldenMinionRect;
        private Image _goldenMinionImage;
        private int _minionSide;
        public static event Action<int, int> OnStartBoost;
        public static event Action OnGoldenMinionClick;

        private void OnEnable()
        {
            MinionController.OnShowGoldenMinion += ShowGoldenMinion;
            MinionController.OnHideGoldenMinion += HideGoldenMinion;
        }
        private void OnDisable()
        {
            MinionController.OnShowGoldenMinion -= ShowGoldenMinion;
            MinionController.OnHideGoldenMinion -= HideGoldenMinion;
        }
        private void Start()
        {
            _goldenMinionRect = GetComponent<RectTransform>();
            _goldenMinionImage = GetComponent<Image>();
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            OnStartBoost?.Invoke(_boost, _durationBoost);
            OnGoldenMinionClick?.Invoke();
        }
        private void HideGoldenMinion()
        {
            Vector2 position = _goldenMinionRect.anchoredPosition;
            position.x += 130 * _minionSide;
            _goldenMinionRect.DORotate(new Vector3(0, 0, 0), 1);
            _goldenMinionRect.DOAnchorPos(position, 1.5f);
        }
        private void ShowGoldenMinion()
        {
            ResetRect();
            Vector2 position = _goldenMinionRect.anchoredPosition;
            position.x -= 130 * _minionSide;
            _goldenMinionRect.DORotate(new Vector3(0, 0, 30 * _minionSide), 1);
            _goldenMinionRect.DOAnchorPos(position, 1.5f);
        }
        private void ResetRect()
        {
            _minionSide = Random.Range(-1, 1) >= 0 ? 1 : -1;
            switch (_minionSide)
            {
                case 1:
                {
                    _goldenMinionImage.sprite = _goldenMinionSpriteRight;
                    break;
                }
                case -1:
                {
                    _goldenMinionImage.sprite = _goldenMinionSpriteLeft;
                    break;
                }
            }
            Vector2 position = new Vector2
                    (
                        (_mainCanvas.rect.width / 2 + 100) * _minionSide, 
                        Random.Range(0, (_mainCanvas.rect.height / 2 - 200))
                    );
            _goldenMinionRect.anchoredPosition = position;
        }
    }
}