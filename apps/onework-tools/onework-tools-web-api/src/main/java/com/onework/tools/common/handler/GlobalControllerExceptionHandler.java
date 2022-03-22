package com.onework.tools.common.handler;

import com.onework.tools.common.web.R;
import com.onework.tools.common.web.WebApiException;
import org.springframework.core.convert.ConversionFailedException;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.bind.annotation.ResponseStatus;
import org.springframework.web.bind.annotation.RestControllerAdvice;

/**
 * OpenApi会解析@RestControllerAdvice注解的类，在response中会显示这些异常定义：400/404/500
 *
 * @author kevin
 */
@RestControllerAdvice
public class GlobalControllerExceptionHandler {

    @ExceptionHandler(ConversionFailedException.class)
    @ResponseStatus(HttpStatus.BAD_REQUEST)
    public R handleConnversion(RuntimeException ex) {
        R resp = new R().code(HttpStatus.BAD_REQUEST).message(ex.getMessage());
        return resp;
    }

    @ExceptionHandler(Exception.class)
    @ResponseStatus(HttpStatus.INTERNAL_SERVER_ERROR)
    public R handleException(Exception ex) {
        R resp = new R().code(HttpStatus.INTERNAL_SERVER_ERROR).message(ex.getMessage());
        return resp;
    }

    @ExceptionHandler(WebApiException.class)
    @ResponseStatus(HttpStatus.NOT_FOUND)
    public R handleBookNotFound(RuntimeException ex) {
        R resp = new R().code(HttpStatus.NOT_FOUND).message(ex.getMessage());
        return resp;
    }
}
