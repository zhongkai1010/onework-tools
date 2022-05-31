package com.onework.tools.component.spring.security.handler;

import com.onework.tools.web.R;
import com.onework.tools.web.ResponseUtils;
import lombok.extern.slf4j.Slf4j;
import org.springframework.security.core.AuthenticationException;
import org.springframework.security.web.AuthenticationEntryPoint;
import org.springframework.stereotype.Component;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

/**
 * 用户访问受保护的资源，但是用户没有通过认证则会进入这个处理器
 * @author Administrator
 */
@Component
@Slf4j
public class EntryPointUnauthorizedHandler implements AuthenticationEntryPoint {

    @Override
    public void commence(HttpServletRequest request, HttpServletResponse response,
        AuthenticationException authException) throws IOException {

        log.error(authException.getMessage());

        ResponseUtils.result(response, new R().forbidden("not login"));
    }
}