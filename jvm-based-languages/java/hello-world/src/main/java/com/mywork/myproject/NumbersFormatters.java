package com.mywork.myproject;

import java.math.BigDecimal;
import java.text.NumberFormat;
import java.util.Locale;

public class NumbersFormatters {
    public static void main(String[] args) {
        // You can format numbers easily using the "NumberFormat" class
        NumberFormat nf = NumberFormat.getCompactNumberInstance(Locale.CANADA, NumberFormat.Style.SHORT);

        System.out.println(nf.format(1_000_000));
        System.out.println(nf.format(100_000));
        System.out.println(nf.format(1_000));

        NumberFormat nfp = NumberFormat.getCurrencyInstance(Locale.CANADA);
        System.out.println(nfp.format(new BigDecimal("10.2555")));
    }
}
