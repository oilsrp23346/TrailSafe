﻿#pragma checksum "C:\Users\siriporn\Documents\GitHub\Trail Safe\TrailSafe\App4\map.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7077C760A3A04289A97DD30E6C679AD4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App4
{
    partial class map : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.myMap = (global::Bing.Maps.Map)(target);
                }
                break;
            case 2:
                {
                    global::Bing.Maps.Pushpin element2 = (global::Bing.Maps.Pushpin)(target);
                    #line 24 "..\..\..\map.xaml"
                    ((global::Bing.Maps.Pushpin)element2).Tapped += this.pushpinTapped;
                    #line default
                }
                break;
            case 3:
                {
                    global::Bing.Maps.Pushpin element3 = (global::Bing.Maps.Pushpin)(target);
                    #line 30 "..\..\..\map.xaml"
                    ((global::Bing.Maps.Pushpin)element3).Tapped += this.pushpinTappedNode1;
                    #line default
                }
                break;
            case 4:
                {
                    global::Bing.Maps.Pushpin element4 = (global::Bing.Maps.Pushpin)(target);
                    #line 36 "..\..\..\map.xaml"
                    ((global::Bing.Maps.Pushpin)element4).Tapped += this.pushpinTappedNode2;
                    #line default
                }
                break;
            case 5:
                {
                    global::Bing.Maps.Pushpin element5 = (global::Bing.Maps.Pushpin)(target);
                    #line 42 "..\..\..\map.xaml"
                    ((global::Bing.Maps.Pushpin)element5).Tapped += this.pushpinTappedNode3;
                    #line default
                }
                break;
            case 6:
                {
                    global::Bing.Maps.Pushpin element6 = (global::Bing.Maps.Pushpin)(target);
                    #line 48 "..\..\..\map.xaml"
                    ((global::Bing.Maps.Pushpin)element6).Tapped += this.pushpinTappedNode4;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

