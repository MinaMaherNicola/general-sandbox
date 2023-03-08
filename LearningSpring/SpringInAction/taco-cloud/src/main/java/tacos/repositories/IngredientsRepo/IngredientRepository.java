package tacos.repositories.IngredientsRepo;

import org.springframework.context.annotation.Bean;
import org.springframework.stereotype.Repository;
import tacos.domainclasses.Ingredient;

import java.util.Optional;

public interface IngredientRepository {
    Iterable<Ingredient> findAll();
    Optional<Ingredient> findById(String id);
    Ingredient save(Ingredient ingredient);
}
