# TRS
manipulate 3D object's Transform and Rotation in 3D Coordinates.

> VRSickness/TRS/Assets/

### C31.cs  
* make child object(C31) rotated arount parent object(P31)  
	<img src = "Res/C31.gif" width = "300"/>
    
### P41.cs
* make object object's rotation degree(P41) equal to double degree of another object(P42) of same level

### RigRotation.cs  
 With Unity XR API, Virtual Camera Object's rotation and transform values are determined by Information of In Real VR HMD Device. Developer Can't manipulate Virtual Camera's Rotation value. But a Lab requires function that experimenter can manipulate it, So I try to control parent object instead Virtual Camera to offset camera's rotation and It is now possible to control the degree of Camera object rotation as the HMD rotates.

Rig(White Cube)
	Camera(Red Cube)
Camera is rotated by Script
	Camera *= Quaternion.Euler(0,1,0);
#### Rotation rate : 0
<img src = "Res/RigRotation_0.gif" width = "300" />
The camera seems to doesn't rotate. Because rotation of camera's parent object(Rig) offset rotation of camera


#### Rotation rate : 1
<img src = "Res/RigRotation_1.gif" width = "300" />
The Camera is rotated nomally.

#### Rotation rate : 0.5
<img src = "Res/RigRotation_05.gif" width = "300" />
Half of Rotation of Camera is offseted by rotation of parent object. It looks like to spin slowly.

#### Rotation rate : 2
 <img src = "Res/RigRotation_2.gif" width = "300" />
 It is rotated more fastly

 
 