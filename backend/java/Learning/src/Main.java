import Services.Users.ProblemSolver;

import java.util.Arrays;

public class Main {
    public static void main(String[] args) {
        ProblemSolver solver = new ProblemSolver();

        System.out.println(Arrays.toString(solver.twoSum(new int[]{3, 3}, 6)));
    }
}