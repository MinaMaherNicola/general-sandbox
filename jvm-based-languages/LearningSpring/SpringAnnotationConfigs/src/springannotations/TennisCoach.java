package springannotations;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

@Component
@Scope("prototype")
public class TennisCoach implements Coach {
    @Value("${email}")
    private String email;

    private final FortuneService fortuneService;

    @Autowired
    public TennisCoach(@Qualifier("randomFortuneService") FortuneService fortuneService) {
        this.fortuneService = fortuneService;
    }

    public String getEmail() {
        return this.email;
    }

    @Override
    public String getDailyWorkout() {
        return "Tennis workout.";
    }

    @Override
    public String tellFortune() {
        return fortuneService.getFortune();
    }
}
