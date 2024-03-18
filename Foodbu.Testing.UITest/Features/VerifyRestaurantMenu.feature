Feature: VerifyRestaurantMenu

    As a user
    I want to verify the menu of FOODBU restaurant

Background:
    Given I have launched the FoodBu application

    @tag
Scenario: Verify Restaurant Menu MAINS section
    When I navigate to the MAINS section
    Then The list of available dishes pane should be visible
    And Dishes with their prices should be as follow
    | DishName      | DishPrice | Visibility |
    | Spicy Falafel | 1.26 $    | TRUE       |