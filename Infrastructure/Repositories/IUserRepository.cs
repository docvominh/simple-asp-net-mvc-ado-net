using DataObject.DTO;
using DataObject.ViewModel;
using Infrastructure.Database;
using Infrastructure.Utils;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Infrastructure.Repositories
{
    public interface IUserRepository
    {
        List<UserDTO> FindAll();

        List<UserDTO> FindAll(SearchUserConditionModel condition);
    }

    public class UserRepository : IUserRepository
    {
        private ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Input parameter
        /// @userId VARCHAR,
        /// @userName VARCHAR,
        /// @email VARCHAR,
        /// @active BIT
        /// </summary>
        private static readonly string GET_LIST_USER_SP = @"uspGetListUser";

        public List<UserDTO> FindAll()
        {
            List<UserDTO> list = null;
            List<SqlParameter> listParam = new List<SqlParameter>();
            listParam.Add(new SqlParameter("@userId", DBNull.Value));
            listParam.Add(new SqlParameter("@userName", DBNull.Value));
            listParam.Add(new SqlParameter("@email", DBNull.Value));
            listParam.Add(new SqlParameter("@active", true));

            using (AdoContext context = new AdoContext())
            {
                list = EntityHelper<UserDTO>.GetListObject(context.GetData(GET_LIST_USER_SP, listParam));
            }

            log.Info("MY LOG : " + list.Count);
            return list;
        }

        public List<UserDTO> FindAll(SearchUserConditionModel condition)
        {
            throw new NotImplementedException();
        }
    }
}