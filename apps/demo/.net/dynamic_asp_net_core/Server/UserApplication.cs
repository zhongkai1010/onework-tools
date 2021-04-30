using System.Collections.Generic;

namespace dynamic_asp_net_core.Server
{
    public class UserApplication
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public UserDto Insert(UserDto input)
        {
            return new UserDto();
        }

        public List<UserDto> Get()
        {
            return  new List<UserDto>
            {
                new UserDto{}
            };
        }

    }
}
