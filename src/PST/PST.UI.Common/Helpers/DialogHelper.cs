//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: DialogHelper.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System;
using DevComponents.DotNetBar;

namespace PST.UI.Common.Helpers
{
    public static class DialogHelper
    {
        public static eTaskDialogResult ShowError(string caption, string text)
        {
            return TaskDialog.Show(caption, eTaskDialogIcon.Stop, caption, string.Format("{0}：{1}", caption, text),
                eTaskDialogButton.Ok);
        }

        public static eTaskDialogResult ShowRemoveConfirm(string caption, string text)
        {
            return TaskDialog.Show("删除数据", eTaskDialogIcon.Delete, caption, string.Format("{0}：{1}", caption, text),
                eTaskDialogButton.Yes | eTaskDialogButton.No);
        }

        public static eTaskDialogResult ShowConfirm(string caption, string text)
        {
            return TaskDialog.Show(caption, eTaskDialogIcon.Delete, caption, string.Format("{0}：{1}", caption, text),
                eTaskDialogButton.Yes | eTaskDialogButton.No);
        }

        public static eTaskDialogResult ShowException(string title, Exception e)
        {
            string errorHeader = "An application error occurred. Please contact the adminstrator " +
                                 "with the following information:\n\n";
            return ShowException(title, errorHeader, e);
        }

        public static eTaskDialogResult ShowException(string title, string header, Exception e)
        {
            string errorMsg = e.Message + "\n\nStack Trace:\n" + e.StackTrace;
            return TaskDialog.Show(title, eTaskDialogIcon.Stop, header, errorMsg,
                eTaskDialogButton.Ok);
        }

        public static eTaskDialogResult ShowRemoveError(string text)
        {
            return TaskDialog.Show("数据删除失败", eTaskDialogIcon.Stop, "数据删除失败",
                string.Format("系统在删除数据时发生错误，错误原因：\n\n{0}", text),
                eTaskDialogButton.Ok);
        }

        public static eTaskDialogResult ShowUpdateError(string text)
        {
            return TaskDialog.Show("数据更新失败", eTaskDialogIcon.Stop, "数据更新失败",
                string.Format("系统在更新数据时发生错误，错误原因：\n\n{0}", text),
                eTaskDialogButton.Ok);
        }

        public static eTaskDialogResult ShowAddError(string text)
        {
            return TaskDialog.Show("数据添加失败", eTaskDialogIcon.Stop, "数据添加失败",
                string.Format("系统在添加数据时发生错误，错误原因：\n\n{0}", text),
                eTaskDialogButton.Ok);
        }

        public static eTaskDialogResult ShowLoadError(string text)
        {
            return TaskDialog.Show("数据载入失败", eTaskDialogIcon.Stop, "数据载入失败",
                string.Format("系统在获取数据时发生错误，错误原因：\n\n{0}", text),
                eTaskDialogButton.Ok);
        }
    }
}