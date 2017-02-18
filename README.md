# ClassCounter
Simple example to count the number of times a class has been created and how many instances of that class are still alive.

## How to Run

```shell
git clone https://github.com/mwcaisse/ClassCounter.git
cd ./ClassCounter/src/ClassCounter
dotnet run 150
```

## Sample Output
```
  NonInheritableCountable: Created:  600  Alive:   0
                ImCounted: Created:  150  Alive:   0
             StayingAlive: Created: 1200  Alive: 400
          ImCountedAsWell: Created:  300  Alive:   0
```		  
## Implementation

### Class Inheritance

Simply inherit from ClassCounterBase on the class(es) you wish to enable counting on.

```C#
public class ClassIWantToCountWithInheritance : ClassCounterBase 
{

}
```

####Advantages
1. Only need to add the base class to enable counting, no need to add code to the constructor and deconstructor. Any changes made to the API will not require updating the class.

####Disadvantages
1. You need to inherit from the BaseClassCounter class, which will not allow you to inherit from another class.
2. Need to modify the class to enable instance counting.

### Without Inheritance

Add the ClassCounter.InstanceCreated to the constructor and ClassCounter.InstanceRemoved to the deconstructor.


```C#

public class ClassIWantToCount 
{

	public ClassIWantToCount() 
	{
		ClassCounter.InstanceCreated(this);
	}
	
	~ClassIWantToCount() 
	{
		ClassCounter.InstanceRemoved(this);
	}
}
```

####Advantages
1. You are free to inherit from which ever class you choose

####Disadvantages
1. You need to add 2 lines manually to the constructor + deconstructor, and will need to change them manually if ClassCounter API changes.
2. Need to modify the class to enable instance counting.

### Other Considerations
Both of these methods require you modify the class directly to enable instance counting.
Ideally it would be nice to have a RegisterForInstanceCounting(Type t) method that enables instance counting for that type without modifying the class. I was not able to find a way to do this without modifying the .NET runtime.
