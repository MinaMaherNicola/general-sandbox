import springcodeconfigs.Coach;
import org.springframework.context.annotation.AnnotationConfigApplicationContext;

public class Main {
    public static void main(String[] args) {
        var context = new AnnotationConfigApplicationContext(SpringConfiguration.class);

        Coach coach = context.getBean("tennisCoach", Coach.class);
        System.out.println(coach.getDailyWorkout());
        System.out.println(coach.getFortune());
        System.out.println(coach.getEmail());
        System.out.println(coach.getTeam());
    }
}