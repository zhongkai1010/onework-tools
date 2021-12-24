package onework.sample.mybatisplus.generate.mapper;

import com.baomidou.mybatisplus.core.mapper.BaseMapper;
import onework.sample.mybatisplus.generate.entity.UserArticle;

/**
 * <p>
 * Mapper 接口
 * </p>
 *
 * @author zhongkai
 * @since 2021-12-24
 */
public interface UserArticleMapper extends BaseMapper<UserArticle> {
    /**
     * 删除所有记录
     *
     * @return 影响记录数
     */
    long deleteAll();
}
