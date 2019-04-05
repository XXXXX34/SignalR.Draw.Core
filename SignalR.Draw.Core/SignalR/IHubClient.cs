using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.Draw.Core.SignalR
{
    public interface IHubClient
    {
        /// <summary>
        /// 发送消息到客户端
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task ReceiveAsync(Message message);
    }
}
