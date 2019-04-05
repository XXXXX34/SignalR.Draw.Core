using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.Draw.Core.SignalR
{
    public class ChatHub : Hub<IHubClient>
    {
        private const string BROADCAST = "broadcast";

        /// <summary>
        /// client调用发送
        /// </summary>
        /// <param name="roomName"></param>
        /// <param name="userName"></param>
        /// <param name="content"></param>
        /// <returns></returns>

        public async Task Send(string roomName, string userName, string content)
        {
            await SendToClient(roomName, userName, content);
        }

        /// <summary>
        /// 连接成功
        /// </summary>
        /// <returns></returns>
        public override Task OnConnectedAsync()
        {
            var connectionId = Context.ConnectionId;
            return base.OnConnectedAsync();
        }

        /// <summary>
        /// 失去连接
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override Task OnDisconnectedAsync(Exception exception)
        {
            //todo
            return base.OnDisconnectedAsync(exception);
        }

        /// <summary>
        /// 进入房间
        /// </summary>
        /// <param name="roomName"></param>
        /// <param name="userName"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public async Task InRoom(string roomName, string userName, string content)
        {
            var connectionId = Context.ConnectionId;
            await Groups.AddToGroupAsync(connectionId, roomName);
            await SendToClient(roomName, userName, content);
        }

        /// <summary>
        /// 离开房间
        /// </summary>
        /// <param name="roomName"></param>
        /// <param name="userName"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public async Task OutRoom(string roomName, string userName, string content)
        {
            var connectionId = Context.ConnectionId;
            await SendToClient(roomName, userName, content);
            await Groups.RemoveFromGroupAsync(connectionId, roomName);
        }

        /// <summary>
        /// 发送到Client
        /// </summary>
        /// <param name="roomName"></param>
        /// <param name="userName"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        private async Task SendToClient(string roomName, string userName, string content)
        {
            if (roomName == BROADCAST)//广播
            {
                await Clients.All.ReceiveAsync(new Message { UserName = userName, RoomName = string.Empty, Content = content });
            }
            else
            {
                await Clients.Groups<IHubClient>(roomName).ReceiveAsync(new Message { UserName = userName, RoomName = roomName, Content = content });
            }
        }
    }
}
