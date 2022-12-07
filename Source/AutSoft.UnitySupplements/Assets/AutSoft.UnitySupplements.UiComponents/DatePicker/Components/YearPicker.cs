﻿using AutSoft.UnitySupplements.Vitamins;
using TMPro;
using UnityEngine;

namespace AutSoft.UnitySupplements.UiComponents.DatePicker.Components
{
    public class YearPicker : MonoBehaviour
    {
        [SerializeField] private Transform _buttonParent = default!;
        [SerializeField] private MonthPicker _monthPicker = default!;
        [SerializeField] private TMP_Text _yearMonthLabel = default!;

        private int _currentYearStart;
        private int _currentMonth;
        private TMP_FontAsset? _font;

        private void Awake() => this.CheckSerializedFields();

        public void SpawnYears(int startYear, int currentMonth, TMP_FontAsset font)
        {
            _currentMonth = currentMonth;
            _font = font;
            _buttonParent.DestroyChildren();
            _currentYearStart = startYear - (startYear % 10);
            for (var i = 0; i < 20; i++)
            {
                var currentYear = Instantiate(Resources.Load<GameObject>("YearButton"), _buttonParent);
                currentYear.GetComponent<YearButton>().SetupYearButton(_currentYearStart + i, _monthPicker, gameObject, _font);
                if (_currentYearStart + i == startYear)
                {
                    currentYear.GetComponent<YearSelectionHighlighter>().Highlight(true);
                }
            }
            _yearMonthLabel.text = $"{_currentYearStart} - {_currentYearStart + 19}";
            _monthPicker.SetCurrentMonth(_currentMonth);
        }

        public void StepYears(int step)
        {
            _font.IsObjectNullThrow();
            _currentYearStart += step;
            SpawnYears(_currentYearStart, _currentMonth, _font);
        }
    }
}