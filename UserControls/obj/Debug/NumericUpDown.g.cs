﻿#pragma checksum "..\..\NumericUpDown.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C835E302F060215F1460779B83389BFB8432B07D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using UserControls;


namespace UserControls {
    
    
    /// <summary>
    /// NumericUpDown
    /// </summary>
    public partial class NumericUpDown : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\NumericUpDown.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NUDTextBox;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\NumericUpDown.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.RepeatButton NUDButtonUP;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\NumericUpDown.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.RepeatButton NUDButtonDown;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/UserControls;component/numericupdown.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\NumericUpDown.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.NUDTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 20 "..\..\NumericUpDown.xaml"
            this.NUDTextBox.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.NUDTextBox_PreviewKeyDown);
            
            #line default
            #line hidden
            
            #line 20 "..\..\NumericUpDown.xaml"
            this.NUDTextBox.PreviewKeyUp += new System.Windows.Input.KeyEventHandler(this.NUDTextBox_PreviewKeyUp);
            
            #line default
            #line hidden
            
            #line 20 "..\..\NumericUpDown.xaml"
            this.NUDTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.NUDTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.NUDButtonUP = ((System.Windows.Controls.Primitives.RepeatButton)(target));
            
            #line 21 "..\..\NumericUpDown.xaml"
            this.NUDButtonUP.Click += new System.Windows.RoutedEventHandler(this.NUDButtonUP_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.NUDButtonDown = ((System.Windows.Controls.Primitives.RepeatButton)(target));
            
            #line 22 "..\..\NumericUpDown.xaml"
            this.NUDButtonDown.Click += new System.Windows.RoutedEventHandler(this.NUDButtonDown_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

