package com.onework.tools.common.web;

import org.springframework.stereotype.Component;

import javax.annotation.processing.AbstractProcessor;
import javax.annotation.processing.RoundEnvironment;
import javax.annotation.processing.SupportedAnnotationTypes;
import javax.annotation.processing.SupportedSourceVersion;
import javax.lang.model.SourceVersion;
import javax.lang.model.element.TypeElement;
import java.util.Set;

/**
 * @projectName: onework-tools
 * @package: com.onework.tools.common.web
 * @className: TOperation
 * @author: 钟凯
 * @description: 描述
 * @date: 2021/12/18 21:49
 * @version: 1.0
 */

@Component
@SupportedAnnotationTypes({"io.swagger.v3.oas.annotations.Operation"})
@SupportedSourceVersion(SourceVersion.RELEASE_8)
public class OperationAbstractProcessor extends AbstractProcessor {

    /**
     * {@inheritDoc}
     *
     * @param annotations
     * @param roundEnv
     */
    @Override
    public boolean process(Set<? extends TypeElement> annotations, RoundEnvironment roundEnv) {
        return false;
    }
}
