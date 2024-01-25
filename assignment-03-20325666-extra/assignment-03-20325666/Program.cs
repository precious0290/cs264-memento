// See https://aka.ms/new-console-template for more information
//
// See https://aka.ms/new-console-template for more information
/* Name of App that will control the functions of the app whilst handing the user input

it will export the svg hardcode into an svg file that will hold the shapes
Operating System: Windows
IDE: Visual Studio Code

*/

using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DeluxePad
{
  public class DeluxeDrawing{


    public static void Main(string[]args)
    {
        Console.WriteLine(" Canvas created	- use commands to add shapes to	the	canvas");
        Console.WriteLine("For commands (Type 'H' )");
        Console.WriteLine("To view list of shapes to create (Type 'V')");
        Console.WriteLine("To end the program ( Type 'Q')");
        Console.WriteLine();
        Random r = new Random();
        r.Next(1, 99);
        string [] colourArray  = {""};

/* FillColour, StrokeColour and Strokewidthsize are used to store the style attributes for when a user would like to update the shape
i came across this solution from my last assignment where i realised it would update but the svg shape itself would not save the update for the styles
so i thought making global variables that stored the previous ones would work */
 
        string fillColour="";
        string strokeColour="";
        string StrokeWidthSize="";
        string userResponse=Console.ReadLine();
        string userChoice ="";
        
        string svgStartTag ="<svg height=\"1080\" width=\"800\">";
        string svgEndTag="</svg>";

        bool endSession = false;
    
        Canvas newCanvas = new Canvas();
        Memento memory = new Memento();


        while(endSession==false){
        switch(userResponse) 
        {
            case "H":
           // Console.WriteLine("information!!!!!");
            Console.WriteLine(" Commands:");
            Console.WriteLine(" H	 	 Help	-	displays this message");
            Console.WriteLine(" A	<shape>	 Add <shape	to canvas");
            Console.WriteLine(" D     Display Canvas");
            Console.WriteLine(" Del   Delete a chosen shape"); //extra credit
            Console.WriteLine(" Up    Update a chosen shape"); //extra credit
            Console.WriteLine(" U	 	  Undo last operation");
            Console.WriteLine(" R	 	  Redo last operation");
            Console.WriteLine(" C	 	  Clear canvas");
            Console.WriteLine(" P	 	  Print History");
            Console.WriteLine(" Q	 	  Quit application");
            userResponse = Console.ReadLine();
            break;

            case "V":
            Console.WriteLine("Enter a shape name to select a shape you want to create!");
            Console.WriteLine("[A circle] -> Add Circle"+"\n[A ellipse] -> Add Ellipse"+"\n[A line] -> Add Line");
            Console.WriteLine("[A path] -> Add Path"+  "\n[A polygon] -> Add Polygon"+"\n[A polyline] -> Add Polyline");
            Console.WriteLine("[A rectangle] -> Add Rectangle" +"\n[A square] -> Add Square"+"\n[A text] -> Add Text");
            Console.WriteLine(" H	 	 Help	-	displays this message");
            Console.WriteLine(" D     Display Canvas");
            Console.WriteLine(" Del   Delete a chosen shape");//extra credit
            Console.WriteLine(" Up    Update a chosen shape");//extra credit
            Console.WriteLine(" U	 	  Undo last operation");
            Console.WriteLine(" R	 	  Redo last operation");
            Console.WriteLine(" C	 	  Clear canvas");
            Console.WriteLine(" P	 	  Print History");
            Console.WriteLine(" Q	 	  Quit application");
            userChoice = Console.ReadLine();
            break;

          
            

           case "Q":
           Console.WriteLine("Your session is finished!"+"\nHave a nice day<3 ");
           Environment.Exit(0);
           break;

           default:
            Console.WriteLine("No option was selected!"+"\nPlease select an option from the menu!");
             userResponse = Console.ReadLine();
            break;

            

        }
        
          
          //Shape shape1 = new Circle("2","2","1");
         //menu for user selecting a shape!
      //Shape userShape;

      Shape userShape  = new Circle(); // -> defined in my switch case scope so i can refer to it at any point within the switch
     
      string userDecision; //used for deciding what attributes, if any should b added to their shape
         switch(userChoice)
         {
            case "A circle":
            Console.WriteLine("Drawing a Circle!");
            Console.WriteLine("Would you like to change default circle size?"+"\n(Type 'y' for yes)"+"\n(Type 'n' for no)" );
           userDecision = Console.ReadLine().ToLower();
             
           if(userDecision=="y")
           {
            Console.WriteLine("Type in 3 numbers,pressing enter everytime");
            Console.WriteLine("Circle x: ");
            string userCx = Console.ReadLine();
            Console.WriteLine("Circle y: ");
            string userCy= Console.ReadLine();
            Console.WriteLine("Radius: ");
            string userRadius = Console.ReadLine();
            userShape = new Circle(userCx,userCy,userRadius);
            Console.WriteLine("Circle	(R="+userRadius+","+"X="+userCx+"y="+userCy+") added to the canvas.");
            
            
           }
           else if(userDecision=="n"){

            string randX= r.Next(1,100).ToString();
            string randY = r.Next(1,100).ToString();
            string randR  =r.Next(1,100).ToString();
             userShape = new Circle(randX, randY, randR);
            Console.WriteLine("Circle	(R="+randR+","+"X="+randX+"y="+randY+") added to the canvas.");
           }
           userDecision="";
           Console.WriteLine("Would you like to change the default circle colour and the line thickness size?"+"\n(Type 'y' for yes)"+"\n(Type 'n' for no)");
           userDecision = Console.ReadLine().ToLower();

           if(userDecision=="y")
           {
             Console.WriteLine("Type in 2 colours and a number,pressing enter everytime");
             Console.WriteLine("Shape Colour:");
             string fillcolour = Console.ReadLine().ToLower();
             Console.WriteLine("Shape Outline Colour");
             string strokecolour = Console.ReadLine().ToLower();
             Console.WriteLine("Shape Outline Thickness");
             string strokesize = Console.ReadLine();
             userShape.setFill(fillcolour);  
             userShape.setStroke(strokecolour);
             userShape.setStrokeWidth(strokesize);
             Console.WriteLine("This is your Circle!");
            
           Console.WriteLine(userShape.getShapeAttribute());
              
           }
           else if(userDecision=="n")
           {
             userShape.setFill("");
             userShape.setStroke("");
             userShape.setStrokeWidth("");
             Console.WriteLine("This is your Circle!");
           Console.WriteLine(userShape.getShapeAttribute());
           }
           fillColour = userShape.getFill();
           strokeColour= userShape.getStroke();
           StrokeWidthSize = userShape.getStrokeWidth();
           
           newCanvas.AddShape(userShape.getShapeAttribute());//adds svg circle string to list
            memory.AddHistory(userShape.getShapeAttribute());
            memory.clearRedoList();
            break;


            case "A ellipse":
            Console.WriteLine("Drawing a Ellipse!");
            Console.WriteLine("Would you like to change default ellipse size?"+"\n(Type 'y' for yes)"+"\n(Type 'n' for no)" );
           userDecision = Console.ReadLine().ToLower();
             userShape  = new Ellipse();
           if(userDecision=="y")
           {
            Console.WriteLine("Type in 4 numbers, pressing enter everytime");
            Console.WriteLine("Circle x coordinate");
            string userCx = Console.ReadLine();
            Console.WriteLine("Circle y coordinate");
            string userCy= Console.ReadLine();
            Console.WriteLine("Circle Radius x coordinate");
            string userRx = Console.ReadLine();
            Console.WriteLine("Circle Radius y coordinate");
            string userRy = Console.ReadLine();
            userShape = new Ellipse(userCx,userCy,userRx,userRy);
            Console.WriteLine("Ellipse	(Rx="+userRx+","+"Ry="+userRy+"X="+userCx+"y="+userCy+") added to the canvas.");

            
           }
           else if(userDecision=="n"){

             string randX = r.Next(1,100).ToString();
             string randY = r.Next(1,100).ToString();
             string randRX = r.Next(1,100).ToString();
             string randRY= r.Next(1,100).ToString();
             userShape = new Ellipse(randX, randY, randRX, randRY);
             Console.WriteLine("Ellipse	(Rx="+randRX+","+"Ry="+randRY+"X="+randX+"y="+randY+") added to the canvas.");
           }
           userDecision="";
           Console.WriteLine("Would you like to change the default ellipse colour and the line thickness size?"+"\n(Type 'y' for yes)"+"\n(Type 'n' for no)");
           userDecision = Console.ReadLine().ToLower();
             if(userDecision=="y")
           {Console.WriteLine("Type in 2 colours and a number,pressing enter everytime");
             Console.WriteLine("Shape Colour:");
             string fillcolour = Console.ReadLine().ToLower();
             Console.WriteLine("Shape Outline Colour");
             string strokecolour = Console.ReadLine().ToLower();
             Console.WriteLine("Shape Outline Thickness");
             string strokesize = Console.ReadLine();
             userShape.setFill(fillcolour);  
             userShape.setStroke(strokecolour);
             userShape.setStrokeWidth(strokesize);
             Console.WriteLine("This is your Ellipse!");
             
           Console.WriteLine(userShape.getShapeAttribute());
             memory.AddHistory(userShape.getShapeAttribute());
             memory.clearRedoList();
           }
           else if(userDecision=="n")
           {
             userShape.setFill("");
             userShape.setStroke("");
             userShape.setStrokeWidth("");
             Console.WriteLine("This is your Ellipse!");
           Console.WriteLine(userShape.getShapeAttribute());
           }
           fillColour = userShape.getFill();
           strokeColour= userShape.getStroke();
           StrokeWidthSize = userShape.getStrokeWidth();
           
           newCanvas.AddShape(userShape.getShapeAttribute());//adds svg ellipse string to list
           memory.AddHistory(userShape.getShapeAttribute());
           memory.clearRedoList();

             
            break;

            case "A line":
            Console.WriteLine("Drawing a Line!");
            userDecision="";
          
            Console.WriteLine("Would you like to change default line size?"+"\n(Type 'y' for yes)"+"\n(Type 'n' for no)" );
           userDecision = Console.ReadLine().ToLower();
            
             userShape = new Line();
           if(userDecision=="y")
           {
            Console.WriteLine("Type in 4 numbers, pressing enter everytime");
            Console.WriteLine("Line x1 coordinate");
            string userX1 = Console.ReadLine();
            Console.WriteLine("Line x2 coordinate");
            string userX2= Console.ReadLine();
            Console.WriteLine("Line y1 coordinate");
            string userY1 = Console.ReadLine();
            Console.WriteLine("Line y2 coordinate");
            string userY2 = Console.ReadLine();
            userShape = new Line(userX1,userX2,userY1,userY2);
            Console.WriteLine("Line (X1="+userX1+",X2="+userX2+",y1="+userY1+",y2="+userY2+" added to the canvas.");

            
           }
           else if( userDecision=="n")
           {
            string x1 = r.Next(1,100).ToString();
            string x2 = r.Next(1,100).ToString();
            string y1 = r.Next(1,100).ToString();
            string y2 = r.Next(1,100).ToString();
            userShape = new Line(x1,x2,y1,y2);
            Console.WriteLine("Line (X1="+x1+",X2="+x2+",y1="+y1+",y2="+y2+" added to the canvas.");
           }
             
           
           userDecision="";
           Console.WriteLine("Would you like to change the default line colour and the line thickness size?"+"\n(Type 'y' for yes)"+"\n(Type 'n' for no)");
           userDecision = Console.ReadLine();
             if(userDecision=="y")
           {
            Console.WriteLine("Type in 1 colour and a number,pressing enter everytime");
             Console.WriteLine("Shape Outline Colour");
             string strokecolour = Console.ReadLine().ToLower();
             Console.WriteLine("Shape Outline Thickness");
             string strokesize = Console.ReadLine();  
             userShape.setStroke(strokecolour);
             userShape.setStrokeWidth(strokesize);
             Console.WriteLine("This is your Line!");
           Console.WriteLine(userShape.getShapeAttribute());
             
           }
           else if(userDecision=="n")
           {
         
             userShape.setStroke("");
             userShape.setStrokeWidth("");
             Console.WriteLine("This is your Line!");
           Console.WriteLine(userShape.getShapeAttribute());
           }
           
           strokeColour= userShape.getStroke();
           StrokeWidthSize = userShape.getStrokeWidth();
           
           newCanvas.AddShape(userShape.getShapeAttribute());//adds svg line string to list
           memory.AddHistory(userShape.getShapeAttribute());
           memory.clearRedoList();
            break;

            case "A path":
            Console.WriteLine("Drawing a Path!");
                      userDecision="";
          
            Console.WriteLine("Would you like to change default path size?"+"\n(Type 'y' for yes)"+"\n(Type 'n' for no)" );
           userDecision = Console.ReadLine();
            
             userShape = new Path();
           if(userDecision=="y")
           {
            Console.WriteLine("Type in a line with 7 inputs in a row, for example: M150 0 L75 200 L225 200 Z ");
            string path = Console.ReadLine();
            userShape = new Path(path);
            Console.WriteLine("Line ("+path+") added to the canvas.");

            
           }
           else if( userDecision=="n")
           {
            userShape = new Path();
            Console.WriteLine("Line (M150 0 L75 200 L225 200 Z) added to the canvas");
           }
             
           
           userDecision="";
           Console.WriteLine("Would you like to change the default path colour and the line thickness size?"+"\n(Type 'y' for yes)"+"\n(Type 'n' for no)");
           userDecision = Console.ReadLine();
             if(userDecision=="y")
           {
            Console.WriteLine("Type in 2 colours and a number,pressing enter everytime");
             Console.WriteLine("Shape Colour:");
             string fillcolour = Console.ReadLine().ToLower();
             Console.WriteLine("Shape Outline Colour");
             string strokecolour = Console.ReadLine().ToLower();
             Console.WriteLine("Shape Outline Thickness");
             string strokesize = Console.ReadLine();
             userShape.setFill(fillcolour);  
             userShape.setStroke(strokecolour);
             userShape.setStrokeWidth(strokesize);
             Console.WriteLine("This is your Path!");
           Console.WriteLine(userShape.getShapeAttribute());
             
           }
           else if(userDecision=="n")
           {
             userShape.setFill("");
             userShape.setStroke("");
             userShape.setStrokeWidth("");
             Console.WriteLine("This is your Path!");
           Console.WriteLine(userShape.getShapeAttribute());
           }
           fillColour = userShape.getFill();
           strokeColour= userShape.getStroke();
           StrokeWidthSize = userShape.getStrokeWidth();
           
           newCanvas.AddShape(userShape.getShapeAttribute());//adds svg path string to list
           memory.AddHistory(userShape.getShapeAttribute());
           memory.clearRedoList();
            break; 

            case "A polygon":
            Console.WriteLine("Drawing a Polygon!");
            userDecision="";
          
            Console.WriteLine("Would you like to change default polygon size?"+"\n(Type 'y' for yes)"+"\n(Type 'n' for no)" );
           userDecision = Console.ReadLine();
            
             userShape = new Polygon();
           if(userDecision=="y")
           {
            Console.WriteLine("Type in a line with 8 inputs in a row, for example: 220,10 300,210 170,250 123,234 ");
            string points = Console.ReadLine();
            Console.WriteLine("Polygon (" +points+") added to the canvas.");
  
            
           }
           else if( userDecision=="n")
           {
            userShape = new Polygon();
            Console.WriteLine("Polygon (220,10 300,210 170,250 123,234) added to the canvas.");
           }
             
           
           userDecision="";
           Console.WriteLine("Would you like to change the default polygon colour and the line thickness size?"+"\n(Type 'y' for yes)"+"\n(Type 'n' for no)");
           userDecision = Console.ReadLine();
             if(userDecision=="y")
           {
            Console.WriteLine("Type in 2 colours and a number,pressing enter everytime");
             Console.WriteLine("Shape Colour:");
             string fillcolour = Console.ReadLine().ToLower();
             Console.WriteLine("Shape Outline Colour");
             string strokecolour = Console.ReadLine().ToLower();
             Console.WriteLine("Shape Outline Thickness");
             string strokesize = Console.ReadLine();
             userShape.setFill(fillcolour);  
             userShape.setStroke(strokecolour);
             userShape.setStrokeWidth(strokesize);
             Console.WriteLine("This is your Polygon!");
           Console.WriteLine(userShape.getShapeAttribute());
             
           }
           else if(userDecision=="n")
           {
             userShape.setFill("");
             userShape.setStroke("");
             userShape.setStrokeWidth("");
             Console.WriteLine("This is your Polygon!");
             memory.AddHistory(userShape.getShapeAttribute());
           Console.WriteLine(userShape.getShapeAttribute());
           }
           fillColour = userShape.getFill();
           strokeColour= userShape.getStroke();
           StrokeWidthSize = userShape.getStrokeWidth();
           memory.AddHistory(userShape.getShapeAttribute());
           newCanvas.AddShape(userShape.getShapeAttribute());//adds svg polygon string to list
            break;

            case "A polyline":
            Console.WriteLine("Drawing a Polyline!");
              userDecision="";
          
            Console.WriteLine("Would you like to change default polyline size?"+"\n(Type 'y' for yes)"+"\n(Type 'n' for no)" );
           userDecision = Console.ReadLine();
            
             userShape = new Polyline();
           if(userDecision=="y")
           {
            Console.WriteLine("Type in a line with 12 inputs in a row, for example: 20,20 40,25 60,40 80,120 120,140 200,180 ");
            Console.WriteLine("Each x, y position is separated by a comma -> 7,6 ==> 7 is x, 6 is y");
            string points = Console.ReadLine();
            userShape = new Polyline(points);
            Console.WriteLine("Polyline ("+points+") added to the canvas.");

            
           }
           else if( userDecision=="n")
           {
            userShape = new Polyline();
            Console.WriteLine("Polyline (20,20 40,25 60,40 80,120 120,140 200,180) added to the canvas.");
           }
             
           
           userDecision="";
           Console.WriteLine("Would you like to change the default polyline colour and the line thickness size?"+"\n(Type 'y' for yes)"+"\n(Type 'n' for no)");
           userDecision = Console.ReadLine();
             if(userDecision=="y")
           {
            Console.WriteLine("Type in 2 colours and a number,pressing enter everytime");
             Console.WriteLine("Shape Colour:");
             string fillcolour = Console.ReadLine().ToLower();
             Console.WriteLine("Shape Outline Colour");
             string strokecolour = Console.ReadLine().ToLower();
             Console.WriteLine("Shape Outline Thickness");
             string strokesize = Console.ReadLine();
             userShape.setFill(fillcolour);  
             userShape.setStroke(strokecolour);
             userShape.setStrokeWidth(strokesize);
             Console.WriteLine("This is your Polyline!");
            
           Console.WriteLine(userShape.getShapeAttribute());
             
           }
           else if(userDecision=="n")
           {
             userShape.setFill("");
             userShape.setStroke("");
             userShape.setStrokeWidth("");
             Console.WriteLine("This is your Polyline!");
           Console.WriteLine(userShape.getShapeAttribute());
           }
           fillColour = userShape.getFill();
           strokeColour= userShape.getStroke();
           StrokeWidthSize = userShape.getStrokeWidth();
           memory.AddHistory(userShape.getShapeAttribute());
           newCanvas.AddShape(userShape.getShapeAttribute());//adds polyline string to list
           memory.clearRedoList(); 
            break;

            case "A rectangle":
            Console.WriteLine("Drawing a Rectangle!");
              userDecision="";
          
            Console.WriteLine("Would you like to change default rectangle size?"+"\n(Type 'y' for yes)"+"\n(Type 'n' for no)" );
           userDecision = Console.ReadLine();
            
             userShape = new Rectangle();
           if(userDecision=="y")
           {
            Console.WriteLine("Type in 4 numbers, pressing enter everytime ");
            Console.WriteLine("Rectangle x coordinate:");
            string x = Console.ReadLine();
            Console.WriteLine("Rectangle y coordinate:");
            string y = Console.ReadLine();
            Console.WriteLine("Rectangle height:");
            string height = Console.ReadLine();
            Console.WriteLine("Rectangle weight:");
            string width = Console.ReadLine();
            userShape = new Rectangle(x,y,height,width);
            Console.WriteLine(" Rectangle	(H="+height+",W="+width +",X="+x+","+"y="+y+") added to the canvas.");

            
           }
           else if( userDecision=="n")
           {
            string height = r.Next(1,100).ToString();
            string weight = r.Next(1,100).ToString();
            string x = r.Next(1,100).ToString();
            string y = r.Next(1,100).ToString();
            userShape = new Rectangle();
            Console.WriteLine("Rectangle (H=10,W=20,X=40,y=60) added to the canvas.");
           }
             
           
           userDecision="";
           Console.WriteLine("Would you like to change the default rectangle colour and the line thickness size?"+"\n(Type 'y' for yes)"+"\n(Type 'n' for no)");
           userDecision = Console.ReadLine();
             if(userDecision=="y")
           {
             Console.WriteLine("Type in 2 colours and a number,pressing enter everytime");
             Console.WriteLine("Shape Colour:");
             string fillcolour = Console.ReadLine().ToLower();
             Console.WriteLine("Shape Outline Colour");
             string strokecolour = Console.ReadLine().ToLower();
             Console.WriteLine("Shape Outline Thickness");
             string strokesize = Console.ReadLine();
             userShape.setFill(fillcolour);  
             userShape.setStroke(strokecolour);
             userShape.setStrokeWidth(strokesize);
             Console.WriteLine("This is your Rectangle!");
             
           Console.WriteLine(userShape.getShapeAttribute());
             
           }
           else if(userDecision=="n")
           {
             userShape.setFill("");
             userShape.setStroke("");
             userShape.setStrokeWidth("");
              Console.WriteLine("This is your Rectangle!");
              memory.AddHistory(userShape.getShapeAttribute());
           Console.WriteLine(userShape.getShapeAttribute());
           }
           fillColour = userShape.getFill();
           strokeColour= userShape.getStroke();
           StrokeWidthSize = userShape.getStrokeWidth();
           memory.AddHistory(userShape.getShapeAttribute());
           newCanvas.AddShape(userShape.getShapeAttribute());//adds svg rectangle string to list
           memory.clearRedoList();
            break;
             
             case "A square":
            Console.WriteLine("Drawing a Square!");
              userDecision="";
          
            Console.WriteLine("Would you like to change default square size?"+"\n(Type 'y' for yes)"+"\n(Type 'n' for no)" );
           userDecision = Console.ReadLine();
            
             userShape = new Rectangle();
           if(userDecision=="y")
           {
            Console.WriteLine("Type in 3 numbers, pressing enter everytime ");
            Console.WriteLine("Square x coordinate:");
            string x = Console.ReadLine();
            Console.WriteLine("Square y coordinate:");
            string y = Console.ReadLine();
            Console.WriteLine("Square height:");
            string height = Console.ReadLine();


            userShape = new Square(x,y,height);
            Console.WriteLine(" Square	(L="+height+","+"X="+x+","+"y="+y);
            
           }
           else if( userDecision=="n")
           {
            string x = r.Next(1,100).ToString();
            string y = r.Next(1,100).ToString();
            string height = r.Next(1,100).ToString();
           userShape = new Square(x,y,height);
           Console.WriteLine(" Square	(L="+height+","+"X="+x+","+"y="+y);
           }
             
           
           userDecision="";
           Console.WriteLine("Would you like to change the default square colour and the line thickness size?"+"\n(Type 'y' for yes)"+"\n(Type 'n' for no)");
           userDecision = Console.ReadLine();
             if(userDecision=="y")
           {
             Console.WriteLine("Type in 2 colours and a number,pressing enter everytime");
             Console.WriteLine("Shape Colour:");
             string fillcolour = Console.ReadLine().ToLower();
             Console.WriteLine("Shape Outline Colour");
             string strokecolour = Console.ReadLine().ToLower();
             Console.WriteLine("Shape Outline Thickness");
             string strokesize = Console.ReadLine();
             userShape.setFill(fillcolour);  
             userShape.setStroke(strokecolour);
             userShape.setStrokeWidth(strokesize);
             Console.WriteLine("This is your Square!");
             
           Console.WriteLine(userShape.getShapeAttribute());
             
           }
           else if(userDecision=="n")
           {
             userShape.setFill("");
             userShape.setStroke("");
             userShape.setStrokeWidth("");
              Console.WriteLine("This is your Square!");
              
           Console.WriteLine(userShape.getShapeAttribute());
           }
           fillColour = userShape.getFill();
           strokeColour= userShape.getStroke();
           StrokeWidthSize = userShape.getStrokeWidth();
           memory.AddHistory(userShape.getShapeAttribute());
           newCanvas.AddShape(userShape.getShapeAttribute());//adds svg rectangle string to list
           memory.clearRedoList(); 
            break;
            
            case "A text":
            Console.WriteLine();

             userDecision="";
          
            Console.WriteLine("Would you like to change default text?"+"\n(Type 'y' for yes)"+"\n(Type 'n' for no)" );
           userDecision = Console.ReadLine();
            
             userShape = new Text();
           if(userDecision=="y")
           {
            Console.WriteLine("Type in 2 numbers, pressing enter everytime ");
            Console.WriteLine("Text x coordinate:");
            string x = Console.ReadLine();
            Console.WriteLine("Text y coordinate:");
            string y = Console.ReadLine();
            Console.WriteLine("Text font: for example type in 'italic 20px sans-serif' for ur text to be in italic font of size 20px");
            string font = Console.ReadLine();
            Console.WriteLine("Class font: Type in any name , in lowercase, for your text class to be called such as: mytextclass");
            string className = Console.ReadLine();
            Console.WriteLine("Text: Enter any text of any length you would like to show on your canvas");
            string text = Console.ReadLine();
            


            userShape = new Text(x,y,font,className,text);
            Console.WriteLine("Text (Text="+text+" ,font="+font+" ,class="+className+" ,X="+x+", y="+y);
            
           }
           else if( userDecision=="n")
           {
            string x = r.Next(1,100).ToString();
            string y = r.Next(1,100).ToString();
            string font="italic 20px sans-serif";
            string className="textclass";
            string text="This Text is Placed on Your SVG Canvas";

             userShape = new Text(x,y,font,className,text);
            Console.WriteLine("Text (Text="+text+" ,font="+font+" ,class="+className+" ,X="+x+", y="+y);
            
           }
             
           
           userDecision="";
           Console.WriteLine("Would you like to change the default text colour?"+"\n(Type 'y' for yes)"+"\n(Type 'n' for no)");
           userDecision = Console.ReadLine();
             if(userDecision=="y")
           {
             Console.WriteLine("Text Colour:");
             string fillcolour = Console.ReadLine().ToLower();
             userShape.setFill(fillcolour);  
             Console.WriteLine("This is your Text!");
             
           Console.WriteLine(userShape.getShapeAttribute());
             
           }
           else if(userDecision=="n")
           {
             userShape.setFill("");
              Console.WriteLine("This is your Text!");
              
           Console.WriteLine(userShape.getShapeAttribute());
           }
           fillColour = userShape.getFill();  
           newCanvas.AddShape(userShape.getShapeAttribute());//adds svg rectangle string to list 
           memory.AddHistory(userShape.getShapeAttribute());
           memory.clearRedoList(); 
            break;

            case "C":          
            newCanvas.ClearCanvas();
            newCanvas.AddShape("");
            Console.WriteLine("List Cleared!");
            memory.AddHistory("");
            //is there a way i can save an empty canvas and then go back to that empty canvas?
            //How do i revert back to the state where shapes were drawn on the canvas?
            //when i undo or redo after clearing a canvas i get an out of bounds message
            //i wanted to see what would happen if i added an empty string into my canvas-> it fixed the out of bounds message when i undo however it wouldnt return back to the state it had shapes in.
            //i think ill look into this in future
            //im not 100% sure what the action is required to go back to a drawn canvas once cleared , my inital thoughts were undo , since its undoing the clear action but now im not so sure
            break;

           case "Q":
           Console.WriteLine("Your session is finished!"+"\nHave a nice day<3 ");
           endSession =true;
           break;

           case "R":
         string redo = memory.Redo();
        /* if()
         {

         } */
          newCanvas.AddShape(redo);
          Console.WriteLine(redo);           
          
           break;
           
           case "U":
           string undid = memory.Undo();
           Console.WriteLine(undid);
            newCanvas.RemoveShape();
           break;

           case "P":
           Console.WriteLine("Your History: ");
           Console.WriteLine();
           memory.printHistory();
         
           
           break;

           case "D":
           newCanvas.ShapesDrawnList();
           break;

            case "Up":
           Console.WriteLine("Enter a number to select a shape you would like to update"); //extra credit
            newCanvas.ShapesDrawnList();
            userChoice =Console.ReadLine();
            string shapeUpdate= newCanvas.UpdateShapeName(userChoice);
            int index = int.Parse(userChoice);
           Console.WriteLine(shapeUpdate);
           Console.WriteLine("What would you like to update in this shape?");
           Console.WriteLine("Please enter an attribute you would like to change, for example: Enter strokewidth to change the shape outline size");
           userChoice =Console.ReadLine();

         // Console.WriteLine("fill length og:"+ogfilllength);  

         /*I can undo the shape after the update however the original state is lost -> need to sort this out */
       
              if(userChoice =="fill")
               { 
            Console.WriteLine("Enter a new colour you would like your shape to have");
            
              string newFill = Console.ReadLine().ToLower();
               shapeUpdate = shapeUpdate.Replace(fillColour,newFill);
             newCanvas.UpdateShapeAttributes(index,shapeUpdate);
               }
               else if(userChoice=="stroke")
               {
                Console.WriteLine("Enter a new colour you would like your shape outline to have");
                string newStroke= Console.ReadLine().ToLower();
                  shapeUpdate = shapeUpdate.Replace(strokeColour, newStroke);
                  newCanvas.UpdateShapeAttributes(index,shapeUpdate);
               }
               else if(userChoice=="strokewidth"){
                Console.WriteLine("Enter a new thickness size you would like your shape outline to have");
                  string newStrokeWidth = Console.ReadLine();
                  shapeUpdate = shapeUpdate.Replace(StrokeWidthSize, newStrokeWidth);
                  newCanvas.UpdateShapeAttributes(index,shapeUpdate);
               }
              newCanvas.removeExtra(index);
              Console.WriteLine();
             Console.WriteLine("New Shape looks like"+"\n"+shapeUpdate);
             memory.AddHistory(shapeUpdate);
               
             break;

              case "Del":
            Console.WriteLine("Enter a number to select a shape you want to delete!"); //extra credit
             newCanvas.ShapesDrawnList();
            userChoice =Console.ReadLine();
            newCanvas.DeleteShape(userChoice);

            Console.WriteLine("Your new list looks like: ");
            Console.WriteLine();
            newCanvas.ShapesDrawnList();
            break;



             default:
            Console.WriteLine(" Commands:");
            Console.WriteLine(" H	 	 Help	-	displays this message");
            Console.WriteLine(" A	<shape>	 Add <shape	to canvas");
            Console.WriteLine(" D     Display Canvas");
            Console.WriteLine(" Del   Delete a chosen shape");
            Console.WriteLine(" Up    Update a chosen shape");
            Console.WriteLine(" U	 	  Undo last operation");
            Console.WriteLine(" R	 	  Redo last operation");
            Console.WriteLine(" C	 	  Clear canvas");
            Console.WriteLine(" P	 	  Print History");
            Console.WriteLine(" Q	 	  Quit application");
            userChoice = Console.ReadLine();
            break;                    
            
         }
         
        }

Console.WriteLine("Are you satisfied with your svg shape list?"+"\nThis is the order in which they will be drawn, higher indexed numbers will b drawn on top of the lower indexed ones.");
Console.WriteLine("For example: index 6 will b overlap on top of index 2 ");
newCanvas.ShapesDrawnList();


Console.WriteLine();
Console.WriteLine("(Type 'y') if satisfied otherwise (Type 'n')");
string userAns = Console.ReadLine(); 
 bool endZindexMangement = false;
//managing the z-index commands
switch(userAns)
{
  case "y":
  Console.WriteLine("Your file will be saved and exported as file format type svg");
  break;

  case "n":
  Console.WriteLine("Choose what you would like to do:");
  Console.WriteLine("[1] -> Swap two shape indexes"+"\n[2] -> Change a specific shape index");
  Console.WriteLine("When you are finished sorting out your shape positions(Type 'done' )");
  userAns = Console.ReadLine();
while(endZindexMangement ==false){
  if(userAns=="1")
  {

    Console.WriteLine("Enter two numbers to select which two shapes you would like to swap!"+"Press enter everytime");
    newCanvas.ShapesDrawnList();
    Console.WriteLine();
    Console.WriteLine("first shape:");
    string zindex1 = Console.ReadLine();
    Console.WriteLine("Second shape:");
    string zindex2 =Console.ReadLine();
    newCanvas.SwapZindexes(zindex1,zindex2);

    Console.WriteLine("This is your new list!");
    newCanvas.ShapesDrawnList();

  }
  else if(userAns=="2")
  {
     Console.WriteLine("Note: You can only only change the lower positioned shape to a higher one as it would automatically default the higher ones to a lower position! ");
      Console.WriteLine("Note: the position you choose will b 1 lower to account for the list size");
      Console.WriteLine("Enter a number to select which shape you would like to change its shape position in the list(z-index)!");
      newCanvas.ShapesDrawnList();
      string shape= Console.ReadLine();
      Console.WriteLine("Enter a number where you would like to put ur shape");
      string zindex = Console.ReadLine();
      newCanvas.ChangeShapeZindex(shape,zindex);
      
      Console.WriteLine("This is your new list!");
  }
  else if(userAns=="done")
  {
     Console.WriteLine("Your shape managing session is over<3");
     endZindexMangement = true;
     
  }
  else{
    Console.WriteLine("not a valid input!");
    Console.WriteLine("[1] -> Swap two shape indexes"+"\n[2] -> Change a specific shape index");
  }

}
  break;
}
 Console.WriteLine();        
//svg string 


//manages svg file export


string userFileName="UserSketchpad.svg";
Console.WriteLine("Would you like to create a name for your file?"+"\n(Type 'y' for yes)"+"(Type 'n' for no)");
  Console.WriteLine();
  string userFileChoice = Console.ReadLine();


  switch(userFileChoice)
  {
    case "y":
     Console.WriteLine("Type in a name for your file, for example: Sketchpad.svg");
     userFileName = Console.ReadLine();
    break;

    case "n":
    userFileName="UserSketchpad.svg";
    break;
  }

 string pathString = @"C:\Users\pdere\Downloads\3rd-Year-Modules\CS264_Software Design\assignment-03-20325666\Ass3TestExtra";
 pathString = System.IO.Path.Combine(pathString, userFileName);
   
   Console.WriteLine("Writing your svg file to a folder");
using(StreamWriter sw = File.CreateText(pathString))
{
 sw.WriteLine(svgStartTag);
 sw.WriteLine(newCanvas.GetShapeDrawnList());
 sw.WriteLine();
 sw.WriteLine(svgEndTag);
}
Console.WriteLine("What your svg file looks like:");
Console.WriteLine();
Console.WriteLine(svgStartTag);
newCanvas.ShapesDrawnList();
Console.WriteLine(svgEndTag);
      
      //file managing

   
   
    /*foreach string x in canvas Console.WriteLine(x), File.WriteAllLines(filename.svg, canvas) */

    }
   
   
}


}

