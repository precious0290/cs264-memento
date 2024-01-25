using System.Collections;
public class Memento  
{
 private  ArrayList shapeList = new  ArrayList();

  private string memento; //memento

  private string shapesList; // originator -> carries the original state of canvas
  private ArrayList history = new ArrayList(); //history  -> shows all actions that takes place
  private ArrayList caretaker = new ArrayList();//caretaker


  public Memento()
  {
     this.shapeList = shapeList; //originator
     this.caretaker = caretaker;//caretaker
    this.history = history; 
     
  }
  //saves my shapes into these 2 lists
  public void AddHistory(string memento)
  {
   
      history.Add(memento);
    shapeList.Add(memento);
     
    
  }
  // have to figure out a way to get the shape back after i undo and create a new shape then press redo
  // -> when u undo a shape and u want to get it back u need to press redo a number of times, so for instance when u
  // create a circle first and then undo the circle, then create another shape, u must  press r twice, this will redo ur new created shape aswell as the circle.

// adds the last thing thats on shapeList to the history when it comes to undoing
  public string Undo()
  {
    
    caretaker.Add(shapeList[(shapeList.Count)-1]);
    string undid = shapeList[(shapeList.Count)-1].ToString();
    shapeList.Remove(shapeList[(shapeList.Count)-1]);
    
    return undid;
  }
/*Redo -> when u Undo a shape u created -> Make a new shape -> U cannot redo the first shape since it erases the history timeline */
  //need to find a way to delete old shape once a new shape is created.
  public string Redo()
  {  

     // possibly checking if the element in the history index is the same as the one in caretaker
     //if the string is not the same then u cant redo?
    string redo = caretaker[(caretaker.Count)-1].ToString();
    shapeList.Add(caretaker[(caretaker.Count)-1]);
    caretaker.Remove(caretaker[(caretaker.Count)-1]);
    return redo;
    //return redo to main?
  }
  public void clearRedoList()
  {
    caretaker.Clear();
  }

  public ArrayList getHistory()
  {
    return history;
  }
  public void printHistory()
  {
    
    foreach( var h in history)
    {
      Console.WriteLine(h+"\n");
    }
    /*
     Console.WriteLine();
    foreach( var s in shapeList)
    {
      Console.WriteLine(s+"\n");
    }
    Console.WriteLine();
    foreach( var c in caretaker)
    {
      Console.WriteLine(c+"\n");
    }*/
  } 

}



/*//Memento Design Pattern
//-----------------------------------------------------------------------------------------------------------------------
    //took this mainly from the tutorial -> thank you Mark
    class Memento
    {
        Shape shape;
        public Shape getShape()
        {
            return this.shape;
        }
        public void setShape(Shape s)
        {
            this.shape = s;
        }
    }
//-----------------------------------------------------------------------------------------------------------------------
    //caretaker is used to store memento inside in
    //taken  and adapted from the tutorial provided by Mark -> Thank you Mark
    //https://www.dofactory.com/net/memento-design-pattern
    class Caretaker
    {
        List<Memento> CareUndoRedo = new List<Memento>();
        Memento state = new Memento();
        public Memento getState()
        {
            this.state = this.CareUndoRedo[CareUndoRedo.Count-1];
            this.CareUndoRedo.RemoveAt(CareUndoRedo.Count - 1);
            return this.state;
        }
        public void addState(Memento m)
        {
            this.state = m;
            this.CareUndoRedo.Add(state);
        }
        public int getSize() 
        { 
            return this.CareUndoRedo.Count; 
        }
    } */


/*Mementos are snapshots that save progress of the canvas. So theyre kinda like a canvas being drawn 1 step behind the original canvas i think */
/* For a memento i need  -> Redo(Push ?), Undo(Pop ?) , History( ShapeList array), */