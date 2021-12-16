Hello.

This is Ludvig Baummann Olsson's hand in.

I went for both the first and second Assignments:

1. Scriptable Events Feature.
I implemented screen wrapping for the player ship by using scriptable events.
The ship's sprite has a new component called OutOfBoundsChecker.
This component raises a scriptable event passing a vector3 whenever the ship gets outside the camera view.
The ship parent has a vector3 scriptabel event listener that applies the passed vector3 to the ships position.

2. Asteroid Destroyer.
I used A runtime set to handle asteroid destruction and splitting.
When an asteroid si spawned it is added to the runtime set which contains a dictionary<int,Asteroid>.
The dictonary uses the instance ID of the newly created asteroid as the key in the dictonary. 
Whenever an asteroid is hit by a laser it raises an scriptable event sending its instance ID.

The asteroid destroyer prefab has a scriptable event listener that hears the event call.
The asteroid destroyer then gets the asteroid in the runtime set via the sent in ID.
It then checks if theasteroid is big enough to split and destroyes it.
If the asteroid is big enough to split the destroyer raises a call sending a new class called split data.
Split data is a holder class only meant to pass values.
The asteroid spawner has a event listener that hears the call.
The spawner then spawns 2 to 3 new asteroids on the destroyed asteroids location and half at of its size,
based on the SplitData it gets.