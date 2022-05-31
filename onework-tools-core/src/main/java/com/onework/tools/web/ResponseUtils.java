package com.onework.tools.web;

import com.fasterxml.jackson.databind.ObjectMapper;

import javax.servlet.ServletOutputStream;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.core
 * @Description: 描述
 * @date Date : 2022年05月10日 14:36
 */
public class ResponseUtils {

    public static void result(HttpServletResponse response, R r) throws IOException {
        response.setContentType("application/json;charset=UTF-8");
        ObjectMapper objectMapper = new ObjectMapper();
        ServletOutputStream out = response.getOutputStream();
        out.write(objectMapper.writeValueAsString(r).getBytes("UTF-8"));
        out.flush();
        out.close();
    }
}
