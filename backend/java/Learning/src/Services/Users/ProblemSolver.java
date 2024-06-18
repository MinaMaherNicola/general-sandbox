package Services.Users;

import java.util.HashMap;

public class ProblemSolver {
    public int[] twoSum(int[] nums, int target) {
        if (nums.length == 2) {
            return new int[]{nums[0], nums[1]};
        }
        HashMap<Integer, Integer> map = new HashMap<Integer, Integer>();

        for (int i = 0; i < nums.length; i++) {
            map.put(i, Math.abs(nums[i] - target));
        }

        for (int i = 0; i < nums.length; i++) {
            int currentDiff = map.get(i);
            if (currentDiff == nums[i]) {
                return new int[] {i}
            }
        }
        throw new NullPointerException();
    }
}
