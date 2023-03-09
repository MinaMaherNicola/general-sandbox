package com.springmvc.learningspring.domainclasses;

import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

public class Student {
    private String firstName;
    private String lastName;
    private String country;
    private final Map<String, String> countryOptions;
    private String favoriteProgrammingLanguage;
    private List<String> favoriteOS;

    public Student() {
        countryOptions = new LinkedHashMap<>();
        countryOptions.put("BR", "Brazil");
        countryOptions.put("EG", "Egypt");
        countryOptions.put("UK", "United Kingdom");
    }

    public Map<String, String> getCountryOptions() {
        return this.countryOptions;
    }


    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    public String getCountry() {
        return country;
    }

    public void setCountry(String country) {
        this.country = country;
    }

    public String getFavoriteProgrammingLanguage() {
        return favoriteProgrammingLanguage;
    }

    public void setFavoriteProgrammingLanguage(String favoriteProgrammingLanguage) {
        this.favoriteProgrammingLanguage = favoriteProgrammingLanguage;
    }

    public List<String> getFavoriteOS() {
        return favoriteOS;
    }

    public void setFavoriteOS(List<String> favoriteOS) {
        this.favoriteOS = favoriteOS;
    }
}
