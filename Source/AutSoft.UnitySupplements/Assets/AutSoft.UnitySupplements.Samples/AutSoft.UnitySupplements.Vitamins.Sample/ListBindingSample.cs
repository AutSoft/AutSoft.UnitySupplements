﻿#nullable enable
using Injecter;
using Injecter.Unity;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.UI;

namespace AutSoft.UnitySupplements.Vitamins.Sample
{
    public class ListBindingSample : MonoBehaviour
    {
        [Inject] private readonly ListBindingData _data = default!;
        [Inject] private readonly IGameObjectFactory _factory = default!;

        [SerializeField] private ListView _listView = default!;

        [SerializeField] private Button _addButton = default!;
        [SerializeField] private Button _removeButton = default!;
        [SerializeField] private Button _orderButton = default!;

        [SerializeField] private GameObject _itemsPrefab = default!;

        [SerializeField] private GameObject _newItemParent = default!;
        [SerializeField] private GameObject _newItemPrefab = default!;

        private void Awake()
        {
            this.CheckSerializedField(x => x._addButton);
            this.CheckSerializedField(x => x._removeButton);
            this.CheckSerializedField(x => x._orderButton);
            this.CheckSerializedField(x => x._itemsPrefab);
            this.CheckSerializedField(x => x._newItemParent);
            this.CheckSerializedField(x => x._newItemPrefab);
        }

        private void Start()
        {
            _listView.Initialze<ListItemData, ReadOnlyObservableCollection<ListItemData>, ListItem>(_data.Items, _itemsPrefab);

            _addButton.onClick.Bind(gameObject, () =>
            {
                var item = _newItemParent.transform.GetChild(0).GetComponent<EditableListItem>().Data;

                _newItemParent.transform.DestroyChildren();
                _factory.Instantiate(_newItemPrefab, _newItemParent.transform, true);

                _data.Add(item);
            });

            _orderButton.onClick.Bind(gameObject, _data.Order);
            _removeButton.onClick.Bind(gameObject, _data.RemoveSelected);
        }
    }
}
