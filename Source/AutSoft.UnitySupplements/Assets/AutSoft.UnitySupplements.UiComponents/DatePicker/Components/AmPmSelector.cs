﻿#nullable enable
using AutSoft.UnitySupplements.Vitamins;
using AutSoft.UnitySupplements.Vitamins.Bindings;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AutSoft.UnitySupplements.UiComponents.DatePicker.Components
{
    public class AmPmSelector : MonoBehaviour
    {
        [SerializeField] private TMP_Text _amText = default!;
        [SerializeField] private TMP_Text _pmText = default!;
        [SerializeField] private Toggle _amToggle = default!;
        [SerializeField] private Toggle _pmToggle = default!;

        private DatePicker? _datePicker;

        public bool IsAm => _amToggle.isOn;

        private void Awake()
        {
            this.CheckSerializedFields();

            _amText.text = CultureInfo.CurrentCulture.DateTimeFormat.AMDesignator;
            _pmText.text = CultureInfo.CurrentCulture.DateTimeFormat.PMDesignator;
        }

        private void Start()
        {
            this.Bind(_amToggle.onValueChanged, AmClicked);
            this.Bind(_pmToggle.onValueChanged, PmClicked);
        }

        private void PmClicked(bool clicked)
        {
            _datePicker.IsObjectNullThrow();
            if (clicked)
            {
                _datePicker.AddHour(12);
            }
        }

        private void AmClicked(bool clicked)
        {
            _datePicker.IsObjectNullThrow();
            if(clicked)
            {
                _datePicker.AddHour(-12);
            }
        }

        public void InitAmPmSelector(DatePicker datePicker, bool isPm, TMP_FontAsset font)
        {
            _datePicker = datePicker;
            _amText.font = font;
            _pmText.font = font;
            if(isPm) { _pmToggle.SetIsOnWithoutNotify(true); }
        }
    }
}