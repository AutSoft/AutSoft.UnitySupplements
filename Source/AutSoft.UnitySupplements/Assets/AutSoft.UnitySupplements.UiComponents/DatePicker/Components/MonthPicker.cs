﻿using AutSoft.UnitySupplements.Vitamins;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TMPro;
using UnityEngine;

namespace AutSoft.UnitySupplements.UiComponents.DatePicker.Components
{
    public class MonthPicker : MonoBehaviour
    {
        [SerializeField] private Transform _buttonParent = default!;
        [SerializeField] private TMP_Text _yearMonthLabel = default!;
        [SerializeField] private YearMonthPicker _yearMonthPicker = default!;

        private int _year;
        private int _currentMonth;
        private readonly List<MonthButton> _monthButtons = new();

        private void Awake()
        {
            this.CheckSerializedFields();
            _buttonParent.DestroyChildren();
            var monthnames = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames;
            for (var i = 0; i < monthnames.Count(m => m != string.Empty); i++)
            {
                var monthname = monthnames[i];
                var currentMonth = Instantiate(Resources.Load<GameObject>("MonthButton"), _buttonParent);
                var monthButton = currentMonth.GetComponent<MonthButton>();
                monthButton.SetupYearButton(monthname, i + 1, _yearMonthPicker, _year);
                _monthButtons.Add(monthButton);
                monthButton.GetComponent<YearSelectionHighlighter>().HighLightButton(false);
            }

            _monthButtons[_currentMonth - 1].GetComponent<YearSelectionHighlighter>().HighLightButton(true);
        }

        public void InitYear(int year)
        {
            _year = year;
            _yearMonthLabel.text = year.ToString();
            foreach (var monthButton in _monthButtons)
            {
                monthButton.UpdateYear(year);
                monthButton.GetComponent<YearSelectionHighlighter>().HighLightButton(false);
            }
            if (_monthButtons.Count > 0)
            {
                _monthButtons[_currentMonth - 1].GetComponent<YearSelectionHighlighter>().HighLightButton(true);
            }
        }

        public void SetCurrentMonth(int currentMonth) => _currentMonth = currentMonth;
    }
}
