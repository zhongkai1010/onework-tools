package onework.sample.mybatisplus.generate.entity;

import com.baomidou.mybatisplus.annotation.*;
import io.swagger.v3.oas.annotations.media.Schema;
import lombok.Getter;
import lombok.Setter;

import java.io.Serializable;
import java.time.LocalDateTime;

/**
 * <p>
 *
 * </p>
 *
 * @author zhongkai
 * @since 2021-12-24
 */
@Getter @Setter @TableName("ow_user_articles") @Schema(name = "UserArticle对象", description = "")
public class UserArticle implements Serializable {

    private static final long serialVersionUID = 1L;

    @Schema(description = "主键") @TableId(value = "uid", type = IdType.ASSIGN_ID) private String uid;

    @Schema(description = "用户id") @TableField("user_id") private String userId;

    @Schema(description = "标题") @TableField("title") private String title;

    @Schema(description = "内容") @TableField("content") private String content;

    @Schema(description = "创建时间") @TableField(value = "created_at", fill = FieldFill.INSERT) private LocalDateTime
        createdAt;

    @Schema(description = "修改时间") @TableField(value = "updated_at", fill = FieldFill.UPDATE) private LocalDateTime
        updatedAt;

    @Schema(description = "删除时间") @TableField("deleted_at") @TableLogic private LocalDateTime deletedAt;

    @Schema(description = "删除用户") @TableField("deleted_user_id") private String deletedUserId;

    @Override public String toString() {
        return "UserArticle{" + "uid='" + uid + '\'' + ", userId='" + userId + '\'' + ", title='" + title
            + '\''
            + ", content='" + content + '\'' + ", createdAt=" + createdAt + ", updatedAt=" + updatedAt + ", deletedAt="
            + deletedAt + ", deletedUserId='" + deletedUserId + '\'' + '}';
    }
}