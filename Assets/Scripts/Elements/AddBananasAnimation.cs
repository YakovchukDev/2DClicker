using System.Collections;
using TMPro;
using UnityEngine;
using DG.Tweening;

namespace Elements
{
    public class AddBananasAnimation : MonoBehaviour
    {
        private TMP_Text _text;
        private RectTransform _rectTransform;

        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
            _text = GetComponentInChildren<TMP_Text>();
        }
        public void Play(string currentModifier)
        {
            _text.text = $"+{StringArepheticOperations.GetSourceText(currentModifier)}";
            _rectTransform.DOScale(0.1f, 0.2f);
            _rectTransform.DOAnchorPosY(100, 0.2f);
            StartCoroutine(AnimationReset(0.2f));
        }
        private IEnumerator AnimationReset(float time)
        {
            yield return new WaitForSeconds(time);
            _rectTransform.anchoredPosition = new Vector2(0, 0);
            _rectTransform.localScale = new Vector2(0, 0);
        }
    }
}