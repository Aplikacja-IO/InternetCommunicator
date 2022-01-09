using InternetCommunicator.Domain.Models;
using InternetMessengerApp.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetMessengerApp.Models
{
    public class UserDashboardModel
    {
        private int userId;
        private string userToken;
        public UserDashboardModel(int _userId, string _userToken)
        {
            userId = _userId;
            userToken = _userToken;
        }
        public List<Group> MyGroups { get; set; }
        public async Task GetAllUserGroups()
        {
            var server = new ServerAPIServices();
            MyGroups = await server.GetAllUserGroupsAsync(userId, userToken);
        }
        public string test = "asasa";
    }
}
