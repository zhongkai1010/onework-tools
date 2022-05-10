package com.onework.tools.webapi.controller.identity;

import com.onework.tools.identity.entity.User;
import com.onework.tools.web.AbstractCrudController;
import org.springframework.web.bind.annotation.RestController;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.webapi.controller
 * @Description: 描述
 * @date Date : 2022年05月09日 10:02
 */
@RestController("/user")
public class UserController extends AbstractCrudController<User> {

}
