package com.onework.tools.webapi.controller;

import com.onework.tools.core.JwtUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.web.bind.annotation.RestController;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.webapi.controller
 * @Description: 描述
 * @date Date : 2022年05月10日 9:13
 */
@RestController
public class AccountController {

    @Autowired
    private JwtUtils jwtUtils;

    @Autowired
    private AuthenticationManager authenticationManager;


}
