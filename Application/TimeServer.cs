﻿using System;
using System.Net;
using NewLife.Net.Sockets;

namespace NewLife.Net.Application
{
    /// <summary>Time服务器</summary>
    public class TimeServer : NetServer
    {
        /// <summary>实例化一个Time服务。向请求者返回1970年1月1日以来的所有秒数</summary>
        public TimeServer()
        {
            // 默认37端口
            Port = 37;

            Name = "Time服务";
        }

        static readonly DateTime STARTTIME = new DateTime(1970, 1, 1);

        /// <summary>已重载。</summary>
        /// <param name="server"></param>
        /// <param name="session"></param>
        protected override void OnAccept(ISocketServer server, ISocketSession session)
        {
            WriteLog("Time {0}", session.Remote);

            TimeSpan ts = DateTime.Now - STARTTIME;
            Int32 s = (Int32)ts.TotalSeconds;
            // 因为要发往网络，这里调整网络字节序
            s = IPAddress.HostToNetworkOrder(s);
            Byte[] buffer = BitConverter.GetBytes(s);
            //Send(e.Socket, buffer, 0, buffer.Length, e.RemoteEndPoint);
            //session.Send(buffer, 0, buffer.Length, e.RemoteEndPoint);
            session.Send(buffer);
        }
    }
}