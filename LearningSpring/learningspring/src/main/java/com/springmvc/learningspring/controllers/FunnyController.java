package com.springmvc.learningspring.controllers;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller
@RequestMapping("/funny")
public class FunnyController {
    @RequestMapping("/home")
    public String getFunnyHome() {
        return "funny-home";
    }
}
