using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InteractorLayer.FriendInteractor
{
    public class FriendInteractor : IFriendInteractor
    {
        public FriendInteractor()
        {

        }
        public Task AddFriend(string addressUser, string addressFriend)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFriend(string addressUser, string addressFriend)
        {
            throw new NotImplementedException();
        }
    }
}
