using System;

class MacroCalculator
{
    static void Main(string[] args)
    {
        Console.WriteLine("==============================");
        Console.WriteLine(" Welcome to the Fordge Macro and Calorie Calculator!");
        Console.WriteLine("==============================");

        // Gather user information
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        int age;
        while (true)
        {
            Console.Write("Enter your age: ");
            if (int.TryParse(Console.ReadLine(), out age) && age > 0) break;
            Console.WriteLine("Invalid input. Please enter a valid age.");
        }

        Console.Write("Enter your gender (M/F): ");
        string gender = Console.ReadLine().ToUpper();
        while (gender != "M" && gender != "F")
        {
            Console.Write("Invalid input. Enter your gender (M/F): ");
            gender = Console.ReadLine().ToUpper();
        }

        // Ask for weight unit
        Console.Write("Do you want to use kilograms (kg) or pounds (lbs) for weight? (Enter kg/lbs): ");
        string weightUnit = Console.ReadLine().ToLower();
        while (weightUnit != "kg" && weightUnit != "lbs")
        {
            Console.Write("Invalid choice. Enter kg or lbs: ");
            weightUnit = Console.ReadLine().ToLower();
        }

        double weight;
        while (true)
        {
            Console.Write($"Enter your weight in {weightUnit}: ");
            if (double.TryParse(Console.ReadLine(), out weight) && weight > 0) break;
            Console.WriteLine("Invalid input. Please enter a valid weight.");
        }

        if (weightUnit == "lbs")
        {
            weight *= 0.453592; // Convert lbs to kg
        }

        // Ask for height unit
        Console.Write("Do you want to use centimeters (cm) or feet/inches for height? (Enter cm/ft): ");
        string heightUnit = Console.ReadLine().ToLower();
        while (heightUnit != "cm" && heightUnit != "ft")
        {
            Console.Write("Invalid choice. Enter cm or ft: ");
            heightUnit = Console.ReadLine().ToLower();
        }

        double height;
        if (heightUnit == "cm")
        {
            while (true)
            {
                Console.Write("Enter your height in cm: ");
                if (double.TryParse(Console.ReadLine(), out height) && height > 0) break;
                Console.WriteLine("Invalid input. Please enter a valid height.");
            }
        }
        else
        {
            int feet, inches;
            while (true)
            {
                Console.Write("Enter your height in feet: ");
                if (int.TryParse(Console.ReadLine(), out feet) && feet > 0) break;
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            while (true)
            {
                Console.Write("Enter your height in inches: ");
                if (int.TryParse(Console.ReadLine(), out inches) && inches >= 0) break;
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            height = (feet * 30.48) + (inches * 2.54); // Convert feet'inches to cm
        }

        // Activity level
        Console.WriteLine("\nOn a scale of 1-5, how active are you?");
        Console.WriteLine("1 - Sedentary (little to no exercise)");
        Console.WriteLine("2 - Lightly active (light exercise/sports 1-3 days a week)");
        Console.WriteLine("3 - Moderately active (moderate exercise/sports 3-5 days a week)");
        Console.WriteLine("4 - Very active (hard exercise/sports 6-7 days a week)");
        Console.WriteLine("5 - Super active (very hard exercise, physical job, or training twice a day)");

        int activityLevel;
        while (true)
        {
            Console.Write("Enter your activity level (1-5): ");
            if (int.TryParse(Console.ReadLine(), out activityLevel) && activityLevel >= 1 && activityLevel <= 5) break;
            Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
        }

        // Goal
        Console.WriteLine("\nWhat is your goal?");
        Console.WriteLine("1 - Lose weight");
        Console.WriteLine("2 - Maintain weight");
        Console.WriteLine("3 - Gain weight");

        int goal;
        while (true)
        {
            Console.Write("Enter your goal (1-3): ");
            if (int.TryParse(Console.ReadLine(), out goal) && goal >= 1 && goal <= 3) break;
            Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
        }

        // Speed of weight change
        double calorieAdjustment = 0;
        if (goal != 2) // Only needed for weight gain/loss
        {
            Console.WriteLine("\nHow quickly do you want to adjust your weight?");
            Console.WriteLine("1 - Mild (0.25 kg per week / 0.5 lb per week)");
            Console.WriteLine("2 - Moderate (0.5 kg per week / 1 lb per week)");
            Console.WriteLine("3 - Extreme (1 kg per week / 2 lb per week)");

            int speed;
            while (true)
            {
                Console.Write("Enter your choice (1-3): ");
                if (int.TryParse(Console.ReadLine(), out speed) && speed >= 1 && speed <= 3) break;
                Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
            }

            calorieAdjustment = speed switch
            {
                1 => 250,
                2 => 500,
                3 => 1000,
                _ => 0
            };

            if (goal == 1) calorieAdjustment *= -1; // Caloric deficit for weight loss
        }

        // Calculate BMR and TDEE
        double bmr = (gender == "M")
            ? (10 * weight + 6.25 * height - 5 * age + 5)
            : (10 * weight + 6.25 * height - 5 * age - 161);

        double[] activityMultipliers = { 1.2, 1.375, 1.55, 1.725, 1.9 };
        double tdee = bmr * activityMultipliers[activityLevel - 1] + calorieAdjustment;

        // Macronutrient preference
        Console.WriteLine("\nSelect your macronutrient preference:");
        Console.WriteLine("1 - Balanced");
        Console.WriteLine("2 - Low fat");
        Console.WriteLine("3 - Low carbs");
        Console.WriteLine("4 - High protein");

        int macroPreference;
        while (true)
        {
            Console.Write("Enter your choice (1-4): ");
            if (int.TryParse(Console.ReadLine(), out macroPreference) && macroPreference >= 1 && macroPreference <= 4) break;
            Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
        }

        // Macro calculations
        double protein = weight * 2; // 2g per kg (default)
        double fats = weight * 0.8; // 0.8g per kg (default)
        double carbs = (tdee - (protein * 4 + fats * 9)) / 4;

        switch (macroPreference)
        {
            case 2: // Low fat
                fats *= 0.7;
                carbs = (tdee - (protein * 4 + fats * 9)) / 4;
                break;
            case 3: // Low carbs
                carbs *= 0.7;
                fats = (tdee - (protein * 4 + carbs * 4)) / 9;
                break;
            case 4: // High protein
                protein *= 1.3;
                carbs = (tdee - (protein * 4 + fats * 9)) / 4;
                break;
        }

        // Display results
        Console.Clear();
        Console.WriteLine("\n--- Results ---");
        Console.WriteLine($"TDEE: {tdee:F2} kcal/day");
        Console.WriteLine($"Protein: {protein:F2} g");
        Console.WriteLine($"Fats: {fats:F2} g");
        Console.WriteLine($"Carbs: {carbs:F2} g");

        Console.WriteLine("\nThank you for using the Macro and Calorie Calculator!");
    }
}