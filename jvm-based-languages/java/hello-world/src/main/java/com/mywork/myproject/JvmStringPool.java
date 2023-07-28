package com.mywork.myproject;

public class JvmStringPool {
    public static void main(String[] args) {
        String a = "abc";
        String b = "abc";

        // in JVM, if two strings has the same value, they are not saved in the memory twice
        // but the JVM only saves the word once and reference it with another pointer.
        // all strings are saved in what is called "string pool"
        // only when a string object is created using a new operator, the memory for the new object is allocated outside
        // the string pool

        System.out.println(System.identityHashCode(a));
        System.out.println(System.identityHashCode(b));
    }
}
