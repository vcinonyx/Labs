using System;
using System.Linq;

namespace CSharp
{
    public class Text
    {
        public Line[] _content;

        public Text()
        {
            _content = new Line[] { };
        }

        public void AddLine(Line newLine)

        {
            Array.Resize(ref _content, _content.Length + 1);
            _content[_content.Length - 1] = newLine;
        }

        public void RemoveLine(int lineNumber)
        {
            Line[] newText = new Line[_content.Length - 1];
            for (int i = 0; i < _content.Length; i++)
            {
                if (i < lineNumber)
                {
                    newText[i] = _content[i];
                }
                if (i > lineNumber)
                {
                    newText[i - 1] = _content[i];
                }
            }
            _content = newText;
        }

        public int CharCounter()
        {
            int counter = 0;
            for (int i = 0; i < _content.Length; i++)
            {
                counter += _content[i].str.Length;
            }
            return counter;
        }

        public void ClearText()
        {
            _content = new Line[0];
        }
        public int FindStr(char[] subStr)
        {
            int counter = 0;
            for(int i = 0; i<_content.Length; i++)
            {
                counter +=_content[i].FindSubStr(subStr);
            }
            return counter;
        }

        public void Replace(string a, string b)
        {
            for (int i = 0; i < _content.Length; i++)
            {
                _content[i].CharReplace(a, b);     
            }
        }
    }
}
