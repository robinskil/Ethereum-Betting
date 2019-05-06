using InteractorLayer.AuthenticationService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InteractorLayer.FriendInteractor
{
    public interface IFriendInteractor
    {
        Task AddFriend(string addressUser, string addressFriend);
        Task RemoveFriend(string addressUser, string addressFriend);
    }
}
