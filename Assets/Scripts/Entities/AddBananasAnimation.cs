using System;
using TMPro;
using UnityEngine;

namespace Entities
{
    public class AddBananasAnimation : MonoBehaviour
    {
        private TMP_Text _text;
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _text = GetComponentInChildren<TMP_Text>();
        }
        public void Play(ulong currentModifier)
        {
            if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Show"))
            {
                _text.text = $"+{currentModifier}";
                _animator.Play("Show");
            }
        }
    }
}