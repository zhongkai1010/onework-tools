using Microsoft.AspNetCore.Mvc;
using OneWork.Server.Base;
using OneWork.Server.Repository;
using System.Collections.Generic;
using System.Linq;

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

        /// <summary>
        ///
        /// </summary>
        /// <param name="userRepository"></param>
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
            _userRepository.Update(user);
            return user;
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