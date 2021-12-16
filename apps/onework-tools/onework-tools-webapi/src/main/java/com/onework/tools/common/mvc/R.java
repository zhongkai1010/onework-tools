package com.onework.tools.common.mvc;

import java.io.Serializable;

import org.apache.commons.lang3.StringUtils;
import org.springframework.http.HttpStatus;

import io.swagger.v3.oas.annotations.media.Schema;
import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
@Schema(description = "Response对象")
public class R<T> implements Serializable {
    private static final long serialVersionUID = 1L;

    @Schema(description = "消息code", required = true)
    private int code;
    @Schema(description = "消息提示内容")
    private String message;
    @Schema(description = "消息实体")
    private T data;

    public R<T> code(int code) {
        this.code = code;
        return this;
    }

    public R<T> code(HttpStatus status) {
        this.code = status.value();
        return this;
    }

    public R<T> message(String message) {
        this.message = message;
        return this;
    }

    public R<T> data(T data) {
        this.data = data;
        return this;
    }

    public R<T> success() {
        this.code(0);
        this.message(HttpStatus.OK.getReasonPhrase());
        return this;
    }


    /**
     * 未授权返回结果
     */
    public R<T> forbidden(String message) {
        this.code(HttpStatus.FORBIDDEN);
        if (StringUtils.isNotBlank(message)) {
            this.message(message);
        } else {
            this.message(HttpStatus.FORBIDDEN.getReasonPhrase());
        }
        return this;
    }

    /**
     * 未登录返回结果
     */
    public R<T> unauthorized(String message) {
        this.code(HttpStatus.UNAUTHORIZED);
        this.message(HttpStatus.UNAUTHORIZED.getReasonPhrase());
        return this;
    }

    /**
     * 校验失败
     *
     * @param message
     * @return
     */
    public R<T> validateFailed(String message) {
        this.code(HttpStatus.NOT_FOUND);
        this.message(message);
        return this;
    }

}
