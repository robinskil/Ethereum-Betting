using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Repositories
{
    public interface IFriendRepository
    {
        bool AddFriend(Friend friend);
        bool RemoveFriend(Friend friend);
        Task<bool> AddFriendAsync(Friend friend);
        Task<bool> RemoveFriendAsync(Friend friend);
    }
}
