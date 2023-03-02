package com.springmvc.learningspring.controllers;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;

@Controller
public class HomeController {
    @RequestMapping("/")
    public String getHomePage() {
        return "home";
    }

    @RequestMapping("/form")
    public String getFormPage() {
        return "form";
    }

    @RequestMapping("/processForm")
    public String formProcessing(@RequestParam("studentName") String name, Model model) {
        model.addAttribute("name", name.toUpperCase());
        return "display-name";
    }
}
