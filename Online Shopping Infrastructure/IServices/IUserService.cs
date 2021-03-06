using Online_Shopping_Domain.DTO;
using Online_Shopping_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shopping_Infrastructure.IServices
{
   public interface IUserService
    {
        void Login(LoginUserDTO loginUserDTO);
        IEnumerable<User> GetAll();
        User GetById(Guid id);
        User Create(User user);
        void Update(User user);
        void Delete(Guid id);
    }
}
