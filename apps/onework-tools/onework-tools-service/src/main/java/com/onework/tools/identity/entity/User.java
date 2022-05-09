package com.onework.tools.identity.entity;

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
 * @since 2022-05-09
 */
@Getter
@Setter
@Accessors(chain = true)
@TableName("ow_users")
public class User implements Serializable {

    private static final long serialVersionUID = 1L;

    /**
     * 唯一值，不重复
     */
    @TableId(value = "uid", type = IdType.ASSIGN_ID)
    private String uid;

    /**
     * 系统uid
     */
    @TableField("username")
    private String username;

    /**
     * 模块uid
     */
    @TableField("display_name")
    private String displayName;

    @TableField("sex")
    private Integer sex;

    @TableField("birthday")
    private LocalDateTime birthday;

    @TableField("mail")
    private LocalDateTime mail;

    @TableField("phone")
    private String phone;

    @TableField("`password`")
    private String password;

    @TableField("enable_state")
    private Boolean enableState;

    @TableField("active_state")
    private Boolean activeState;

    @TableField("last_login_date")
    private LocalDateTime lastLoginDate;

    @TableField(value = "created_at", fill = FieldFill.INSERT)
    private LocalDateTime createdAt;

    @TableField(value = "updated_at", fill = FieldFill.INSERT_UPDATE)
    private LocalDateTime updatedAt;

    @TableField(value = "deleted_at", fill = FieldFill.DEFAULT)
    @TableLogic
    private LocalDateTime deletedAt;


}
