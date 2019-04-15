using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Irony.Parsing;

namespace SoftSrv
{
    public class ScriptParser
    {
        public List<WinAutoParams> _parms = new List<WinAutoParams>();

        public ScriptParser(string script)
        {
            ScriptGrammar ex = new ScriptGrammar();
            Parser parser = new Parser(ex);
            ParseTree parseTree = parser.Parse(script);
            if (!parseTree.HasErrors())
            {
                Console.WriteLine(parseTree.Status.ToString());
                ParseTree(parseTree.Root, 0);
            }
            else
            {
                string errors = "Error in parsing";
                foreach (var s in parseTree.ParserMessages)
                    errors += "\n" + s;
                Console.WriteLine(errors);

                throw new Exception(errors);
            }

        }

        public void ParseTree(ParseTreeNode node, int level)
        {
            for (int i = 0; i < level; i++)
                Console.Write("  ");

            Console.WriteLine(node);
            if (level == 1)
            {
                switch (node.ChildNodes[0].Token.Text)
                {
                    case "select-window":
                        _parms.Add(new SelectWindowParams { window = node.ChildNodes[1].Token.Text });
                        break;
                    case "mouse-move":
                        _parms.Add(new SetCursorParams
                        {
                            x = Int32.Parse(node.ChildNodes[1].Token.Text),
                            y = Int32.Parse(node.ChildNodes[3].Token.Text)
                        });
                        break;
                    case "mouse-click":
                        _parms.Add(new MouseClickParams() {
                            click = node.ChildNodes[1].Token.Text == "single-click" ? 
                                        MouseClickParams.clicktype.single_click : MouseClickParams.clicktype.double_click 
                        });
                        break;
                    case "send-keys":
                        _parms.Add(new SendKeysParams
                        {
                            str = node.ChildNodes[1].Token.Text
                        });
                        break;
                }
            }

            foreach (ParseTreeNode child in node.ChildNodes)
                ParseTree(child, level + 1);
        }
    }

    /*  This is an example AST created from a simple script
     *  ----
     
    Statements
      Stmt
        select-window (Keyword)
        Firefox - www.google.com (string)
      Stmt
        mouse-move (Keyword)
        192 (number)
        , (Key symbol)
        100 (number)
      Stmt
        mouse-click (Keyword)
        single-click (Keyword)
      Stmt
        send-keys (Keyword)
        today in wikipedia (string)
      Stmt
        mouse-move (Keyword)
        192 (number)
        , (Key symbol)
        150 (number)
      Stmt
        mouse-click (Keyword)
        single-click (Keyword)
     */

}
