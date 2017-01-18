using System;
using System.Linq;
using System.Windows;
using Awesomium.Core;
using Awesomium.Windows.Controls;
using System.Collections.Generic;
using Iros._7th.Workshop;

namespace Launcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private fLibrary fLib;
        public MainWindow()
        {
            InitializeComponent();
            fLib = new fLibrary();
        }
        
        // This will be set to the target URL, when this window does not
         // host a created child view. The WebControl, is bound to this property.
        public Uri Source
        {
            get { return (Uri)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        // Identifies the <see cref="Source"/> dependency property.
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source",
            typeof(Uri), typeof(MainWindow),
            new FrameworkPropertyMetadata(null));


        // This will be set to the created child view that the WebControl will wrap,
        // when ShowCreatedWebView is the result of 'window.open'. The WebControl, 
        // is bound to this property.
        public IntPtr NativeView
        {
            get { return (IntPtr)GetValue(NativeViewProperty); }
            private set { this.SetValue(MainWindow.NativeViewPropertyKey, value); }
        }

        private static readonly DependencyPropertyKey NativeViewPropertyKey =
            DependencyProperty.RegisterReadOnly("NativeView",
            typeof(IntPtr), typeof(MainWindow),
            new FrameworkPropertyMetadata(IntPtr.Zero));

        // Identifies the <see cref="NativeView"/> dependency property.
        public static readonly DependencyProperty NativeViewProperty =
            NativeViewPropertyKey.DependencyProperty;

        // The visibility of the address bar and status bar, depends
        // on the value of this property. We set this to false when
        // the window wraps a WebControl that is the result of JavaScript
        // 'window.open'.
        public bool IsRegularWindow
        {
            get { return (bool)GetValue(IsRegularWindowProperty); }
            private set { this.SetValue(MainWindow.IsRegularWindowPropertyKey, value); }
        }

        private static readonly DependencyPropertyKey IsRegularWindowPropertyKey =
            DependencyProperty.RegisterReadOnly("IsRegularWindow",
            typeof(bool), typeof(MainWindow),
            new FrameworkPropertyMetadata(true));

        // Identifies the <see cref="IsRegularWindow"/> dependency property.
        public static readonly DependencyProperty IsRegularWindowProperty =
            IsRegularWindowPropertyKey.DependencyProperty;

        private void bLaunch(object sender, RoutedEventArgs e)
        {
           fLib.externalLaunch(false, false);
        }
    }
}