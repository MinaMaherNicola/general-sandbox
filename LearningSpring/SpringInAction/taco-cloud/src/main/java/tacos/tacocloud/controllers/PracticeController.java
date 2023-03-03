package tacos.tacocloud.controllers;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestMapping;

import java.util.List;

@Controller
@RequestMapping("/practice")
public class PracticeController {
    @ModelAttribute
    public void addTestToModel(Model model) {
        model.addAttribute("studentName", "Mina Nicola");
        List<String> names = List.of("Test", "Test2", "Test3");
        for (String name : names) {
            model.addAttribute("names", names);
        }
    }

    @GetMapping("/student-name")
    public String getStudentName() {
        return "student-name";
    }

    @GetMapping("/names")
    public String getNames() {
        return "names";
    }
}
