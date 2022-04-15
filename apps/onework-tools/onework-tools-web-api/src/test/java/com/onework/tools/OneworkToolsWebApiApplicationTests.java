package com.onework.tools;

import cn.hutool.core.collection.CollUtil;
import cn.hutool.extra.tokenizer.Result;
import cn.hutool.extra.tokenizer.TokenizerEngine;
import cn.hutool.extra.tokenizer.TokenizerUtil;
import cn.hutool.extra.tokenizer.Word;
import com.onework.tools.domain.database.DomainDatabaseException;
import lombok.extern.slf4j.Slf4j;
import org.junit.jupiter.api.Test;
import org.springframework.boot.test.context.SpringBootTest;

import java.util.Iterator;

@Slf4j
@SpringBootTest
class OneworkToolsWebApiApplicationTests {

    @Test
    void contextLoads() throws DomainDatabaseException {

        TokenizerEngine engine = TokenizerUtil.createEngine();

        //解析文本
        String text = "领域模式划分项目层次结构，考虑代码生成器代码与业务代码合理";
        Result result = engine.parse(text);
        //输出：这 两个 方法 的 区别 在于 返回 值
        String resultStr = CollUtil.join((Iterator<Word>)result, " ");
        System.out.println(resultStr);
    }
}
