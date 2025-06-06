﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace GAT.GT7.Client.Core
{
    public class DataGridBehavior
    {
        public static readonly DependencyProperty AutoscrollProperty = DependencyProperty.RegisterAttached(
         "Autoscroll", typeof(bool), typeof(DataGridBehavior), new PropertyMetadata(default(bool), AutoscrollChangedCallback));

        private static readonly Dictionary<DataGrid, NotifyCollectionChangedEventHandler> _handlers = new();

        private static void AutoscrollChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            DataGrid dataGrid = dependencyObject as DataGrid;
            if (dataGrid == null)
            {
                throw new InvalidOperationException("Dependency object is not DataGrid.");
            }

            if ((bool)args.NewValue)
            {
                Subscribe(dataGrid);
                dataGrid.Unloaded += DataGridOnUnloaded;
                dataGrid.Loaded += DataGridOnLoaded;
            }
            else
            {
                Unsubscribe(dataGrid);
                dataGrid.Unloaded -= DataGridOnUnloaded;
                dataGrid.Loaded -= DataGridOnLoaded;
            }
        }

        private static void Subscribe(DataGrid dataGrid)
        {
            if (_handlers.ContainsKey(dataGrid) == false)
            {
                var handler = new NotifyCollectionChangedEventHandler((sender, eventArgs) => ScrollToEnd(dataGrid));
                _handlers.Add(dataGrid, handler);
                ((INotifyCollectionChanged)dataGrid.Items).CollectionChanged += handler;
                ScrollToEnd(dataGrid);
            }
        }

        private static void Unsubscribe(DataGrid dataGrid)
        {
            NotifyCollectionChangedEventHandler handler;
            _handlers.TryGetValue(dataGrid, out handler);
            if (handler != null)
            {
                ((INotifyCollectionChanged)dataGrid.Items).CollectionChanged -= handler;
                _handlers.Remove(dataGrid);
            }
        }

        private static void DataGridOnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            DataGrid dataGrid = (DataGrid)sender;
            if (GetAutoscroll(dataGrid))
            {
                Subscribe(dataGrid);
            }
        }

        private static void DataGridOnUnloaded(object sender, RoutedEventArgs routedEventArgs)
        {
            DataGrid dataGrid = (DataGrid)sender;
            if (GetAutoscroll(dataGrid))
            {
                Unsubscribe(dataGrid);
            }
        }

        private static void ScrollToEnd(DataGrid datagrid)
        {
            if (datagrid.Items.Count == 0)
            {
                return;
            }
            datagrid.ScrollIntoView(datagrid.Items[datagrid.Items.Count - 1]);
        }

        public static void SetAutoscroll(DependencyObject element, bool value)
        {
            element.SetValue(AutoscrollProperty, value);
        }

        public static bool GetAutoscroll(DependencyObject element)
        {
            return (bool)element.GetValue(AutoscrollProperty);
        }
    }
}