package tacos.tacocloud.controllers;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;

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

    @ResponseBody
    @GetMapping
    public GenericResponse<Integer> h5a() {
        var response = new GenericResponse<Integer>();
        response.setData(10);
        return response;
    }

    class GenericResponse<T> {
        private T data;
        private String message = "Success";
        public T getData() {
            return data;
        }

        public void setData(T data) {
            this.data = data;
        }

        public String getMessage() {
            return message;
        }

        public void setMessage(String message) {
            this.message = message;
        }
    }
}
