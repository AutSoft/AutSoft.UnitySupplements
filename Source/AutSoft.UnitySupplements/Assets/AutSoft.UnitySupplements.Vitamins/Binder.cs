﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

namespace AutSoft.UnitySupplements.Vitamins
{
    /// <summary>
    /// Provide "WPF-like" data binding methods, which connect properties of binding target objects and data sources
    /// </summary>
    public static class Binder
    {
        private static readonly Dictionary<Type, Dictionary<string, PropertyInfo>> _properties = new();

        public static void BindOneWay<TSource>(this INotifyPropertyChanged source, GameObject gameObject, string propertyName, Action<TSource> update) =>
            BindSourceToTarget(source, gameObject, propertyName, update);

        public static void BindOneWay<TSource, TBindingSource>(this TBindingSource source, GameObject gameObject, Expression<Func<TBindingSource, TSource>> memberExpression, Action<TSource> update)
            where TBindingSource : INotifyPropertyChanged =>
            BindOneWay(source, gameObject, GetMemberName(memberExpression), update);

        public static void BindTwoWay<TSource, TTarget>
        (
            this INotifyPropertyChanged source,
            GameObject gameObject,
            UnityEvent<TSource> unityEvent,
            string propertyName,
            Action<TTarget> updateTarget,
            Func<TSource, TTarget> updateSource
        )
        {
            var (sourceType, destroyDetector) = BindSourceToTarget(source, gameObject, propertyName, updateTarget);
            BindTargetToSource(source, unityEvent, propertyName, updateSource, sourceType, destroyDetector);
        }

        public static void BindTwoWay<TSource, TTarget, TBindingSource>
        (
            this TBindingSource source,
            GameObject gameObject,
            UnityEvent<TSource> unityEvent,
            Expression<Func<TBindingSource, TSource>> memberExpression,
            Action<TTarget> updateTarget,
            Func<TSource, TTarget> updateSource
        )
            where TBindingSource : INotifyPropertyChanged =>
            BindTwoWay(source, gameObject, unityEvent, GetMemberName(memberExpression), updateTarget, updateSource);

        public static void BindOneTime<TSource>(this INotifyPropertyChanged source, string propertyName, Action<TSource> update)
        {
            var sourceType = source.GetType();
            SetValueFirstTime(source, propertyName, update, sourceType);
        }

        public static void BindOneTime<TSource, TBindingSource>(this TBindingSource source, Expression<Func<TBindingSource, TSource>> memberExpression, Action<TSource> update)
            where TBindingSource : INotifyPropertyChanged =>
            BindOneTime(source, GetMemberName(memberExpression), update);

        public static void BindOneWayToSource<TSource, TTarget>
        (
            this INotifyPropertyChanged source,
            GameObject gameObject,
            UnityEvent<TSource> unityEvent,
            string propertyName,
            Func<TSource> getValue,
            Func<TSource, TTarget> updateSource
        )
        {
            var sourceType = source.GetType();
            var destroyDetector = gameObject.GetOrAddComponent<DestroyDetector>();
            var property = GetProperty<TSource>(propertyName, sourceType);
            var value = getValue();
            property.SetValue(source, value);
            BindTargetToSource(source, unityEvent, propertyName, updateSource, sourceType, destroyDetector);
        }

        public static void BindOneWayToSource<TSource, TTarget, TBindingSource>
        (
            this INotifyPropertyChanged source,
            GameObject gameObject,
            UnityEvent<TSource> unityEvent,
            Expression<Func<TBindingSource, TSource>> memberExpression,
            Func<TSource> getValue,
            Func<TSource, TTarget> updateSource
        )
            where TBindingSource : INotifyPropertyChanged =>
            BindOneWayToSource(source, gameObject, unityEvent, GetMemberName(memberExpression), getValue, updateSource);

        private static string GetMemberName<T, R>(Expression<Func<T, R>> memberExpression) => ((MemberExpression)memberExpression.Body).Member.Name;

        private static void BindTargetToSource<TSource, TTarget>
        (
            INotifyPropertyChanged source,
            UnityEvent<TSource> unityEvent,
            string propertyName,
            Func<TSource, TTarget> updateSource,
            Type sourceType,
            DestroyDetector destroyDetector
        )
        {
            void UpdateProperty(TSource value)
            {
                var property = _properties[sourceType][propertyName];
                var nextValue = updateSource(value);
                property.SetValue(source, nextValue);
            }
            unityEvent.AddListener(UpdateProperty);
            destroyDetector.Destroyed += () => unityEvent.RemoveListener(UpdateProperty);
        }

        private static (Type sourceType, DestroyDetector destroyDetector) BindSourceToTarget<T>
        (
            INotifyPropertyChanged source,
            GameObject gameObject,
            string propertyName,
            Action<T> update
        )
        {
            var sourceType = source.GetType();
            void UpdateBinding(object _, PropertyChangedEventArgs args)
            {
                if (args.PropertyName != propertyName) return;
                var property = _properties[sourceType][propertyName];
                update((T)property.GetValue(source));
            }
            source.PropertyChanged += UpdateBinding;
            var destroyDetector = gameObject.GetOrAddComponent<DestroyDetector>();
            destroyDetector.Destroyed += () => source.PropertyChanged -= UpdateBinding;
            SetValueFirstTime(source, propertyName, update, sourceType);
            return (sourceType, destroyDetector);
        }

        private static void SetValueFirstTime<T>
        (
            INotifyPropertyChanged source,
            string propertyName,
            Action<T> update,
            Type sourceType
        )
        {
            var property = GetProperty<T>(propertyName, sourceType);
            update((T)property.GetValue(source));
        }

        private static PropertyInfo GetProperty<T>(string propertyName, Type sourceType)
        {
            PropertyInfo property;
            if (!_properties.TryGetValue(sourceType, out var properties))
            {
                property = GetPropertyOrThrow(propertyName, sourceType);
                _properties.Add(sourceType, new Dictionary<string, PropertyInfo> { { propertyName, property } });
            }
            else if (!properties.TryGetValue(propertyName, out property))
            {
                property = GetPropertyOrThrow(propertyName, sourceType);
                properties.Add(propertyName, property);
            }
            return property;

            static PropertyInfo GetPropertyOrThrow(string propertyName, Type sourceType)
            {
                var property = sourceType.GetProperty(propertyName) ?? throw new InvalidOperationException($"Could not find Property {propertyName} on Type {sourceType.FullName}");
                if (!property.PropertyType.IsAssignableFrom(typeof(T))) throw new InvalidOperationException($"Could not bind Property of type {property.PropertyType} to Update type {typeof(T)}");
                return property;
            }
        }
    }
}
