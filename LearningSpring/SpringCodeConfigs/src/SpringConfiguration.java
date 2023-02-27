import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.PropertySource;
import springcodeconfigs.Coach;
import springcodeconfigs.FortuneService;
import springcodeconfigs.HappyFortuneService;
import springcodeconfigs.TennisCoach;

@Configuration
@PropertySource("classpath:configs.properties")
public class SpringConfiguration {
    @Bean
    public FortuneService happyFortuneService() {
        return new HappyFortuneService();
    }

    @Bean
    public Coach tennisCoach() {
        return new TennisCoach(happyFortuneService());
    }
}
