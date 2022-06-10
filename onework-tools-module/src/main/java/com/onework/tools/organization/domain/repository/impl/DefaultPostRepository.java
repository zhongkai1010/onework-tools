package com.onework.tools.organization.domain.repository.impl;

import com.onework.tools.organization.domain.repository.PostRepository;
import com.onework.tools.organization.domain.vo.PostVo;
import org.springframework.stereotype.Repository;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.organization.domain.repository.impl
 * @Description: 描述
 * @date Date : 2022年06月10日 16:49
 */
@Repository
public class DefaultPostRepository implements PostRepository {
    @Override
    public void deletePostByOrganization(String organizationId) {

    }

    @Override
    public void addPost(PostVo post) {

    }

    @Override
    public PostVo getPost(String organizationId, String name) {
        return null;
    }

    @Override
    public PostVo getPost(String uid) {
        return null;
    }

    @Override
    public void updatePost(PostVo post) {

    }

    @Override
    public void deletePost(String postId) {

    }
}
