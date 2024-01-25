
//canvas keeps track of all the shapes in the list for the user to update, delete and create new shapes.
using System;
using System.Collections;


public class Canvas{


  private  ArrayList shapeList = new  ArrayList();

  private string shape;

  private string shapesList;

  public Canvas()
  {   
     this.shapeList =shapeList;
  }
//adds the svg shape string to the list
  public void AddShape(string shape)
  {
   
    shapeList.Add(shape);
   
    // this.shapeList =shapeList;
  }
  //prints the shapes being drawn so far
  public void ShapesDrawnList()
  {
    int i=0; //refers to the z-index in the list , where the greater the number the higher the stackin order is.
    foreach(var shape in shapeList)
    {
      Console.WriteLine("["+i+"]"+" "+shape);
      i++;
    }
  }
  //to return to main method for the svg shapes to b written in the file
  public string GetShapeDrawnList()
  {
     foreach(var shape in shapeList)
    {
      shapesList += shape+"\n";
    }
    return shapesList;
  }


//Deletes shape
  public void DeleteShape(string del)
  {
    int delete = Int32.Parse(del);
    for(int i =0; i < shapeList.Count; i++)
    {
      if(i==delete)
      {
        shapeList.RemoveAt(delete);
      }
    }
  }


  public void RemoveShape()
  {
    shapeList.RemoveAt((shapeList.Count)-1);
  }
  //Clears Canvas
  public void ClearCanvas()
  {
    shapeList.Clear();
  }
//updates shapes
  public string UpdateShapeName(string shape)
  {

  string shapeToBUpdated = (string)shapeList[Int32.Parse(shape)]; 
    return shapeToBUpdated;
  }
  public void UpdateShapeAttributes(int index,string shapeUpdate)
  { 
    
    shapeList.Insert(index,shapeUpdate);
    
  }
  //removes the old shape , as when i insert the updated shape at the old shape index , it would push the old shape up the list
  public void removeExtra(int index)
  {
    shapeList.RemoveAt(index+1);
  }
  //Managing my shapes list z index
  //changes the z-index of a chosen shape
  //thereotically this should work as an arraylist doesnt have a definined size, however
  public void ChangeShapeZindex(string shape, string zindex)
  {
  
    int change = Int32.Parse(zindex);
    string shapeChange = (string)shapeList[Int32.Parse(shape)];
    

    for(int i=0; i< shapeList.Count; i++)
    {
      if(i==Int32.Parse(shape))
      {
        shapeList.RemoveAt(Int32.Parse(shape));
      }
    }
    shapeList.Insert((change-1), shapeChange);

  }
  //swaps 2 zindexes of user chosen shapes
  public void SwapZindexes(string zindex1, string zindex2)
  {
     
     int swap1 = Int32.Parse(zindex1);
     int swap2 = Int32.Parse(zindex2);

    var temp = shapeList[swap1];
     shapeList[swap1]= shapeList[swap2];
     shapeList[swap2]= temp;
  }
  

}









/*Steps : Make a canvas class that the user will use to draw their desired shape 
look into shape interfaces -> we may want to just extract the values instead of the behaviours 
user input will call a shape/class -> switch case (Circle / Rectangle / Line / Polygon / Polyline / Path)

Shapes can be drawn anywhere and there can only be one canvas

svg output code should be exported to an svg file ( write svg file with the code)
show user the svg code -> have an option to save or rewrite

z index ->height -> first one is always at the top everything else gets drawn underneath 
-> cant change their z index

shift + alt + k +f  -> indents everything

first idea for algorithm -> create an interface for shapes that returns the wanted values to the interface -> need to extract them
how? -> research? -> the interface will have abstract methods for desired shapes?

in interface class -> Shapes( length , width , height, colour, fill, stroke-width)

"<svg height="210" width="500">
  <polygon points="200,10 250,190 160,210" style="fill:lime;stroke:purple;stroke-width:1" />
</svg>" -> svg example

in output for user i need:

user read coordinates and lengths
save or redo function
for user input have a loop looking for user input shapes

canvas class will be a list of shapes ->

file system -> write to files -> empty  file -> add svg 
inheritance 
*/