using System;
using System.Collections.Generic;
using System.Linq;
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
            //throw new NotImplementedException
            Context.Friends.Add(friend);
            Context.SaveChanges();
            return true;
        }

        public Task<bool> AddFriendAsync(Friend friend)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Friend> GetFriends(string userId)
        {
            var u = Context.Users.Find(userId);

            return u.Friends.ToArray();
        }

        public Task<IEnumerable<Friend>> GetFriendsAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveFriend(Friend friend)
        {
            Context.Friends.Remove(friend);
            Context.SaveChanges();
            return true;
        }

        public Task<bool> RemoveFriendAsync(Friend friend)
        {
            throw new NotImplementedException();
        }
    }
}
