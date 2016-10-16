using DataObject.DTO;
using DataObject.ViewModel;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;

namespace Services.User
{
    public interface IUserServices
    {
        List<UserDTO> FindAll();

        List<UserDTO> FindAll(SearchUserConditionModel condition);
    }

    public class UserServices : IUserServices
    {
        private readonly IUserRepository userRepositoty;

        public UserServices(IUserRepository repositoty)
        {
            this.userRepositoty = repositoty;
        }

        public List<UserDTO> FindAll()
        {
            List<UserDTO> list = null;

            list = userRepositoty.FindAll();

            if (list == null)
            {
                list = new List<UserDTO>();
            }

            return list;
        }

        public List<UserDTO> FindAll(SearchUserConditionModel condition)
        {
            throw new NotImplementedException();
        }
    }
}