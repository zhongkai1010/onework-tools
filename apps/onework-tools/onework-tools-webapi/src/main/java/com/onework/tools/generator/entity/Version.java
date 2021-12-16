package com.onework.tools.generator.entity;

import com.baomidou.mybatisplus.annotation.TableField;
import com.baomidou.mybatisplus.annotation.TableName;
import java.io.Serializable;
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
 * @since 2021-12-16
 */
@Getter
@Setter
@Accessors(chain = true)
@TableName("version")
@Schema(name = "Version对象", description = "")
public class Version implements Serializable {

    private static final long serialVersionUID = 1L;

    @TableField("description")
    private String description;


}
