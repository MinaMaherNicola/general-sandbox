package Chapter11;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.List;

public class Ch11 {
    public static void main(String[] args) {
        List<String> songs = MockSongs.getSongStrings();
        System.out.println(songs);

        Collections.sort(songs);
        System.out.println(songs);
    }

    class MockSongs {
        public static List<String> getSongStrings() {
            List<String> songs = new ArrayList<>();
            songs.add("somersault");
            songs.add("cassidy");
            songs.add("$10");
            songs.add("havana");
            songs.add("Cassidy");
            songs.add("50 Ways");
            return songs;
        }
    }
}
