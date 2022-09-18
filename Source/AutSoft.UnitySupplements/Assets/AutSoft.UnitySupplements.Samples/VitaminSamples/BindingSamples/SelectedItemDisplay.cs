﻿#nullable enable
using AutSoft.UnitySupplements.Vitamins;
using AutSoft.UnitySupplements.Vitamins.Bindings;
using Injecter;
using Injecter.Unity;
using UnityEngine;

namespace AutSoft.UnitySupplements.Samples.VitaminSamples.BindingSamples
{
    [RequireComponent(typeof(MonoInjector))]
    public class SelectedItemDisplay : MonoBehaviour
    {
        [Inject] private readonly ListBindingData _listBindingData = default!;

        [SerializeField] private GameObject _itemPrefab = default!;
        [SerializeField] private Transform _transformParent = default!;

        private void Awake()
        {
            this.CheckSerializedField(x => x._itemPrefab);
            this.CheckSerializedField(x => x._transformParent);
        }

        private void Start() =>
            _listBindingData.Bind(gameObject, x => x.Selected, s =>
            {
                _transformParent.DestroyChildren();
                if (s is null) return;

                Instantiate(_itemPrefab, _transformParent).GetComponent<ListItem>().Initialize(s);
            });
    }
}
