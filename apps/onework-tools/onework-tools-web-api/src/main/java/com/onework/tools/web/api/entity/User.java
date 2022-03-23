package com.onework.tools.web.api.entity;

import com.baomidou.mybatisplus.annotation.FieldFill;
import com.baomidou.mybatisplus.annotation.IdType;
import com.baomidou.mybatisplus.annotation.TableField;
import com.baomidou.mybatisplus.annotation.TableId;
import com.baomidou.mybatisplus.annotation.TableLogic;
import com.baomidou.mybatisplus.annotation.TableName;
import com.onework.tools.common.domain.BaseEntity;
import java.io.Serializable;
import java.time.LocalDateTime;
import io.swagger.v3.oas.annotations.media.Schema;
import lombok.Getter;
import lombok.Setter;
import lombok.experimental.Accessors;

/**
 * <p>
 * 
 * </p>
 *
 * @author 钟凯
 * @since 2022-03-23
 */
@Getter
@Setter
@Accessors(chain = true)
@TableName("ow_users")
@Schema(name = "User对象", description = "")
public class User extends BaseEntity {

    private static final long serialVersionUID = 1L;

    @Schema(description = "唯一值，不重复")
    @TableId(value = "uid", type = IdType.ASSIGN_ID)
    private String uid;

    @Schema(description = "系统uid")
    @TableField("system_uid")
    private String systemUid;

    @Schema(description = "模块uid")
    @TableField("module_uid")
    private String moduleUid;

    @TableField(value = "created_at", fill = FieldFill.INSERT)
    private LocalDateTime createdAt;

    @TableField(value = "updated_at", fill = FieldFill.INSERT_UPDATE)
    private LocalDateTime updatedAt;

    @TableField(value = "deleted_at", fill = FieldFill.DEFAULT)
    @TableLogic
    private LocalDateTime deletedAt;


}
