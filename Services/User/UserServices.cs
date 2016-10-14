using DataObject.DTO;
using DataObject.ViewModel;
using System.Collections.Generic;
using System;
using Infrastructure.Repositories;

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
            this.userRepositoty =  repositoty;
        }

        public List<UserDTO> FindAll()
        {
            throw new NotImplementedException();
        }

        public List<UserDTO> FindAll(SearchUserConditionModel condition)
        {
            throw new NotImplementedException();
        }
    }
}