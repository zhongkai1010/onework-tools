package com.onework.tools.common.spring.security.handler;

import com.onework.tools.core.JwtUtils;
import com.onework.tools.web.R;
import com.onework.tools.web.ResponseUtils;
import lombok.extern.slf4j.Slf4j;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.web.authentication.AuthenticationSuccessHandler;
import org.springframework.stereotype.Component;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

/**
 * 登录成功操作
 *
 * @author Administrator
 */
@Component
@Slf4j
public class LoginAuthenticationSuccessHandler implements AuthenticationSuccessHandler {

    private final JwtUtils jwtTokenUtil;

    public LoginAuthenticationSuccessHandler(JwtUtils jwtTokenUtil) {
        this.jwtTokenUtil = jwtTokenUtil;
    }

    @Override
    public void onAuthenticationSuccess(HttpServletRequest httpServletRequest, HttpServletResponse httpServletResponse,
        Authentication authentication) throws IOException {
        UserDetails userDetails = (UserDetails)authentication.getPrincipal();
        SecurityContextHolder.getContext().setAuthentication(authentication);
        String accessToken = jwtTokenUtil.createToken(userDetails.getUsername());
        ResponseUtils.result(httpServletResponse, new R().data(accessToken).success());
    }
}