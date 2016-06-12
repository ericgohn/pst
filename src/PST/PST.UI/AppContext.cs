//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: AppContext.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using Zeexone.Framework.Windows.Framework.Security;

namespace PST.UI
{
    public class AppContext
    {
        private static readonly AppContext _instance = new AppContext();
        private readonly IUser _user;

        private AppContext()
        {
            _user = new GeneralUser();
        }

        public static AppContext S
        {
            get { return _instance; }
        }

        public MainForm MainForm { get; set; }

        public IUser User
        {
            get { return _user; }
        }
    }
}