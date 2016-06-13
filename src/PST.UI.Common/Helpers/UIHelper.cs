//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: UIHelper.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System;
using System.Windows.Forms;

namespace PST.UI.Common.Helpers
{
    public static class UIHelper
    {
        public static void AsyncSetControlVisible(Control control, bool visible)
        {
            if (control.InvokeRequired)
            {
                Action<Control, bool> callBack = AsyncSetControlVisible;
                control.Invoke(callBack, control, visible);
            }
            else
            {
                control.Visible = visible;
            }
        }

        public static void AsyncSetControlText(Control control, string text)
        {
            if (control.InvokeRequired)
            {
                Action<Control, string> callBack = AsyncSetControlText;
                control.Invoke(callBack, control, text);
            }
            else
            {
                control.Text = text;
            }
        }
    }
}