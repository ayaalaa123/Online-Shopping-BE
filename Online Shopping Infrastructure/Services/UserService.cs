using Online_Shopping_Domain.Entities;
using Online_Shopping_Infrastructure.Helpers;
using Online_Shopping_Infrastructure.Interfaces;
using Online_Shopping_Infrastructure.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Online_Shopping_Infrastructure.Services
{
    public class UserService :IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<User> _userRepository;
        public UserService(IUnitOfWork unitOfWork, IGenericRepository<User> userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;

        }

        public User Create(User user)
        {
            // validation
            if (string.IsNullOrWhiteSpace(user.Password))
                throw new CustomException("Password is required");

            if (_userRepository.Get(a => a.Email == user.Email).FirstOrDefault() != null)
                throw new CustomException("Username \"" + user.Email + "\" is already taken");

            _userRepository.Add(user);
            _unitOfWork.Commit();
            return user;
        }

        public void Delete(Guid id)
        {
            var user = _userRepository.Get(a => a.Id == id).FirstOrDefault();
            if (user != null)
            {
                _userRepository.Delete(user);
                _unitOfWork.Commit();
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(Guid id)
        {
            return _userRepository.Get(a => a.Id == id).FirstOrDefault();
        }

        public void Update(User user)
        {
            var ExistingUser = _userRepository.Get(a=>a.Id== user.Id).FirstOrDefault();

            if (ExistingUser == null)
                throw new CustomException("User not found");

            // update Email if it has changed
            if (!string.IsNullOrWhiteSpace(user.Email) && ExistingUser.Email != user.Email)
            {
                // throw error if the new Email is already taken
                if (_userRepository.Get(a => a.Email == user.Email).FirstOrDefault() != null)
                    throw new CustomException("Username " + user.Email + " is already taken");

                ExistingUser.Email = user.Email;
            }

            // update user properties if provided
            if (!string.IsNullOrWhiteSpace(user.MobileNumber))
                ExistingUser.MobileNumber = user.MobileNumber;

            if (!string.IsNullOrWhiteSpace(user.FullName))
                ExistingUser.FullName = user.FullName;

            // update password if provided
            if (!string.IsNullOrWhiteSpace(user.Password))
            {
                ExistingUser.Password = user.Password;
                
            }

            _userRepository.Update(user);
            _unitOfWork.Commit();

        }
    }
}
