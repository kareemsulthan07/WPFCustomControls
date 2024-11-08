using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace ExpandableTextBlockSampleApp
{
    public class ExpandableTextBlock : TextBlock
    {
        private const double defaultCollapsedWidth = 220;

        public static readonly DependencyProperty CollapsedWidthProperty =
            DependencyProperty.Register(
                nameof(CollapsedWidth),
                typeof(double),
                typeof(ExpandableTextBlock),
                new PropertyMetadata(defaultCollapsedWidth));

        public static readonly DependencyProperty IsExpandedProperty =
            DependencyProperty.Register(
                nameof(IsExpanded),
                typeof(bool),
                typeof(ExpandableTextBlock),
                new PropertyMetadata(false, OnIsExpandedChanged));

        public double CollapsedWidth
        {
            get => (double)GetValue(CollapsedWidthProperty);
            set => SetValue(CollapsedWidthProperty, value);
        }

        public bool IsExpanded
        {
            get => (bool)GetValue(IsExpandedProperty);
            set => SetValue(IsExpandedProperty, value);
        }


        public ExpandableTextBlock()
        {
            Initialize();
        }

        private void Initialize()
        {
            Width = CollapsedWidth;
            TextTrimming = TextTrimming.CharacterEllipsis;
            Cursor = Cursors.Hand;
            MouseLeftButtonDown += ExpandableTextBlock_MouseLeftButtonDown;
        }

        private static void OnIsExpandedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ExpandableTextBlock textBlock)
            {
                textBlock.UpdateExpandState();
            }
        }

        private void ExpandableTextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            IsExpanded = !IsExpanded;
            e.Handled = true;
        }

        private void UpdateExpandState()
        {
            if (IsExpanded)
            {
                // Expand to full width
                Width = double.NaN;
                TextTrimming = TextTrimming.None;
            }
            else
            {
                // Collapse to fixed width
                Width = CollapsedWidth;
                TextTrimming = TextTrimming.CharacterEllipsis;
            }
        }
    }
}
