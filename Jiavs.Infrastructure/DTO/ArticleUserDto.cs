﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Jiavs.Infrastructure.DTO
{
    public class ArticleUserDto
    {
        public uint Id { get; set; }
        /// <summary>
        /// 用户名，用于登录
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegisterTime { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// 上次更新时间
        /// </summary>
        public DateTime? LastUpdateTime { get; set; }
        /// <summary>
        /// 学校
        /// </summary>
        public string School { get; set; }
        /// <summary>
        /// 微信号
        /// </summary>
        public string WeChat { get; set; }
        /// <summary>
        /// QQ号码
        /// </summary>
        public string QQ { get; set; }
        /// <summary>
        /// 用户等级
        /// </summary>
        public short Level { get; set; }
        /// <summary>
        /// 积分
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// 用户描述
        /// </summary>
        public string Description { get; set; }
    }
}
