﻿#pragma checksum "..\..\InstagramTest.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9669A2FC48C0ABB5C9652B0CBA56F5CBCF8927A9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using InstagramServicesDesktopWin64;
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


namespace InstagramServicesDesktopWin64 {
    
    
    /// <summary>
    /// InstagramTest
    /// </summary>
    public partial class InstagramTest : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\InstagramTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelLog;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\InstagramTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbAndroid;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\InstagramTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbBrowser;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\InstagramTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbUsers;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\InstagramTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbProxy;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\InstagramTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbLike;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\InstagramTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbComment;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\InstagramTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbSubscribe;
        
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
            System.Uri resourceLocater = new System.Uri("/InstagramServicesDesktopWin64;component/instagramtest.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\InstagramTest.xaml"
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
            this.labelLog = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.rbAndroid = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 3:
            this.rbBrowser = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 4:
            this.tbUsers = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.tbProxy = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            
            #line 17 "..\..\InstagramTest.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Start);
            
            #line default
            #line hidden
            return;
            case 7:
            this.tbLike = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 20 "..\..\InstagramTest.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Like_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.tbComment = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            
            #line 23 "..\..\InstagramTest.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Comment_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.tbSubscribe = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            
            #line 26 "..\..\InstagramTest.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Subscribe_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

