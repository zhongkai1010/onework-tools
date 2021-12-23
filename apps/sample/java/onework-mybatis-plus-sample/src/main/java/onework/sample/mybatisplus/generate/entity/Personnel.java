package onework.sample.mybatisplus.generate.entity;

import com.baomidou.mybatisplus.annotation.IdType;
import com.baomidou.mybatisplus.annotation.TableField;
import com.baomidou.mybatisplus.annotation.TableId;
import com.baomidou.mybatisplus.annotation.TableName;
import io.swagger.v3.oas.annotations.media.Schema;
import lombok.Getter;
import lombok.Setter;

import java.io.Serializable;

/**
 * <p>
 *
 * </p>
 *
 * @author zhongkai
 * @since 2021-12-23
 */
@Getter @Setter @TableName("personnels") @Schema(name = "Personnel对象", description = "") public class Personnel
    implements Serializable {

    private static final long serialVersionUID = 1L;

    @Schema(description = "主键ID") @TableId(value = "id", type = IdType.ASSIGN_ID) private Long id;

    @Schema(description = "姓名") @TableField("`name`") private String name;

    @Schema(description = "年龄") @TableField("age") private Integer age;

    @Schema(description = "邮箱") @TableField("email") private String email;

    @Override public String toString() {
        return "Personnel{" + "id=" + this.id + ", name='" + this.name + '\'' + ", age=" + this.age
            + ", email='" + this.email + '\'' + '}';
    }
}