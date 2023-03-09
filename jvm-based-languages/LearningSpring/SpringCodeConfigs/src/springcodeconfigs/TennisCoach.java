package springcodeconfigs;

import org.springframework.beans.factory.annotation.Value;

public class TennisCoach implements Coach {

    private final FortuneService fortuneService;
    @Value("${email}")
    private String email;
    @Value("${team}")
    private String team;

    public TennisCoach(FortuneService fortuneService) {
        this.fortuneService = fortuneService;
    }

    @Override
    public String getDailyWorkout() {
        return "Play tennis!";
    }

    @Override
    public String getFortune() {
        return fortuneService.getFortune();
    }

    @Override
    public String getEmail() {
        return email;
    }

    @Override
    public String getTeam() {
        return team;
    }
}
