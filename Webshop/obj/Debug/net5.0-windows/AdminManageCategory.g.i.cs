﻿#pragma checksum "..\..\..\AdminManageCategory.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "33D35490708A9E39D3631FA1A17D9EFCF24243D2"
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
using System.Windows.Controls.Ribbon;
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
using Webshop;


namespace Webshop {
    
    
    /// <summary>
    /// AdminManageCategory
    /// </summary>
    public partial class AdminManageCategory : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\..\AdminManageCategory.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextTitle;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\AdminManageCategory.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextMessage;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\AdminManageCategory.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox InputName;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\AdminManageCategory.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox InputDescription;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\AdminManageCategory.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonCreateCategory;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\AdminManageCategory.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonGoBack;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.14.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Webshop;component/adminmanagecategory.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AdminManageCategory.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.14.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TextTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.TextMessage = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.InputName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.InputDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.ButtonCreateCategory = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\..\AdminManageCategory.xaml"
            this.ButtonCreateCategory.Click += new System.Windows.RoutedEventHandler(this.ButtonCreateCategory_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ButtonGoBack = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\AdminManageCategory.xaml"
            this.ButtonGoBack.Click += new System.Windows.RoutedEventHandler(this.ButtonGoBack_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

