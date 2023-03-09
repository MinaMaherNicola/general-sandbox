package solo.practice.models.pizzas;

import jakarta.validation.constraints.NotBlank;
import lombok.Data;

@Data
public class Pizza {
//    @NotBlank(message = "Pizza name cannot be blank!")
    private String name;
}
