package com.onework.tools.component.spring.security;

import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.stereotype.Component;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.common.spring.security
 * @Description: 描述
 * @date Date : 2022年05月10日 16:57
 */
@Component
public class JwtTokenUserDetailsService implements UserDetailsService {

    @Override
    public UserDetails loadUserByUsername(String username) throws UsernameNotFoundException {
        SecurityUser securityUser = new SecurityUser();
        securityUser.setUsername("onework");
        securityUser.setPassword(new BCryptPasswordEncoder().encode("123456"));

        return securityUser;
    }
}
