using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer.EF;
using DomainLayer.Models;

namespace DataAccesLayer.Repositories
{
    /// <summary>
    /// To be implemented
    /// </summary>
    public class FriendRepository : Repository, IFriendRepository
    {
        public FriendRepository(EthereumBettingContext context) : base(context)
        {

        }
        public bool AddFriend(Friend friend)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddFriendAsync(Friend friend)
        {
            throw new NotImplementedException();
        }

        public bool RemoveFriend(Friend friend)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveFriendAsync(Friend friend)
        {
            throw new NotImplementedException();
        }
    }
}
