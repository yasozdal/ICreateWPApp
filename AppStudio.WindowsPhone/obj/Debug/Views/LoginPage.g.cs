﻿

#pragma checksum "D:\ПРОЕКТ\15.05\AppStudio.WindowsPhone\Views\LoginPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8F58AA0C49EA78D469B158C462798D6C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppStudio.Views
{
    partial class LoginPage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 39 "..\..\Views\LoginPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).LostFocus += this.LoginBox_LostFocus;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 42 "..\..\Views\LoginPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.LoginButton_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 43 "..\..\Views\LoginPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.RegisterButton_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


