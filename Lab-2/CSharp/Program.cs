using System;

namespace CSharp

{
    class Program
    {
        static void Main()
        {
            Text text_obj = new Text();
            text_obj.AddLine(new Line("Lorem ipsum dolor sit amet"));
            text_obj.AddLine(new Line("consectetur adipiscing elit"));
            text_obj.AddLine(new Line("Maecenas odio tellus, dictum"));
            text_obj.AddLine(new Line("in mattis sed, vehicula ut ex"));
            PrintText(text_obj);
            Console.WriteLine(text_obj.CharCounter());
            text_obj.ClearText();
            text_obj.AddLine(new Line("lil punp, future gucci gang"));
            text_obj.AddLine(new Line("young thug, lil baby, gunna"));
            text_obj.AddLine(new Line("j cole, kenrick lamar, dmx"));
            text_obj.AddLine(new Line("illumate, vitonegrgucci "));
            text_obj.RemoveLine(2);
            Console.WriteLine(text_obj.FindStr("gucci".ToCharArray()));
            Console.WriteLine(text_obj.CharCounter());
            text_obj.Replace("u", "b");
            PrintText(text_obj);
        }

        static void PrintText(Text text)
        {
            foreach (Line line in text._content)
            {
                Console.WriteLine(line.str);
            }
        }
    }
}