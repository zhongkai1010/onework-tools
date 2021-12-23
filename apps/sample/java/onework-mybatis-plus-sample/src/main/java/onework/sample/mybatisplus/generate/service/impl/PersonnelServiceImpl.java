package onework.sample.mybatisplus.generate.service.impl;

import onework.sample.mybatisplus.generate.entity.Personnel;
import onework.sample.mybatisplus.generate.mapper.PersonnelMapper;
import onework.sample.mybatisplus.generate.service.IPersonnelService;
import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import org.springframework.stereotype.Service;

/**
 * <p>
 *  服务实现类
 * </p>
 *
 * @author zhongkai
 * @since 2021-12-23
 */
@Service
public class PersonnelServiceImpl extends ServiceImpl<PersonnelMapper, Personnel> implements IPersonnelService {

}
