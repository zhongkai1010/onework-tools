package com.onework.tools.file.domain.event;

import com.onework.tools.file.domain.vo.FileCategoryVo;
import lombok.Getter;
import org.springframework.context.ApplicationEvent;

import java.time.Clock;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.file.domain
 * @Description: 描述
 * @date Date : 2022年05月26日 14:49
 */
public class FileCategoryEvent extends ApplicationEvent {

    @Getter
    private FileCategoryVo fileCategory;

    public FileCategoryEvent(Object source, FileCategoryVo fileCategory) {
        super(source);
        this.fileCategory = fileCategory;
    }

    public FileCategoryEvent(Object source, Clock clock, FileCategoryVo fileCategory) {
        super(source, clock);
        this.fileCategory = fileCategory;
    }

    public FileCategoryEvent(Object source) {
        super(source);

    }
}
