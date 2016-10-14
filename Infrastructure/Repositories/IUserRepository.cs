using DataObject.DTO;
using DataObject.ViewModel;
using Infrastructure.Database;
using Infrastructure.Utils;
using System;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public interface IUserRepository
    {
        List<UserDTO> FindAll();

        List<UserDTO> FindAll(SearchUserConditionModel condition);
    }

    public class UserRepository : IUserRepository
    {
        private static readonly string GET_LIST_USER_SP = "@uspGetListUser";

        public List<UserDTO> FindAll()
        {
            List<UserDTO> list = null;

            using (AdoContext context = new AdoContext())
            {
                list = EntityHelper<UserDTO>.GetListObject(context.GetData(GET_LIST_USER_SP));
            }

            return list;
        }

        public List<UserDTO> FindAll(SearchUserConditionModel condition)
        {
            throw new NotImplementedException();
        }
    }
}