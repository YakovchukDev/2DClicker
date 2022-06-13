using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using Elements;
using Random = UnityEngine.Random;

namespace Entities
{
    // мінйон це об'єкт, який відповідає за тільки за візуалізацію, вся логіка знаходиться в minioncontroller
    public class Minion : MonoBehaviour
    {
        [SerializeField] private AddBananasAnimation _addBananasAnimation;
        [SerializeField] private string _modifierValue;
        [SerializeField] private int _intervalInSeconds;
        [SerializeField] private RectTransform _rectTransformImage;
        [SerializeField] private float _timeCounter;//SerializeField тут не потрібен, стоїть тому що без нього при визові в різних обьектах SetRandomTime(), метод створює одинавове значення, а віднього потрібні різні значення
        private Boost _boost;

        private void Start()
        {
            _boost = GetComponent<Boost>();
        }

        private void FixedUpdate()
        {
            _timeCounter += Time.deltaTime;
            if (_timeCounter >= _intervalInSeconds)
            {
                _timeCounter -= _intervalInSeconds;
                _addBananasAnimation.Play(StringArepheticOperations.MultiplicationOfStrings(_modifierValue, _boost.GetBoostValue()));
                StartCoroutine(Play());
            }
        }
        public int GetIntervalInSeconds() => _intervalInSeconds;
        public string GetValue() => _modifierValue;
        // це потрібно при загрузкі данних, щоб візуаліція додавання монет виглядала більш рівномірною
        public void SetRandomTime()
        {
            _timeCounter = Random.Range(0f, _intervalInSeconds);
        }
        private IEnumerator Play()
        {
            float durationTime = 0.4f;
            _rectTransformImage.DORotate(new Vector3(0, 0, -90), durationTime);
            yield return new WaitForSeconds(durationTime);
            _rectTransformImage.DORotate(new Vector3(0, 0, 0), durationTime);
        }
    }
}