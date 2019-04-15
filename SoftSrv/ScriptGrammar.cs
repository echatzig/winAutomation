using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Irony.Parsing;

namespace SoftSrv
{
    public class ScriptGrammar : Grammar
    {
        public ScriptGrammar()
        {
            //// 1. Terminals
            Terminal number = new NumberLiteral("number");
            Terminal str = new StringLiteral("string", "\"");

            //// 2. Non-terminals
            NonTerminal Statements = new NonTerminal("Statements");
            NonTerminal Stmt = new NonTerminal("Stmt");
            NonTerminal Command = new NonTerminal("Command");
            this.Root = Statements;
            ////3. BNF Rules
            Statements.Rule = MakePlusRule(Statements, Stmt);

            Stmt.Rule = ToTerm("select-window") + str |
                        ToTerm("mouse-move") + number + "," + number |
                        ToTerm("mouse-click") + "single-click" |
                        ToTerm("send-keys") + str;

        }
    }
}


