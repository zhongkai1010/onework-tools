package com.onework.tools.modularity.organization.domain.repository;

import com.onework.tools.modularity.organization.domain.vo.PostVo;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.modularity.organization.domain.repository
 * @Description: 描述
 * @date Date : 2022年05月26日 17:35
 */
public interface PostRepository {
    void deletePostByOrganization(String organizationId);



    void addPost(PostVo post);

    PostVo getPost(String organizationId, String name);

    PostVo getPost(String uid);

    void updatePost(PostVo post);

    void deletePost(String postId);
}
