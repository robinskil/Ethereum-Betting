using InteractorLayer.AuthenticationService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InteractorLayer.FriendInteractor
{
    public interface IFriendInteractor
    {
        bool AddFriend(string addressUser, string addressFriend);
        bool RemoveFriend(string addressUser, string addressFriend);
        Task<bool> AddFriendAsync(string addressUser, string addressFriend);
        Task<bool> RemoveFriendAsync(string addressUser, string addressFriend);
    }
}
