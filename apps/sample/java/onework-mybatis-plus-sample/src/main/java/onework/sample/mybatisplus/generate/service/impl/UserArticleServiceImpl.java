package onework.sample.mybatisplus.generate.service.impl;

import onework.sample.mybatisplus.generate.entity.UserArticle;
import onework.sample.mybatisplus.generate.mapper.UserArticleMapper;
import onework.sample.mybatisplus.generate.service.IUserArticleService;
import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import org.springframework.stereotype.Service;

/**
 * <p>
 *  服务实现类
 * </p>
 *
 * @author zhongkai
 * @since 2021-12-24
 */
@Service
public class UserArticleServiceImpl extends ServiceImpl<UserArticleMapper, UserArticle> implements IUserArticleService {

}
