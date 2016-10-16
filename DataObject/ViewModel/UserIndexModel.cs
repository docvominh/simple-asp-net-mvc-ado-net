using DataObject.DTO;
using System.Collections.Generic;

namespace DataObject.ViewModel
{
    public class UserIndexModel
    {
        public ICollection<UserDTO> ListUser { get; set; }
        public UserDTO User { get; set; }
    }
}