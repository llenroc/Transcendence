using System;
using System.Collections.Generic;
using TranscendenceChat.ServiceBusShared.Entities;

namespace TranscendenceChat.WorkerRole.SocketServer.Domain
{
    public interface IGroupChatsRepository
    {
        GroupChat GetChat(Guid id);

        void UpdateOrCreateGroup(GroupChat chat);

        List<Guid> GetGroupsForUser(long userId);

        void AddGroupToUser(long userId, Guid groupId);

        void RemoveGroupFromUser(long userId, Guid groupId);
    }
}
