using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using DG.Tweening.Core;
using UnityEditor;

namespace EconimicGame.UI
{
    public class BuildingsMenuUI : MonoBehaviour
    {
        [Header("Камера")] [SerializeField] 
        private Camera _camera;

        [Header("Основная кнопка для открытия меню"), Space(10)] [SerializeField]
        private RectTransform _buldingsMenuButton;

        [Header("Кнопки меню")] [SerializeField]
        private List<Transform> _buldingButtons;

        [Header("Отступ между кнопками")] [SerializeField]
        private float _indent;

        [Header("Скорость открытия")] [SerializeField]
        private float _timeToOpen;

        [Header("Позиция сокрытия кнопок")] [SerializeField]
        private Transform _posHide;

        private bool _isOpen = false;

        private void Start()
        {
            _buldingButtons.ForEach((e) => e.DOScale(0f, 0));
        }

        public void ShowHideMenu()
        {
            if (_isOpen == false)
            {
                Show();
            }
            else
            {
                Hide();
            }

            _isOpen = !_isOpen;
        }

        private void Show()
        {
            float moveDistance = _buldingsMenuButton.rect.height;
            Vector3 menuButtonPosition = _buldingsMenuButton.transform.localPosition;

            Sequence sequence = DOTween.Sequence();
            sequence.Append(_buldingButtons[0].DOLocalMove(
                new Vector3(menuButtonPosition.x, menuButtonPosition.y + moveDistance + _indent,
                    menuButtonPosition.z), _timeToOpen));
            sequence.Join(_buldingButtons[0].DOScale(1f, _timeToOpen));
            for (int i = 1; i < _buldingButtons.Count; i++)
            {
                sequence.Append(_buldingButtons[i].DOLocalMove(
                    new Vector3(menuButtonPosition.x, menuButtonPosition.y + (moveDistance * (i + 1)) + _indent,
                        menuButtonPosition.z), _timeToOpen));
                sequence.Join(_buldingButtons[i].DOScale(1f, _timeToOpen));
            }
        }

        private void Hide()
        {
            Vector3 posToHide = _posHide.localPosition;

            Sequence sequence = DOTween.Sequence();
            sequence.Append(_buldingButtons[_buldingButtons.Count - 1].DOLocalMove(posToHide, _timeToOpen));
            sequence.Join(_buldingButtons[_buldingButtons.Count - 1].DOScale(0f, _timeToOpen));
            for (int i = _buldingButtons.Count - 2; i >= 0; i--)
            {
                sequence.Append(_buldingButtons[i].DOLocalMove(posToHide, _timeToOpen));
                sequence.Join(_buldingButtons[i].DOScale(0f, _timeToOpen));
            }
        }
    }
}