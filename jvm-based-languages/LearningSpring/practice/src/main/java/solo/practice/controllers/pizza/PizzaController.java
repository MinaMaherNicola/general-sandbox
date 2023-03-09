package solo.practice.controllers.pizza;


import lombok.extern.slf4j.Slf4j;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;
import solo.practice.models.pizzas.Pizza;
import solo.practice.models.pizzas.PizzaOrderDetails;

@Controller
@RequestMapping("/pizza")
@SessionAttributes({ "pizzaOrderDetails" })
@Slf4j
public class PizzaController {
    @ModelAttribute("pizzaOrderDetails")
    public PizzaOrderDetails addPizzaOrderDetailsToModel() {
        return new PizzaOrderDetails();
    }
    @ModelAttribute("pizza")
    public Pizza addPizzaToModel() {
        return new Pizza();
    }

    @GetMapping
    public String pizzaNameForm() {
        return "pizzas/pizza-name-form";
    }

    @PostMapping
    public String processPizzaSubmission(@ModelAttribute Pizza pizza, @ModelAttribute PizzaOrderDetails pizzaOrderDetails) {
        pizzaOrderDetails.getPizzas().add(pizza);
        return "pizzas/pizza-submission-form";
    }
}
