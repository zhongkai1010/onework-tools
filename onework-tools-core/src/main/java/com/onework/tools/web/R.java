package com.onework.tools.web;

import com.baomidou.mybatisplus.core.toolkit.StringUtils;
import io.swagger.v3.oas.annotations.media.Schema;
import lombok.Getter;
import lombok.Setter;
import org.springframework.http.HttpStatus;

import java.io.Serializable;

/**
 * @author ZK
 * @description 请求返回结果
 * @date 2021/12/16 20:43
 */
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
        code = status.value();
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
        code(0);
        message(HttpStatus.OK.getReasonPhrase());
        return this;
    }

    /**
     * 未授权返回结果
     */
    public R<T> forbidden(String message) {
        code(HttpStatus.FORBIDDEN);
        if (StringUtils.isNotBlank(message)) {
            message(message);
        } else {
            message(HttpStatus.FORBIDDEN.getReasonPhrase());
        }
        return this;
    }

    /**
     * 未登录返回结果
     */
    public R<T> unauthorized(String message) {
        code(HttpStatus.UNAUTHORIZED);
        message(HttpStatus.UNAUTHORIZED.getReasonPhrase());
        return this;
    }

    /**
     * @param message:
     * @return R<T>
     * @author ZK
     * @description 验证失败
     * @date 2021/12/16 20:41
     */
    public R<T> validateFailed(String message) {
        code(HttpStatus.NOT_FOUND);
        message(message);
        return this;
    }

}
