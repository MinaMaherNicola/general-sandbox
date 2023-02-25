package springannotations;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

@Component
public class FootballCoach implements Coach {
    @Autowired
    private FortuneService fortuneService;

    @Override
    public String getDailyWorkout() {
        return "Play football idk";
    }

    @Override
    public String tellFortune() {
        return fortuneService.getFortune();
    }
}
