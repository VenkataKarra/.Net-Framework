# CarsDiscountsCalcAPIs


Access the api endpoitns as below:

http://localhost:49795/api/cars 



 "CarRepository"

* GetAllCars
* Add
* Update


You will need to write a .Net REST API (using C#.Net)
1. Insert new car
2. Update existing car.
3. Calculate discount on a list of cars to purchase according to the rules mentioned below.

Discount rule:
1. If total cost exceeds $100,000 apply 5% discount
2. If number of cars is more than 2, apply 3% discount
3. If cars year is before 2000, apply 10% discount
4. The above rules are cumulative (i.e. all of them can be applicable at the same time)
