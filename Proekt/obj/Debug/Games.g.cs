﻿#pragma checksum "..\..\Games.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AFA6FB09AA0F4F98CC1FA09E51E4E0025235119FE06E03B28F8FCEEAC1F8DD99"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using WpfApp3;


namespace WpfApp3 {
    
    
    /// <summary>
    /// Games
    /// </summary>
    public partial class Games : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\Games.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem PM_1;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Games.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem PM_1_1;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Games.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem PM_1_2;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Games.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem PM_1_5;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Games.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem PM_1_4;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Games.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grids;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp3;component/games.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Games.xaml"
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
            this.PM_1 = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 2:
            this.PM_1_1 = ((System.Windows.Controls.MenuItem)(target));
            
            #line 13 "..\..\Games.xaml"
            this.PM_1_1.Click += new System.Windows.RoutedEventHandler(this.PM_1_1_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.PM_1_2 = ((System.Windows.Controls.MenuItem)(target));
            
            #line 14 "..\..\Games.xaml"
            this.PM_1_2.Click += new System.Windows.RoutedEventHandler(this.PM_1_2_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.PM_1_5 = ((System.Windows.Controls.MenuItem)(target));
            
            #line 15 "..\..\Games.xaml"
            this.PM_1_5.Click += new System.Windows.RoutedEventHandler(this.PM_1_3_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.PM_1_4 = ((System.Windows.Controls.MenuItem)(target));
            
            #line 22 "..\..\Games.xaml"
            this.PM_1_4.Click += new System.Windows.RoutedEventHandler(this.PM_1_4_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.grids = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

