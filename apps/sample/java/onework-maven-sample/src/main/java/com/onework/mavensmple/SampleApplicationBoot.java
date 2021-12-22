package com.onework.mavensmple;

/**
 * @projectName: onework-maven-sample
 * @package: com.onework.mavensmple
 * @className: SampleApplicationBoot
 * @author: 钟凯
 * @description: 描述
 * @date: 2021/12/20 23:22
 * @version: 1.0
 */
public class SampleApplicationBoot {

    public static void main(String[] args) {
        System.out.println("main start...");
        Thread t = new Thread(() -> {
            System.out.println("thread run...");
            try {
                Thread.sleep(30);
            } catch (InterruptedException e) {
            }
            System.out.println("thread end.");
        });
        t.start();
        try {
            Thread.sleep(20);
        } catch (InterruptedException e) {
        }
        System.out.println("main end...");
    }
}
