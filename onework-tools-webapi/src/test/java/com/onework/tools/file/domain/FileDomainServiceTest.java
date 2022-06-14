package com.onework.tools.file.domain;

import com.onework.tools.BaseApplicationTest;
import com.onework.tools.file.domain.vo.FileCategoryConfigType;
import com.onework.tools.file.domain.vo.FileCategoryVo;
import com.onework.tools.webapi.OneworkToolsWebapiApplication;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

import java.util.HashMap;
import java.util.Map;

import static org.junit.jupiter.api.Assertions.*;

/**
 * @author : zhongkai1010@163.com
 * @version V1.0
 * @Project: onework-tools
 * @Package com.onework.tools.file.domain
 * @Description: 描述
 * @date Date : 2022年06月14日 15:16
 */
@SpringBootTest(classes = {OneworkToolsWebapiApplication.class})
class FileDomainServiceTest extends BaseApplicationTest {

    @Autowired
    private FileDomainService fileDomainService;

    @Test
    void addCategory() {
        FileCategoryVo fileCategoryVo = new FileCategoryVo();
        fileCategoryVo.setCode("test1");
        fileCategoryVo.setName("测试类别1");
        Map<FileCategoryConfigType, String> config = new HashMap<>(7);
        config.put(FileCategoryConfigType.FILE_EXT, ".ext,.ext");
        fileDomainService.addCategory(fileCategoryVo, config);
    }

    @Test
    void updateCategoryConfig() {
        Map<FileCategoryConfigType, String> config = new HashMap<>(7);
        config.put(FileCategoryConfigType.FILE_EXT, ".crv");
        config.put(FileCategoryConfigType.FILE_SIZE, "1048");
        fileDomainService.updateCategoryConfig("1536647004752666626", config);
    }

    @Test
    void testUpdateCategoryConfig() {
        fileDomainService.updateCategoryConfig("1536647004752666626", FileCategoryConfigType.FILE_SIZE, "2048");
    }

    @Test
    void deleteCategory() {

        fileDomainService.deleteCategory("1536647004752666626");

    }

    @Test
    void addFile() {
    }

    @Test
    void deleteFile() {
    }

    @Test
    void addFileAttachment() {
    }

    @Test
    void deleteFileAttachment() {
    }

    @Test
    void deleteAttachment() {
    }
}