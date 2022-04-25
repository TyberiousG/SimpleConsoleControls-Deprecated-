# SimpleConsoleControls
Simple Console Controls for .NET languages

SimpleConsoleControls (SCC) makes creating Command Line Interfaces simple and easy with any .NET language. Current functions and subroutines include:


- Subroutine: **Label**( X [int], Y [int], LabelText [string], Optional FColor [ConsoleColor], Optional BColor [ConsoleColor])

  Creates a label within the window at the designated X and Y starting points.



- Function: **TextField**( X [int], Y [int], Width [int])

  Creates a Fixed-Length Input Field starting at the designated X and Y points.
  
  Returns string value from user input.
  
  
- Subroutine: **Title**( Y [int], Text [string])


  Creates a title label centered in the middle of the window.
  
  
- Function: **PasswordField**( X [int], Y [int], Width [int], Optional Mask [string])
  
  Draws fixed-length masked input field in the main window at the designated starting X and Y points.
  
  Returns string from user password input.


- Subroutine: **DrawRectangle**(X [int], Y[int], Width [int], Height [int])

  Draws a rectangle to the screen at the specified X and Y positions. The origin point of the rectangle is the upper right hand corner.
  The rectangle design is displayed in "double pipe" characters.
