using Jiavs.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jiavs.Domain.Models.ValueObjects
{
    public class LoginHistory : ValueObject
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginTime { get; set; }
        /// <summary>
        /// 登录ip
        /// </summary>
        public string LoginIp { get; set; }
        /// <summary>
        /// 客户端类型
        /// </summary>
        public ClientKind Client { get; set; }
        /// <summary>
        /// 客户端指纹
        /// </summary>
        public string ClientMark { get; set; }
    }

    public enum ClientKind
    {
        Web = 0,
        Android,
        AndroidWeb,
        AndroidPad,
        Iphone,
        IphoneWeb,
        IPad,
        Other
    }
}
