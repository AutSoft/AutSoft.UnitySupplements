﻿#nullable enable
using AutSoft.UnitySupplements.EventBus;
using AutSoft.UnitySupplements.UiComponents.Timeline;
using AutSoft.UnitySupplements.Vitamins;
using Injecter;
using Injecter.Unity;
using System.Globalization;
using TMPro;
using UnityEngine;

namespace AutSoft.UnitySupplements.Samples.TimelineSamples
{
    public class TimeReactor : MonoBehaviourInjected
    {
        [Inject] private readonly IEventBus _eventBus = default!;

        [SerializeField] private TMP_Text _text = default!;

        private void Start()
        {
            this.CheckSerializedFields();

            _eventBus.Subscribe<CurrentTimeChanged>(OnTimeChanged);
        }

        protected override void OnDestroy()
        {
            _eventBus.UnSubscribe<CurrentTimeChanged>(OnTimeChanged);
            base.OnDestroy();
        }

        private void OnTimeChanged(CurrentTimeChanged message) => _text.text = message.CurrentTime.ToString(CultureInfo.InvariantCulture);
    }
}
