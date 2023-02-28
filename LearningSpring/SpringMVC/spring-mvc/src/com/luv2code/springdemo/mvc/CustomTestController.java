package com.luv2code.springdemo.mvc;

import javax.servlet.http.HttpServletRequest;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller
public class CustomTestController {

	@RequestMapping("test")
	public String customEndPoint(HttpServletRequest request, Model model) {
		String param = request.getParameter("team") + " " + "RMA";
		model.addAttribute("team", param);
		return "team-view";
	}
}
