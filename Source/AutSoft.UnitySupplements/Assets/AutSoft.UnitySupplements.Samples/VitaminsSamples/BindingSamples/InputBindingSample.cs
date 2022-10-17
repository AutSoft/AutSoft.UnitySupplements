﻿#nullable enable
using AutSoft.UnitySupplements.Vitamins;
using AutSoft.UnitySupplements.Vitamins.Bindings;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AutSoft.UnitySupplements.Samples.VitaminSamples.BindingSamples
{
    public class InputBindingSample : MonoBehaviour
    {
        private readonly InputData _data = new();

        [SerializeField] private TMP_InputField _inputField = default!;
        [SerializeField] private TMP_Text _inputShowcase = default!;
        [SerializeField] private TMP_Text _parsedValueText = default!;
        [SerializeField] private Button _removeLastCharacterButton = default!;
        [SerializeField] private Button _alphabetizeButton = default!;

        private void Awake()
        {
            this.CheckSerializedFields();

            _data.Bind
            (
                gameObject,
                _inputField.onValueChanged,
                x => x.Input,
                updateTarget: x => _inputField.text = x,
                updateSource: x => x
            );

            _data.Bind
            (
                gameObject,
                x => x.Input,
                i => _inputShowcase.text = i
            );

            _data.Bind
            (
                gameObject,
                x => x.Input,
                i => _parsedValueText.text = double.TryParse(i, out var result)
                    ? result.ToString()
                    : "Could not parse"
            );

            _removeLastCharacterButton.onClick.Bind(gameObject, _data.RemoveLastCharacter);

            _alphabetizeButton.onClick.Bind(gameObject, _data.Alphabetize);
        }
    }
}
