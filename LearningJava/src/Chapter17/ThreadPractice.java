package Chapter17;

import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class ThreadPractice {
    public static void main(String[] args) {
        // single threading
        ExecutorService executor = Executors.newSingleThreadExecutor();

        executor.execute(() -> System.out.println("1"));
        System.out.println("2");

        executor.shutdown();

        Thread myThread = new Thread(() -> System.out.println("1"));
        myThread.start();
        System.out.println("2");

        // multiple threading (thread pool)
        ExecutorService threadPool = Executors.newFixedThreadPool(2);
        threadPool.execute(() -> runJob("Job 1"));
        threadPool.execute(() -> runJob("Job 2"));
        threadPool.shutdown();
    }
    public static void runJob(String jobName) {
        for (int i = 0; i < 25; i++) {
            System.out.println(jobName + " is running on " + Thread.currentThread().getName());
        }
    }
}
