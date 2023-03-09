package solo.practice.models.pizzas;

import jakarta.validation.constraints.NotBlank;
import lombok.Data;

import java.util.ArrayList;
import java.util.List;

@Data
public class PizzaOrderDetails {
    private List<Pizza> pizzas;
//    @NotBlank(message = "Address cannot be empty!")
    private String address;

    public PizzaOrderDetails() {
        pizzas = new ArrayList<>();
    }
}
