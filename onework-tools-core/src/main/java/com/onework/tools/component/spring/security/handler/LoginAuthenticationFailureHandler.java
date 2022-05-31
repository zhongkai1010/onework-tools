package com.onework.tools.component.spring.security.handler;

import com.onework.tools.web.R;
import com.onework.tools.web.ResponseUtils;
import lombok.extern.slf4j.Slf4j;
import org.springframework.security.core.AuthenticationException;
import org.springframework.security.web.authentication.AuthenticationFailureHandler;
import org.springframework.stereotype.Component;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.common.spring.scurity.handler
 * @Description: 描述
 * @date Date : 2022年05月10日 14:13
 */
@Component
@Slf4j
public class LoginAuthenticationFailureHandler implements AuthenticationFailureHandler {
    /**
     * 登录失败则会被调用
     *
     * @param httpServletRequest
     * @param response
     * @param exception          这个参数是异常信息，可以根据不同的异常类返回不同的提示信息
     * @throws IOException
     */
    @Override
    public void onAuthenticationFailure(HttpServletRequest httpServletRequest, HttpServletResponse response,
        AuthenticationException exception) throws IOException {

        log.error(exception.getMessage());

        ResponseUtils.result(response, new R().forbidden("login failed"));
    }
}