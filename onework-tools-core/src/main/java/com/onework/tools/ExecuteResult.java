package com.onework.tools;

import lombok.Getter;

/**
 * @param <TData>
 * @author zhongkai
 */
public class ExecuteResult<TData> {

    public final static Boolean SUCCESS = true;

    public final static Boolean FAIL = false;

    @Getter
    private boolean result;

    @Getter
    private TData data;

    public ExecuteResult() {

        result = false;
    }

    public ExecuteResult(Boolean result) {

        this.result = result;
    }

    public ExecuteResult<TData> ok() {
        result = true;
        return this;
    }

    public ExecuteResult<TData> ok(TData data) {
        result = true;
        this.data = data;
        return this;
    }

    public ExecuteResult<TData> fail() {
        result = false;
        return this;
    }

    public <T extends Throwable> ExecuteResult<TData> fail(T t) {
        result = false;
        return this;
    }

    public static <T> ExecuteResult<T> success() {
        ExecuteResult<T> executeResult = new ExecuteResult<>();
        return executeResult.ok();
    }

    public static <T> ExecuteResult<T> success(T data) {
        ExecuteResult<T> executeResult = new ExecuteResult<>();
        return executeResult.ok(data);
    }

    public static <T> ExecuteResult<T> failure() {
        ExecuteResult<T> executeResult = new ExecuteResult<>();
        return executeResult.fail();
    }

    public static <E, T extends Throwable> ExecuteResult<E> failure(T t) {
        ExecuteResult<E> executeResult = new ExecuteResult<>();
        return executeResult.fail(t);
    }

    public Boolean compare(Boolean result) {
        return this.result == result;
    }
}
