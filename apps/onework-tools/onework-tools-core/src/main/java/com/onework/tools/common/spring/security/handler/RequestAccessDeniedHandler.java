package com.onework.tools.common.spring.security.handler;

import com.onework.tools.web.R;
import com.onework.tools.web.ResponseUtils;
import lombok.extern.slf4j.Slf4j;
import org.springframework.security.access.AccessDeniedException;
import org.springframework.security.web.access.AccessDeniedHandler;
import org.springframework.stereotype.Component;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

/**
 * 当认证后的用户访问受保护的资源时，权限不够，则会进入这个处理器
 * @author Administrator
 */
@Component
@Slf4j
public class RequestAccessDeniedHandler implements AccessDeniedHandler {
    @Override
    public void handle(HttpServletRequest request, HttpServletResponse response,
        AccessDeniedException accessDeniedException) throws IOException {

        log.error(accessDeniedException.getMessage());

        ResponseUtils.result(response, new R().forbidden("not permission"));
    }
}