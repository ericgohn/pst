//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: TaskHelper.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System;
using System.Threading.Tasks;
using Zeexone.Framework.Core.Logging;

namespace PST.UI.Common.Helpers
{
    public static class TaskHelper
    {
        /// <summary>
        ///     使用非silence模式处理<see cref="Task" />异常。
        /// </summary>
        /// <param name="ae"></param>
        public static void HandleException(AggregateException ae)
        {
            HandleException(ae, false);
        }

        /// <summary>
        ///     处理<see cref="Task" />异常。silence模式下，系统不向用户提示任何信息。
        /// </summary>
        /// <param name="ae"></param>
        /// <param name="silence">是否使用silence模式处理异常。</param>
        public static void HandleException(AggregateException ae, bool silence)
        {
            if (ae == null)
                return;
            var ex = ae.Flatten();
            foreach (var e in ex.InnerExceptions)
            {
                if (!silence)
                    DialogHelper.ShowException("应用程序错误", e);
                LogHelper.Error("应用程序错误", e);
            }
        }
    }
}