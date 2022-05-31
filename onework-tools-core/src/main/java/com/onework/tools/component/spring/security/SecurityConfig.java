package com.onework.tools.component.spring.security;

import com.onework.tools.component.spring.security.filter.TokenAuthenticationFilter;
import com.onework.tools.component.spring.security.handler.EntryPointUnauthorizedHandler;
import com.onework.tools.component.spring.security.handler.RequestAccessDeniedHandler;
import com.onework.tools.component.spring.security.handler.UserLogoutSuccessHandler;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.http.HttpMethod;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.config.annotation.method.configuration.EnableGlobalMethodSecurity;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
import org.springframework.security.config.annotation.web.configuration.WebSecurityConfigurerAdapter;
import org.springframework.security.config.http.SessionCreationPolicy;
import org.springframework.security.web.authentication.UsernamePasswordAuthenticationFilter;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.common.spring
 * @Description: 描述
 * @date Date : 2022年05月10日 9:42
 */
@Configuration
@EnableWebSecurity
@EnableGlobalMethodSecurity(prePostEnabled = true, securedEnabled = true)
public class SecurityConfig extends WebSecurityConfigurerAdapter {

    /**
     *
     */
    @Autowired
    private  RequestAccessDeniedHandler requestAccessDeniedHandler;

    /**
     *
     */
    @Autowired
    private EntryPointUnauthorizedHandler entryPointUnauthorizedHandler;

    /**
     *
     */
    @Autowired
    private  JwtAuthenticationSecurityConfig jwtAuthenticationSecurityConfig;

    /**
     *
     */
    @Autowired
    private UserLogoutSuccessHandler userLogoutSuccessHandler;


    @Override
    protected void configure(HttpSecurity httpSecurity) throws Exception {

        // @formatter:off
        httpSecurity
            //禁用表单登录，前后端分离用不上
            .formLogin()
            .disable()
            //应用登录过滤器的配置，配置分离
            .apply(jwtAuthenticationSecurityConfig)
            .and()
            // 过滤请求
            .authorizeRequests()
            // 排除登录验证
            .antMatchers("/account/login").anonymous()
            // 排除静态文件
            .antMatchers(HttpMethod.GET,
                "/*.html",
                "/**/*.html",
                "/**/*.css",
                "/**/*.js"
            ).permitAll()
            // 排除swagger ui
            .antMatchers("/**/api-docs/**").permitAll()
            // 除上面外的所有请求全部需要鉴权认证
            .anyRequest()
            .authenticated()
            .and()
            //处理异常情况：认证失败和权限不足
            .exceptionHandling()
            //认证未通过，不允许访问异常处理器
            .authenticationEntryPoint(entryPointUnauthorizedHandler)
            //认证通过，但是没权限处理器
            .accessDeniedHandler(requestAccessDeniedHandler)
            .and()
            //退出处理
            .logout()
            .logoutSuccessHandler(userLogoutSuccessHandler)
            .and()
            //基于token，所以不需要session
            .sessionManagement()
            .sessionCreationPolicy(SessionCreationPolicy.STATELESS)
            .and()
            //将TOKEN校验过滤器配置到过滤器链中，否则不生效，放到UsernamePasswordAuthenticationFilter之前
            .addFilterBefore(authenticationTokenFilterBean(),UsernamePasswordAuthenticationFilter.class)
            // 关闭csrf
            .csrf()
            .disable();

        // @formatter:on
    }

    /**
     * 自定义的Jwt Token校验过滤器
     *
     * @return
     */
    @Bean
    public TokenAuthenticationFilter authenticationTokenFilterBean() {
        return new TokenAuthenticationFilter();
    }


    @Bean
    @Override
    protected AuthenticationManager authenticationManager() throws Exception {
        return super.authenticationManager();
    }


}
