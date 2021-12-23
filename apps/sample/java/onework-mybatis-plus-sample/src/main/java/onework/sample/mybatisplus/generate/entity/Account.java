package onework.sample.mybatisplus.generate.entity;

import com.baomidou.mybatisplus.annotation.IdType;
import com.baomidou.mybatisplus.annotation.TableField;
import com.baomidou.mybatisplus.annotation.TableId;
import com.baomidou.mybatisplus.annotation.TableLogic;
import com.baomidou.mybatisplus.annotation.TableName;
import java.io.Serializable;
import java.time.LocalDateTime;
import io.swagger.v3.oas.annotations.media.Schema;
import lombok.Getter;
import lombok.Setter;

/**
 * <p>
 * 
 * </p>
 *
 * @author zhongkai
 * @since 2021-12-23
 */
@Getter
@Setter
@TableName("ow_accounts")
@Schema(name = "Account对象", description = "")
public class Account implements Serializable {

private static final long serialVersionUID = 1L;

        @Schema(description="主键")
                @TableId(value = "uid", type = IdType.ASSIGN_ID)
                private String uid;

        @Schema(description="用户Id")
    @TableField("user_id")
        private String userId;

        @Schema(description="账户类型，密码、微信、QQ")
    @TableField("`type`")
        private String type;

        @Schema(description="数据")
    @TableField("`data`")
        private String data;

        @Schema(description="创建时间")
    @TableField("created_at")
        private LocalDateTime createdAt;

        @Schema(description="修改时间")
    @TableField("updated_at")
        private LocalDateTime updatedAt;

        @Schema(description="删除时间")
    @TableField("deleted_at")
            @TableLogic
private LocalDateTime deletedAt;


    }