package springannotations;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

@Component
public class PaddleCoach implements Coach {
    private FortuneService fortuneService;

    @Autowired
    private void injectFortuneService(FortuneService fortuneService) {
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
