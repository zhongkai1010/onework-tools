package com.onework.tools.core;

/**
 * @projectName: onework-tools
 * @package: com.onework.tools.core
 * @className: ExecuteResult
 * @author: 钟凯
 * @description: 描述
 * @date: 2022/3/31 21:47
 * @version: 1.0
 */
public class ExecuteResult {

    public final static ExecuteResult SUCCESS = new ExecuteResult(true);

    public final static ExecuteResult FAIL = new ExecuteResult(false);

    private boolean result;

    public ExecuteResult() {

        result = false;
    }

    public ExecuteResult(Boolean result) {

        this.result = result;
    }

    public ExecuteResult ok() {
        result = true;
        return this;
    }

    public ExecuteResult fail() {
        result = false;
        return this;
    }

    public <T extends Throwable> ExecuteResult fail(T t) {
        result = false;
        return this;
    }

    public boolean equals(ExecuteResult o) {
        return o.result == result;
    }
}