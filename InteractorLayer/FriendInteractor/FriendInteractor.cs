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
        IFriendRepository friendRepository { get; }
        public FriendInteractor(EthereumBettingContext context)
        {
            friendRepository = new FriendRepository(context);
        }

        public IEnumerable<Friend> GetFriends(string userId)
        {
            return friendRepository.GetFriends(userId);
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
                return friendRepository.AddFriend(relation);
            }
            return false;
        }

        public Task<bool> AddFriendAsync(string addressUser, string addressFriend)
        {
            throw new NotImplementedException();
        }

        public bool RemoveFriend(string addressUser, string addressFriend)
        {
            if (AddressUtil.Current.IsValidAddressLength(addressUser) && AddressUtil.Current.IsValidAddressLength(addressFriend))
            {
                Friend relation = new Friend()
                {
                    UserIdAddress = addressUser,
                    UserFriendAddress = addressFriend
                };
                return friendRepository.RemoveFriend(relation);
            }
            return false;
        }

        public Task<bool> RemoveFriendAsync(string addressUser, string addressFriend)
        {
            throw new NotImplementedException();
        }
    }
}
