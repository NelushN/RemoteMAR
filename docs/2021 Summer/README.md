# Progress

## Week 2

#### Tasks 
- Setup Unity Project on Laptop
- Went through all the existing features of the app
- Ran the application on android emulator

## Week 3

#### Tasks 
- Familization with Code
- tried 2d and 3d text annotations
- Went through more unity tutorials
- decided to go ahead with 2d annotations after discussion with Prof Khalad 

## Week 4

#### Tasks 
- Learnt C# scripting for unity
- Created 2d Text Label annotations. Used line renderer to point to the exact label location

## Week 5

#### Tasks 
- Created Dynamic Text Labels. Created a panel which accepted text as input from user to create the label
- Created point groups, so that all the labels moved in a circle when the model is rotated

## Week 6

#### Tasks 
- Explored other annotation options. 
- Read through multiple papers 
    - https://link.springer.com/article/10.1007/s11042-019-08419-x
    - https://ieeexplore.ieee.org/document/7893337
- Implemented arrow annotations

## Week 7

#### Tasks 
- Implemented circle annotations
- Re implemented lasso annotation, so that it does not disappear after some time 

## Week 8

#### Tasks 
- Attempted to resolve app not installed issue on android build on device. Was working on emulator.
- Attempted to use box collider for the model to ensure that the annotations point to the right location in the z direction. Tried various methods to get 2D projection of the mouse point to the 3D object. 
    - https://gamedevbeginner.com/how-to-convert-the-mouse-position-to-world-space-in-unity-2d-3d/
    - http://immersivecognition.com/uxf-tutorial/part-2/
- Box collider did not serve the purpose since the middle space for models like kidneys was also included as part of the box. Did not give desired results. 
- Finally used mesh collider and raycast to achieve the results.


## Week 9

#### Tasks 
- Made the code generic so that all the annotations can work with any model. Was working only with kidneys before. 
- Worked on creating 3d text labels. 
- Made changes to 2d text labels so that they are more distributed around the model.
- Changed the color of annotations to make sure it was visible.
- Implemented delete functionality for all the annotations.

## Week 10 

#### Tasks 
- Added more models to the application; heart, ribs, kidneys, lungs and ear. 
- Added dropdown option to select the model type. 
- Shifted all the annotation options to the left side to make the UI cleaner. 

## Week 11

#### Tasks 
- Tested the application on multiple android emulators to make the UI consistent
- Changed the help button to an icon. Increased the size of annotation icons. 
- Fixed 3d text labels issue of the text not rotating with the model.
- Tried using 3d circle annotations.

## Week 12

#### Tasks 
- Fixed apk config error causing the application build to fail. 
- Prepared documentation.
- Pushed the code to GitHub repository.
- Code refactoring and comments.
- Attempted to resolve 2d text label issue

## Issues in the application

- Lasso annotation delete not working 
- 2d Text Label not working as expected for heart, ribs and ear model




