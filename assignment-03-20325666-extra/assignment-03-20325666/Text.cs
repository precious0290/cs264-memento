//Extra Credit
public class Text : Shape
{
    private string x;
    private string y;
    private string fill=""; // shape colour
    private string stroke=""; //outline colour
    private string strokewidth=""; //shape thickness
    private string font="";
    private string className ="";
    private string text="";

public Text()
{
        this.x = "40";
        this.y = "60";
        this.font ="italic 20px sans-serif";
        this.className ="textclass";
        this.text="This Text is Placed on Your SVG Canvas";

}
    public Text(string x,string y,string font, string className,string text )
    {
        this.x = x;
        this.y = y;
        this.font = font;
        this.className = className;
        this.text = text;

    }

public void setFill(string fill)
    {
         if(fill =="")
        {
            this.fill = "black";
        }
        else{
            this.fill = fill;
        }
       
    }
    public string getFill()
    {
        return fill;
    }
    public void setStroke(string stroke)
    {
        if(stroke=="")
        {
          this.stroke = "black";  
        }
        else{
             this.stroke = stroke;
        }
       
    }
    public string getStroke()
    {
        return stroke;
    }
    public  void setStrokeWidth(string strokewidth)
    {
       
        if(strokewidth=="")
        {
            this.strokewidth ="1";
        }
        else{
             this.strokewidth = strokewidth;
        }
    }
    public string getStrokeWidth()
    {
        return strokewidth;
    }

    public string getShapeAttribute()
    {
        return "<style>"+"\n."+className+" {"+"\nfont: "+font+";"+"\nfill: "+fill+";"+"\n}"+"\n</style>"+"\n" + "<text x="+"\""+x+"\""+" y="+"\""+y+"\""+" class="+"\""+className+"\""+">"+text+"</text>"; //"<text x="20" y="35" class="small">My</text> />";
    }
    
}

//i took references from the mozilla website on how to compute a text svg string
/* <style>
    .small {
      font: italic 13px sans-serif;
    }
    .heavy {
      font: bold 30px sans-serif;
    }

    /* Note that the color of the text is set with the    *
     * fill property, the color property is for HTML only 
      font: italic 40px serif;
      fill: red;
    }
  </style>

  <text x="20" y="35" class="small">My</text> 
  */
  

  