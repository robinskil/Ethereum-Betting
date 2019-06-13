using DataAccesLayer.EF;
using DataAccesLayer.Repositories;
using DomainLayer.Models;
using Nethereum.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InteractorLayer.FriendInteractor
{
    public class FriendInteractor : IFriendInteractor
    {
        IFriendRepository Repository { get; }
        public FriendInteractor(EthereumBettingContext context)
        {
            Repository = new FriendRepository(context);
        }
        public bool AddFriend(string addressUser, string addressFriend)
        {
            if (AddressUtil.Current.IsValidAddressLength(addressUser) && AddressUtil.Current.IsValidAddressLength(addressFriend))
            {
                Friend relation = new Friend()
                {
                    UserIdAddress = addressUser,
                    UserFriendAddress = addressFriend
                };
                return Repository.AddFriend(relation);
            }
            return false;
        }

        public Task<bool> AddFriendAsync(string addressUser, string addressFriend)
        {
            throw new NotImplementedException();
        }

        public bool RemoveFriend(string addressUser, string addressFriend)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveFriendAsync(string addressUser, string addressFriend)
        {
            throw new NotImplementedException();
        }
    }
}
