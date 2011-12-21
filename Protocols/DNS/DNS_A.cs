﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using NewLife.Serialization;

namespace NewLife.Net.Protocols.DNS
{
    /// <summary>A记录</summary>
    public class DNS_A : DNSBase<DNS_A>
    {
        #region 属性
        /// <summary>IP地址</summary>
        public IPAddress Address
        {
            get { return !String.IsNullOrEmpty(DataString) ? IPAddress.Parse(DataString) : null; ; }
            set { DataString = value.ToString(); }
        }
        #endregion

        #region 构造
        /// <summary>构造一个A记录实例</summary>
        public DNS_A()
        {
            Type = DNSQueryType.A;
            Class = DNSQueryClass.IN;
        }
        #endregion
    }
}