package com.onework.tools.webapi.entity;

import java.io.Serializable;
import lombok.Getter;
import lombok.Setter;
import lombok.experimental.Accessors;

/**
 * <p>
 * 
 * </p>
 *
 * @author 钟凯
 * @since 2021-12-06
 */
@Getter
@Setter
@Accessors(chain = true)
public class Version implements Serializable {

    private static final long serialVersionUID = 1L;

    private String description;


}
