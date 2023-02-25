package springannotations;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Component;

@Component
public class PaddleCoach implements Coach {
    private FortuneService fortuneService;

    @Autowired
    private void injectFortuneService(@Qualifier("randomFortuneService") FortuneService fortuneService) {
        this.fortuneService = fortuneService;
    }
    @Override
    public String getDailyWorkout() {
        return "Play paddle!";
    }

    @Override
    public String tellFortune() {
        return fortuneService.getFortune();
    }
}
