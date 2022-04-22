package com.onework.tools.translate.dao.entity;

import com.baomidou.mybatisplus.annotation.FieldFill;
import com.baomidou.mybatisplus.annotation.IdType;
import com.baomidou.mybatisplus.annotation.TableField;
import com.baomidou.mybatisplus.annotation.TableId;
import com.baomidou.mybatisplus.annotation.TableLogic;
import com.baomidou.mybatisplus.annotation.TableName;
import java.io.Serializable;
import java.time.LocalDateTime;
import lombok.Getter;
import lombok.Setter;
import lombok.experimental.Accessors;

/**
 * <p>
 * 
 * </p>
 *
 * @author zhongkai
 * @since 2022-04-22
 */
@Getter
@Setter
@Accessors(chain = true)
@TableName("ow_tool_translations")
public class ToolTranslation implements Serializable {

    private static final long serialVersionUID = 1L;

    /**
     * 唯一值，不重复
     */
    @TableId(value = "uid", type = IdType.ASSIGN_ID)
    private String uid;

    /**
     * 翻译来源，例如：百度
     */
    @TableField("`source`")
    private String source;

    /**
     * 翻译后文本
     */
    @TableField("dst")
    private String dst;

    /**
     * 翻译前的文本
     */
    @TableField("src")
    private String src;

    /**
     * 需要翻译的语言
     */
    @TableField("`from`")
    private String from;

    /**
     * 翻译后的语言
     */
    @TableField("`to`")
    private String to;

    @TableField(value = "created_at", fill = FieldFill.INSERT)
    private LocalDateTime createdAt;

    @TableField(value = "updated_at", fill = FieldFill.INSERT_UPDATE)
    private LocalDateTime updatedAt;

    @TableField(value = "deleted_at", fill = FieldFill.DEFAULT)
    @TableLogic
    private LocalDateTime deletedAt;


}
