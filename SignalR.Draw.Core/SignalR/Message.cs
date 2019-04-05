using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.Draw.Core.SignalR
{
    public class Message
    {
        /// <summary>
        /// 房间名
        /// 注意：广播=""
        /// </summary>
        public string RoomName { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
    }
}
