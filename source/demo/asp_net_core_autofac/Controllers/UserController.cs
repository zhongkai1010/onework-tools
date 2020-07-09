using System;
using Microsoft.AspNetCore.Mvc;
using OneWork.Server.Base;
using OneWork.Server.Repository;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace OneWork.Controllers
{
    /// <summary>
    ///
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        private IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="mapper"></param>
        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual IEnumerable<User> Get()
        {
            return _userRepository.GetQueryable().ToList();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual User Post(User user)
        {

            _userRepository.Insert(user);
            return user;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public virtual User Put(User user)
        {
            IQueryable<User> queryable = _userRepository.GetQueryable();
            User local = queryable.FirstOrDefault(t => t.Id == user.Id);
            if (local == null)
            {
                throw new ArgumentException("该用户不存在，请重新操作。");
            }
            local = _mapper.Map<User>(user);
            _userRepository.Update(local);
            return local;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="user"></param>
        [HttpDelete]
        public virtual void Delete(User user)
        {
            _userRepository.Delete(user);
        }
    }
}